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
    public class PetFoodService : IPetFoodService
    {
        IPetFoodDal _petFoodDal;

        public PetFoodService(IPetFoodDal petFoodDal)
        {
            _petFoodDal = petFoodDal;
        }

        public void Delete(PetFood t)
        {
            _petFoodDal.Remove(t);
        }

        public PetFood GetById(int id)
        {
            return _petFoodDal.GetByID(id);
        }

        public List<PetFood> GetList()
        {
            return _petFoodDal.GetList();
        }

        public void Insert(PetFood t)
        {
            _petFoodDal.Add(t);
        }

        public void Update(PetFood t)
        {
            _petFoodDal.Update(t);
        }

        public List<PetFood> GetPetFoodID(int id)
        {
            return _petFoodDal.GetListByFilter(x=>x.ID==id);
        }

        public List<PetFood> PetFoodSearch(string s)
        {
            return _petFoodDal.GetListByFilter(x => x.Name.Contains(s));
        }
    }
}
