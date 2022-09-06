using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Delete(Category t)
        {
            _categoryDal.Remove(t);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList();  
        }

        public void Insert(Category t)
        {
            _categoryDal.Add(t);
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<Category> GetCategorieID(int id)
        {
            return _categoryDal.GetListByFilter(x=>x.ID==id);
        }

        public List<Category> CategorySearch(string s)
        {
            return _categoryDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
