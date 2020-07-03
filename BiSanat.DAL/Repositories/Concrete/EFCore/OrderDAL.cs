using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class OrderDAL : IOrderDAL
    {
        public BiContext _context;

        public OrderDAL(BiContext context)
        {
            _context = context;
        }
        public Order Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Orders.Find(id);
            _context.Orders.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Order GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public IList<Order> GetList(Expression<Func<Order, bool>> filter = null)
        {
            return filter != null ? _context.Orders.Where(filter).ToList() : _context.Orders.ToList();
        }

        public Order Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}