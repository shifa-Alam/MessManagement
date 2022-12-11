

namespace MessManagement.Web.Helpers
{
    public class CustomPagedList<TEntity> : ICustomPagedList<TEntity> where TEntity : class
    {
        public int Count { get; set; }
        public int FirstItemOnPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int LastItemOnPage { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public IEnumerable<TEntity> Subset { get; set; }
    }
}