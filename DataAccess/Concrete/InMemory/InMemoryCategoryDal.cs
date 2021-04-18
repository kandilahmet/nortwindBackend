using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Yiyecek"},
                new Category{CategoryId=2,CategoryName="Elektronik"},
                new Category{CategoryId=3,CategoryName="Giyecek"},
            };
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            var result = _categories.SingleOrDefault(x => x.CategoryId == category.CategoryId);
            _categories.Remove(result);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            var result = _categories.SingleOrDefault(x => x.CategoryId == category.CategoryId);
            result.CategoryName = category.CategoryName;
        }
    }
}
