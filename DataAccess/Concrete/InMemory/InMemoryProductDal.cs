using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {  ProductId=1,CategoryId=1,ProductName="Elma",UnitsInStock=20,UnitPrice=2  },
               new Product {  ProductId=2,CategoryId=2,ProductName="Bilgisayar",UnitsInStock=12,UnitPrice=100  },
               new Product {  ProductId=3,CategoryId=1,ProductName="Kavun",UnitsInStock=32,UnitPrice=3  },
               new Product {  ProductId=4,CategoryId=1,ProductName="Havuc",UnitsInStock=43,UnitPrice=4  }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //direkt olarak product'ı verirsek silemeyiz çünkü bellekte aynı product nesnesini işaret etmesi gerekmekte.
            //var result = _products.Find(x => x.ProductId == product.ProductId);
            Product result = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(result);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(x => x.CategoryId == categoryId).ToList();

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product result = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            result.CategoryId = product.CategoryId;
            result.ProductName = product.ProductName;
            result.UnitsInStock = product.UnitsInStock;
            result.UnitPrice = product.UnitPrice;  
        }
    }
}
