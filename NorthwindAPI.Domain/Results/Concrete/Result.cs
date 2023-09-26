using NorthwindAPI.Domain.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Domain.Results.Concrete
{
    public class Result<T> : IResult<T> where T : class
    {
        public T? Object { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
