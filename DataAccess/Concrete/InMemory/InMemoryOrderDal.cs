using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public  class InMemoryOrderDal : IOrderDal
    {
        List<Order> _orders;
        public InMemoryOrderDal()
        {
            _orders = new List<Order>
            {
                new Order{CustomerId=1,EmployeeId=1,OrderId=1,OrderDate=DateTime.Now.Date,ShipCity="İstanbul"},
                new Order{CustomerId=3,EmployeeId=1,OrderId=2,OrderDate=DateTime.Now.Date,ShipCity="Ankara"},
                new Order{CustomerId=2,EmployeeId=1,OrderId=3,OrderDate=DateTime.Now.Date,ShipCity="Sanmsun"},
                new Order{CustomerId=1,EmployeeId=1,OrderId=4,OrderDate=DateTime.Now.Date,ShipCity="İstanbul"}
            };
        }
        public void Add(Order entity)
        {
            _orders.Add(entity);
        }

        public void Delete(Order entity)
        {
           var deletedOrder = _orders.SingleOrDefault(x => x.OrderId == entity.OrderId);
            _orders.Remove(deletedOrder);
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return _orders.AsQueryable().SingleOrDefault(filter);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
           return filter==null
                ? _orders.AsQueryable().Where(filter).ToList()
                : _orders;
        }

        public void Update(Order entity)
        {
            var deletedOrder = _orders.SingleOrDefault(x => x.OrderId == entity.OrderId);
            deletedOrder.CustomerId = entity.CustomerId;
            deletedOrder.EmployeeId = entity.EmployeeId;
            deletedOrder.OrderDate = entity.OrderDate;
            deletedOrder.ShipCity = entity.ShipCity;
        }
    }
}
