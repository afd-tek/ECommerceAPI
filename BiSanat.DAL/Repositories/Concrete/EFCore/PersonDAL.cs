using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BiSanat.DAL.Repositories.Concrete.EFCore
{
    public class PersonDAL : IPersonDAL
    {
        public BiContext _context;

        public PersonDAL(BiContext context)
        {
            _context = context;
        }
        public Person Add(Person entity)
        {
            _context.People.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.People.Find(id);
            _context.People.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public Person GetById(int id)
        {
            return _context.People.Find(id);
        }

        public IList<Person> GetList(Expression<Func<Person, bool>> filter = null)
        {
            return filter != null ? _context.People.Where(filter).ToList() : _context.People.ToList();
        }

        public Person Update(Person entity)
        {
            _context.People.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
