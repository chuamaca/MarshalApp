namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.PropertyMapping
{
    public interface IPropertyMappingService<TSource, TDestination>
    {
        bool ValidMappingExistsFor(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping();
    }
}
