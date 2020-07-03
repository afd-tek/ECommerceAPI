using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class CommentDAL : ICommentDAL
    {
        public BiContext _context;

        public CommentDAL(BiContext context)
        {
            _context = context;
        }
        public Comment Add(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Comments.Find(id);
            _context.Comments.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public IList<Comment> GetList(Expression<Func<Comment, bool>> filter = null)
        {
            return filter != null ? _context.Comments.Where(filter).ToList() : _context.Comments.ToList();
        }

        public Comment Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}