namespace AspNetDependencyInjection.InterfacesExamples
{
    public interface ICustomerRepository
    {
        Task<object> GetCustomerAsync(int id);
    }
}
