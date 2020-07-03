using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class OrderLineItemDAL : IOrderLineItemDAL
    {
        public BiContext _context;

        public OrderLineItemDAL(BiContext context)
        {
            _context = context;
        }
        public OrderLineItem Add(OrderLineItem entity)
        {
            _context.OrderLineItems.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.OrderLineItems.Find(id);
            _context.OrderLineItems.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public OrderLineItem GetById(int id)
        {
            return _context.OrderLineItems.Find(id);
        }

        public IList<OrderLineItem> GetList(Expression<Func<OrderLineItem, bool>> filter = null)
        {
            return filter != null ? _context.OrderLineItems.Where(filter).ToList() : _context.OrderLineItems.ToList();
        }

        public OrderLineItem Update(OrderLineItem entity)
        {
            _context.OrderLineItems.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<OrderLineItem> BulkInsert(List<OrderLineItem> items)
        {
            _context.OrderLineItems.AddRange(items);
            _context.SaveChanges();
            return items;
        }
    }
}