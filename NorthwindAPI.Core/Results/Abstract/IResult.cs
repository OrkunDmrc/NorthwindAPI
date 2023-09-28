
namespace NorthwindAPI.Core.Results.Abstract
{
    public interface IResult<T> where T : class
    {
        T? Object { get; set; }
        string? ErrorMessage { get; set; }
        bool Success { get; set; }
    }
}
