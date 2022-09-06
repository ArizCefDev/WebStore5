using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICerealService : IGenericService<Cereal>
    {
        public List<Cereal> GetCerealID(int id);
        public List<Cereal> CerealSearch(string s);
    }
}
