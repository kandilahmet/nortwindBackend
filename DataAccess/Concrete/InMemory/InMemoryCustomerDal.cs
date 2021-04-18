using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    class InMemoryCustomerDal : ICustomerDal
    {
        List<Customer> _customer;
        public InMemoryCustomerDal()
        {
            _customer = new List<Customer>
            {
                new Customer{CustomerId="1",CompanyName="A",ContactName="Ahmet",City="İstanbul" },
                new Customer{CustomerId="2",CompanyName="B",ContactName="Mehmet",City="Ankara" },
                new Customer{CustomerId="3",CompanyName="A",ContactName="Mustafa",City="Isparta" },
                new Customer{CustomerId="4",CompanyName="C",ContactName="Kemal",City="Samsun" },
            };
        }
        public void Add(Customer entity)
        {
            _customer.Add(entity);
        }

        public void Delete(Customer entity)
        {
            var result = _customer.SingleOrDefault(x => x.CustomerId == entity.CustomerId);
            _customer.Remove(result);
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            var result = _customer.SingleOrDefault(x => x.CustomerId == entity.CustomerId);
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.City = entity.City;
        }
    }
}
