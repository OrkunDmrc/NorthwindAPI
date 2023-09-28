using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Employees")]
    public class Employee : IEntity
    {

    }
}
