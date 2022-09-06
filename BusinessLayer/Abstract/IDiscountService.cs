﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        public List<Discount> GetDiscountID(int id);
        public List<Discount> GetCateDiscountID(int id);
    }
}
