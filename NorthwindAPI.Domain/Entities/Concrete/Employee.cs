using NorthwindAPI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NorthwindAPI.Domain.Entities.Concrete
{
    [Table("Employees")]
    public class Employee : IEntity
    {

    }
}
