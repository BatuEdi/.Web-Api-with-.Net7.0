using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        
        public string? ProductDetail { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ProductPrice { get; set; }
        public DateTime ProductCreateDate { get; set; } = DateTime.Now;
        public DateTime ProductUpdateDate { get; set; }
    }
}
