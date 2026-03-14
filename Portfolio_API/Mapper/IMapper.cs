namespace Portfolio_API.Mapper
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination MapToDto(TSource source);
        TSource MapToEntity(TDestination destination);
        void UpdateEntity(TSource source, TDestination destination);
    }
}
