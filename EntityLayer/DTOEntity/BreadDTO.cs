using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOEntity
{
    public class BreadDTO
    {
        [Key]
        public int ID { get; set; }
        public IFormFile ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Kilogram { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
