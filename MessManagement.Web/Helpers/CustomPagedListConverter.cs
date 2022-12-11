
using AutoMapper;


namespace MessManagement.Web.Helpers
{
    public class CustomPagedListConverter<TSource, TDestination> : ITypeConverter<ICustomPagedList<TSource>, ICustomPagedList<TDestination>>
        where TSource : class where TDestination : class
    {
        public ICustomPagedList<TDestination> Convert(ICustomPagedList<TSource> source,
            ICustomPagedList<TDestination> destination, ResolutionContext context)
        {
            try
            {
                if (source == null) return null;
                if (context == null) return null;

                var customPagedList = context.Mapper.Map<CustomPagedList<TSource>, CustomPagedList<TDestination>>((CustomPagedList<TSource>)source);

                return customPagedList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}