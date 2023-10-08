using Dapper;
using Newtonsoft.Json;
using NorthwindAPI.Core.ApplicationSettings.Concrete;
using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.Core.Results.Concrete;
using NorthwindAPI.DAL.Repository.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperGenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected IResult<T> result;
        protected IResult<List<T>> resultList;
        protected string connectionString; //= "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true";

        public DapperGenericRepository()
        {
            //todo it may be dependency injection
            result = new Result<T>();
            resultList = new Result<List<T>>();
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                var settings = JsonConvert.DeserializeObject<APIApplicationSetting>(json);
                connectionString = settings?.ConnectionString;
            }
        }
        public async Task<IResult<List<T>>> GetListAsync()
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM {tableName}";
            return await QueryListAsync(query);
        }
        public async Task<IResult<T>> GetAsync(int id)
        {
            string tableName = GetTableName();
            string keyColumn = GetKeyColumnName();
            string query = $"SELECT * FROM {tableName} WHERE {keyColumn} = '{id}'";
            return await QueryAsync(query);
        }
        public async Task<IResult<T>> InsertAsync(T entity)
        {
            string tableName = GetTableName();
            string columns = GetColumns(excludeKey: true);
            string properties = GetPropertyNames(excludeKey: true);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";
            return await ExecuteAsync(query, entity);
        }
        public async Task<IResult<T>> UpdateAsync(T entity)
        {
            string tableName = GetTableName();
            string keyColumn = GetKeyColumnName();
            string keyProperty = GetKeyPropertyName();
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE {tableName} SET ");
            foreach (var property in GetProperties(true))
            {
                var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
                string propertyName = property.Name;
                string columnName = columnAttr.Name;
                query.Append($"{columnName} = @{propertyName},");
            }
            query.Remove(query.Length - 1, 1);
            query.Append($" WHERE {keyColumn} = @{keyProperty}");
            return await ExecuteAsync(query.ToString(), entity);
        }
        public async Task<IResult<T>> DeleteAsync(int id)
        {
            string tableName = GetTableName();
            string keyColumn = GetKeyColumnName();
            string query = $"DELETE FROM {tableName} WHERE {keyColumn} = {id}";
            return await ExecuteAsync(query, null);
        }
        protected async Task<IResult<List<T>>> QueryListAsync(string query)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);
                var result = await connection.QueryAsync<T>(query);
                return resultList.FillSuccessResult(result?.ToList());
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
            return resultList;
        }
        protected async Task<IResult<T>> QueryAsync(string query)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);
                var result = await connection.QueryAsync<T>(query);
                return this.result.FillSuccessResult(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
        protected async Task<IResult<T>> ExecuteAsync(string query, T entity)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);
                await connection.ExecuteAsync(query, entity);
                return result.FillSuccessResult(entity);
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
        protected string GetColumns(bool excludeKey = false, Type entityType = null, string tableAs = null)
        {
            var type = entityType == null ? typeof(T) : entityType;
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => p.CustomAttributes.Count() > 0 && p.PropertyType.Name != "ICollection`1" && (!excludeKey || !p.IsDefined(typeof(KeyAttribute))))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    string columnName = columnAttr != null ? columnAttr.Name : p.Name;
                    return tableAs == null ? columnName : tableAs + "." + columnName;
                }));
            return columns;
        }
        protected string GetTableName(Type entityType = null, string tableAs = null)
        {
            string tableName = "";
            var type = entityType == null ? typeof(T) : entityType;
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;
                return tableAs == null ? tableName : tableName + " as " + tableAs;
            }
            return tableAs == null ? type.Name + "s" : type.Name + "s" + " as " + tableAs;
        }
        protected static string GetKeyColumnName()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if (keyAttributes != null && keyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute.Name;
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }
            return null;
        }
        protected string GetPropertyNames(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.CustomAttributes.Count() > 0 && p.PropertyType.Name != "ICollection`1" && (!excludeKey || p.GetCustomAttribute<KeyAttribute>() == null));

            var values = string.Join(", ", properties.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return values;
        }
        protected IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.CustomAttributes.Count() > 0 && p.PropertyType.Name != "ICollection`1" && (!excludeKey || p.GetCustomAttribute<KeyAttribute>() == null));

            return properties;
        }
        protected string GetKeyPropertyName()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.CustomAttributes.Count() > 0 && p.PropertyType.Name != "ICollection`1" && p.GetCustomAttribute<KeyAttribute>() != null);

            if (properties.Any())
            {
                return properties.FirstOrDefault().Name;
            }
            return null;
        }
    }
}

