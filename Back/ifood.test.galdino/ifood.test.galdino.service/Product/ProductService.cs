using ifood.test.galdino.domain.Entity.Product;
using ifood.test.galdino.repository.Interface.Product;
using ifood.test.galdino.service.Interface.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ifood.test.galdino.service.Product
{
    public class ProductService : IProductService
    {
        #region .::Constructor
        private readonly IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region .::Methods
        public async Task<IEnumerable<ProductEntity>> GetAll() => await repository.GetAll();
        public async Task<ProductEntity> GetOne(int id) => await repository.GetOne(id);
        public async Task<int> Post(ProductEntity model) => await repository.Post(model);
        public async Task<bool> Put(ProductEntity model) => await repository.Put(model);
        public async Task<bool> Delete(int id) => await repository.Delete(id); 
        #endregion

    }
}
