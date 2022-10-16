namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.TypeHelper
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
