
using csharp_api_tutorial.Dependency.Interface;
using csharp_api_tutorial.MongoDB;
using MongoDB.Driver;

namespace csharp_api_tutorial.Dependency.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IMongoCollection<PaymentModel> _paymentCollection;

        public PaymentService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDB"];
            var mongoClient = new MongoClient(connectionString);
            var mongoDatabase = mongoClient.GetDatabase("tutorial");
            _paymentCollection = mongoDatabase.GetCollection<PaymentModel>("payment");
        }

        public async Task<List<PaymentModel>> GetAsync() =>
        await _paymentCollection.Find(_ => true).ToListAsync();

        public async Task<PaymentModel?> GetAsync(string id) =>
            await _paymentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PaymentModel newBook) =>
            await _paymentCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, PaymentModel updatedBook) =>
            await _paymentCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _paymentCollection.DeleteOneAsync(x => x.Id == id);
    }
}