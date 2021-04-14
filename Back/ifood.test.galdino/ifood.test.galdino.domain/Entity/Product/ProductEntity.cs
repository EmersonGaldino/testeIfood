using ifood.test.galdino.domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ifood.test.galdino.domain.Entity.Product
{
    [Table("Product")]
    public class ProductEntity : BaseEntity
    {
        [Key]
       
        public int id { get; set; }
        public string description { get; set; } 
        public string image { get; set; }
        public decimal value { get; set; }
    }
}
