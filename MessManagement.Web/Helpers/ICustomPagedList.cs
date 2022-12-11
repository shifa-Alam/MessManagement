

namespace MessManagement.Web.Helpers
{
    public interface ICustomPagedList<TEntity> where TEntity : class
    {
        int Count { get; set; }
        int FirstItemOnPage { get; set; }
        bool HasNextPage { get; set; }
        bool HasPreviousPage { get; set; }
        bool IsFirstPage { get; set; }
        bool IsLastPage { get; set; }
        int LastItemOnPage { get; set; }
        int PageCount { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
        IEnumerable<TEntity> Subset { get; set; }
    }
}