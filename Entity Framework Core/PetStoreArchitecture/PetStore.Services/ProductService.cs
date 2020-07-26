using PetStore.Data;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetStoreDbContext dbContext;
        public ProductService(PetStoreDbContext context)
        {
            this.dbContext = context;
        }

        public void AddProduct()
        {

        }
    }
}
