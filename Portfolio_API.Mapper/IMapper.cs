namespace Portfolio_API.Mapper
{
    public interface IMapper<TSource, TDestinationRead, TDestinationCreate>
    {
        TDestinationRead MapToDto(TSource source);
        TSource MapToEntity(TDestinationCreate destination);
        // void UpdateEntity(TSource entity, TDestinationUpdate destination);
    }

}
