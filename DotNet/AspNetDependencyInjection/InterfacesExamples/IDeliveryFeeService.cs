namespace AspNetDependencyInjection.InterfacesExamples
{
    public interface IDeliveryFeeService
    {
        Task<decimal> GetDeliveryFeeAsync(string zipCode);
    }
}
