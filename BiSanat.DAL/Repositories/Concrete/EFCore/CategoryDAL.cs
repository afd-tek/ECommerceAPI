using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class CategoryDAL : ICategoryDAL
    {
        public BiContext _context;

        public CategoryDAL(BiContext context)
        {
            _context = context;
        }
        public Category Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            _context.Categories.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public IList<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return filter != null ? _context.Categories.Where(filter).ToList() : _context.Categories.ToList();
        }

        public Category Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}