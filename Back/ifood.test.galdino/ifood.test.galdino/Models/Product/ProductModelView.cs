using ifood.test.galdino.api.Models.Base;
using ifood.test.galdino.domain.Entity.Product;

namespace ifood.test.galdino.api.Models.Product
{
    public class ProductModelView : IModelView<ProductEntity>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
    }
}
