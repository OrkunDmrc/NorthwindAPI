using Dapper;
using NorthwindAPI.Domain.Entities.Abstract;
using NorthwindAPI.Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Infrastructure.Repositories.Concrete.Dapper
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true";
        private readonly Dictionary<string, string> tableNames = new Dictionary<string, string>();
        public GenericRepository()
        {
            /*tableNames.Add("Category", "Categories");
            tableNames.Add("Customer", "Customers");
            tableNames.Add("Employee", "Employees");
            tableNames.Add("EmployeeTerritory", "EmployeeTerritories");
            tableNames.Add("Order", "Orders");
            tableNames.Add("OrderDetail", "OrderDetails");
            tableNames.Add("Product", "Products");
            tableNames.Add("Region", "Regions");
            tableNames.Add("Shipper", "Shippers");
            tableNames.Add("Supply", "Supplies");
            tableNames.Add("Territory", "Territories");*/
        }
        public async Task DeleteAsync(T entity)
        {
            /*await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"DELETE FROM dbo.{tableNames[nameof(T)]} WHERE Id = {id}");*/
            string tableName = GetTableName();
            string keyColumn = GetKeyColumnName();
            string keyProperty = GetKeyPropertyName();
            string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(query, entity);
        }

        public async Task<T> GetAsync(int id)
        {
            /*await using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<T>($"SELECT * FROM dbo.{tableNames[nameof(T)]} WHERE = '{id}'");*/
            string tableName = GetTableName();
            string keyColumn = GetKeyColumnName();
            string query = $"SELECT * FROM {tableName} WHERE {keyColumn} = '{id}'";
            await using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<T>(query);
            return result.FirstOrDefault();
        }

        public async Task<List<T>> GetListAsync()
        {
            /*await using var connection = new SqlConnection(_connectionString);
            return (await connection.QueryAsync<T>($"SELECT * FROM dbo.{tableNames[nameof(T)]}")).AsList();*/
            string tableName = GetTableName();
            string query = $"SELECT * FROM {tableName}";
            await using var connection = new SqlConnection(_connectionString);
            var result = await connection.QueryAsync<T>(query);
            return result.ToList();
        }

        public async Task<T> InsertAsync(T entity)
        {
            /*var columns = "";
            var values = "";
            var props = new List<PropertyInfo>(entity.GetType().GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if (!prop.Name.Contains("ID")) 
                {
                    var value = prop.GetValue(entity, null);
                    columns += prop.Name + ", ";
                    values += prop.GetType() == typeof(string) || prop.GetType() == typeof(DateTime) ? $"'{value}', " : $"{value}, ";
                }
            }
            columns = columns.Substring(0, columns.Length - 2);
            values = values.Substring(0, columns.Length - 2);
            await using var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO dbo.{tableNames[nameof(T)]} {columns} VALUES ({values})";
            await connection.ExecuteAsync(query);
            return entity;*/
            string tableName = GetTableName();
            string columns = GetColumns(excludeKey: true);
            string properties = GetPropertyNames(excludeKey: true);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(query, entity);
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            /*var set = "";
            var props = new List<PropertyInfo>(entity.GetType().GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if (!prop.Name.Contains("ID"))
                {
                    var value = prop.GetType() == typeof(string) || prop.GetType() == typeof(DateTime) ? $"'{prop.GetValue(entity, null)}', " : $"{prop.GetValue(entity, null)}";
                    set += $"{prop.Name} = {value}, ";
                }
            }
            set = set.Substring(0, set.Length - 2);
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"UPDATE dbo.TodoItems SET {set} WHERE Id = '{id}'");
            return entity;*/
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
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(query.ToString(), entity);
            return entity;
        }
        private string GetColumns(bool excludeKey = false)
        {
            var type = typeof(T);
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttr != null ? columnAttr.Name : p.Name;
                }));

            return columns;
        }
        private string GetTableName()
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;
                return tableName;
            }

            return type.Name + "s";
        }
        public static string GetKeyColumnName()
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
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            var values = string.Join(", ", properties.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return values;
        }
        protected IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return properties;
        }
        protected string GetKeyPropertyName()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (properties.Any())
            {
                return properties.FirstOrDefault().Name;
            }

            return null;
        }
    }
}

