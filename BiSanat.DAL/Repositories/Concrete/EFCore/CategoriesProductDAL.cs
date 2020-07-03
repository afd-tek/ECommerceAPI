using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class CategoriesProductDAL : ICategoriesProductDAL
    {
        public BiContext _context;

        public CategoriesProductDAL(BiContext context)
        {
            _context = context;
        }
        public CategoriesProduct Add(CategoriesProduct entity)
        {
            _context.CategoriesProducts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            _context.Categories.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public CategoriesProduct GetById(int id)
        {
            return _context.CategoriesProducts.Find(id);
        }

        public IList<CategoriesProduct> GetList(Expression<Func<CategoriesProduct, bool>> filter = null)
        {
            return filter != null ? _context.CategoriesProducts.Where(filter).ToList() : _context.CategoriesProducts.ToList();
        }

        public CategoriesProduct Update(CategoriesProduct entity)
        {
            _context.CategoriesProducts.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}