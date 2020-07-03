using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class ProductDAL : IProductDAL
    {
        public BiContext _context;

        public ProductDAL(BiContext context)
        {
            _context = context;
        }
        public Product Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Products.Find(id);
            _context.Products.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IList<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return filter != null ? _context.Products.Where(filter).ToList() : _context.Products.ToList();
        }

        public Product Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}