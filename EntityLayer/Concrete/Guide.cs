using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Guide
    {
        [Key]
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Work { get; set; }
        public string FacebookURL { get; set; }
        public string InstagramURL { get; set; }
        public string WhatsappURL { get; set; }
        public bool Status { get; set; }
    }
}
