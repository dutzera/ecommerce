using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductListProject.Models
{
    public class OrderedModel
    { 
        [Key]
        public int ordered_id { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório")]
        public int fk_order_id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int fk_product_id { get; set; }

        [JsonIgnore]
        [ForeignKey("fk_order_id")]
        public OrderModel order_model { get; set; }

        [JsonIgnore]
        [ForeignKey("fk_product_id")]
        public ProductModel product_model { get; set; }
    }
}
