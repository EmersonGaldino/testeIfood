using System;

namespace ifood.test.galdino.domain.Entity.Base
{
    public class BaseEntity
    {
        public DateTime datecreate { get; set; } = DateTime.Now;
        public DateTime? dateupdate { get; set; }
        public bool active { get; set; } = true;
    }
}
