using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Poster
    {
        [Key]
        public int ID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Details3 { get; set; }
        public bool Status { get; set; }
    }
}
