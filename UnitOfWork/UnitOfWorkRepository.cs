using NTT_Data.Data;
using NTT_Data.Interfaces;
using NTT_Data.Repositories;


namespace NTT_Data.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public ICustomersRepository CustomersRepository { get; private set; }
        public IProductsRepository ProductsRepository { get; private set; }
        public ISalesRepository SalesRepository { get; private set; }

        private readonly NTTDataContext _NTTDataContext;

        public UnitOfWorkRepository(NTTDataContext NTTDataContext)
        {
            _NTTDataContext = NTTDataContext;
            CustomersRepository = new CustomerRepository(NTTDataContext);
            ProductsRepository = new ProductRepository(NTTDataContext);
            SalesRepository = new SaleRepository(NTTDataContext);
        }

        public async Task CompleteAsync()
        {
            await _NTTDataContext.SaveChangesAsync();
        }
    }
}
