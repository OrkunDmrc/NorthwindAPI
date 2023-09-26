using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Domain.Results.Abstract
{
    public interface IResult<T> where T : class
    {
        T? Object { get; set; }
        string? ErrorMessage { get; set; }
        bool Success { get; set; }
    }
}
