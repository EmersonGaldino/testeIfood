using ifood.test.galdino.domain.Entity.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ifood.test.galdino.service.Interface.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity> GetOne(int id);
        Task<int> Post(ProductEntity model);
        Task<bool> Put(ProductEntity model);
        Task<bool> Delete(int id);
    }
}
