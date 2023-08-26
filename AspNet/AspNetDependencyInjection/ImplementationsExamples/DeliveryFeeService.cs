using AspNetDependencyInjection.InterfacesExamples;

namespace AspNetDependencyInjection.ImplementationsExamples
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        public Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}
