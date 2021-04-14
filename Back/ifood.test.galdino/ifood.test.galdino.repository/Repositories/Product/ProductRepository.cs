using Dapper;
using Dapper.Contrib.Extensions;
using ifood.test.galdino.domain.Entity.Product;
using ifood.test.galdino.repository.Context;
using ifood.test.galdino.repository.Interface.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ifood.test.galdino.repository.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        #region .::Constructor
        private const string SELECT_QUERY = "SELECT * FROM PRODUCT";

        private readonly DbContext context;
        public ProductRepository(DbContext context)
        {
            this.context = context;
        }
        #endregion

        #region .::Methods

        public async Task<IEnumerable<ProductEntity>> GetAll() =>
            await context.Connection.QueryAsync<ProductEntity>($"{SELECT_QUERY} WHERE Active = @Active ORDER BY id", new { Active = true });

        public async Task<ProductEntity> GetOne(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<ProductEntity>(
                $"{SELECT_QUERY} WHERE Active = @Active AND  id = @id", new { Active = true, id });

        public async Task<int> Post(ProductEntity model) =>
            await context
                .Connection
                .InsertAsync(model);

        public async Task<bool> Delete(int id) => await context.Connection.DeleteAsync(new ProductEntity { id = id });

        public async Task<bool> Put(ProductEntity model) => await context.Connection.UpdateAsync(model); 
        #endregion

    }
}
