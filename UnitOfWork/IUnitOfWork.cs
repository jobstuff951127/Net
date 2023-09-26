using NTT_Data.Interfaces;

namespace NTT_Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomersRepository CustomersRepository { get; }
        IProductsRepository ProductsRepository { get; }
        ISalesRepository SalesRepository { get; }

        Task CompleteAsync();
    }
}