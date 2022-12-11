//https://stackoverflow.com/questions/2070850/can-automapper-map-a-paged-list


using AutoMapper;
using X.PagedList;

namespace MessManagement.Web.Helpers
{
    public class PagedListConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>,
        ICustomPagedList<TDestination>> where TSource : class where TDestination : class
    {
        public ICustomPagedList<TDestination> Convert(IPagedList<TSource> source,
            ICustomPagedList<TDestination> destination, ResolutionContext context)
        {
            try
            {
                if (source == null) return null;
                if (context == null) return null;

                var customPagedList = context.Mapper.Map<PagedList<TSource>, CustomPagedList<TDestination>>((PagedList<TSource>)source);
                customPagedList.Subset = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);

                return customPagedList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}