using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBeeftService : IGenericService<Meat>
    {
        public List<Meat> GetBeefID(int id);
        public List<Meat> BeefSearch(string s);
    }
}
