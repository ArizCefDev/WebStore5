using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public List<Category> GetCategorieID(int id);
        public List<Category> CategorySearch(string s);
    }
}
