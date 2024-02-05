using AspNetDependencyInjection.InterfacesExamples;

namespace AspNetDependencyInjection.ImplementationsExamples
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        public Task<object> GetPromoCodeAsync(string promoCode)
        {
            throw new NotImplementedException();
        }
    }
}
