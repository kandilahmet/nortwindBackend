using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int Id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == Id));
        }

        //public IResult CheckSumCategoryFromParameterValue(int value)
        //{
        //    if (GetAll().Data.Count > value)
        //    {
        //        return new ErrorResult(Messages.CategoryCountOverValue);
        //    }
        //    else
        //    {
        //        return new SuccessResult();
        //    }
        //}
    }
}
