using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProductListProject.Models;

namespace ProductListProject
{
    public class ProductModel
    {

        public ProductModel()
        {
            //ordered_model = new HashSet<OrderedModel>();
        }
        [Key]
        public int prod_Id { get; set; }

        [MaxLength(15,ErrorMessage = "Este campo deve conter entre 3 a 15 caracteres")]
        [MinLength(3,ErrorMessage ="Este campo deve conter entre 3 a 15 caracteres")]

        public string prod_Name { get; set; }

        [Range(1,int.MaxValue, ErrorMessage ="Este campo deve ser maior que 1")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        public double prod_Price { get; set; }

        public string prod_Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int prod_Amount { get; set; }

        public string prod_Platform { get; set; }
        
        //public ICollection<OrderedModel> ordered_model { get; set; }

    }
}
