namespace AspNetDependencyInjection.InterfacesExamples
{
    public interface IPromoCodeRepository
    {
        Task<object> GetPromoCodeAsync(string promoCode);
    }
}
