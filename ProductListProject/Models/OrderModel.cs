using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductListProject.Models
{
    public class OrderModel
    {

        public OrderModel()
        {
            ordered_model = new HashSet<OrderedModel>();
        }
        [Key]
        public int order_id { get; set; }

        [MaxLength(15, ErrorMessage = "Este campo deve conter entre 3 a 15 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 15 caracteres")]

        public string order_cname { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Este campo deve ser maior que 1")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double order_value { get; set; }

        [NotMapped]
        public ICollection<int> products { get; set; }

        public ICollection<OrderedModel> ordered_model { get; set; }

    }
}
