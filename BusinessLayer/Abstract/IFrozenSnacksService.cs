using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFrozenSnacksService : IGenericService<FrozenSnacks>
    {
        public List<FrozenSnacks> GetFrozenSnackID(int id);
        public List<FrozenSnacks> FrozenSnackSearch(string s);
    }
}
