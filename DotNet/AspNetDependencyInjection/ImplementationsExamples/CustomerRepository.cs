using AspNetDependencyInjection.InterfacesExamples;

namespace AspNetDependencyInjection.ImplementationsExamples
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<object> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
