namespace MM.Core.Models.FilterModel
{
    public class BaseFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public BaseFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public BaseFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }
    }
}
