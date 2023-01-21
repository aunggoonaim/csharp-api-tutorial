using csharp_api_tutorial.MongoDB;

namespace csharp_api_tutorial.Dependency.Interface
{
    public interface IPaymentService
    {
        Task<List<PaymentModel>> GetAsync();

        Task<PaymentModel?> GetAsync(string id);

        Task CreateAsync(PaymentModel newBook);

        Task UpdateAsync(string id, PaymentModel updatedBook);

        Task RemoveAsync(string id);
    }
}