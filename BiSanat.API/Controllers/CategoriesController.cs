using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiSanat.API.Controllers.Generic;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiSanat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase , IEntityController<Category>
    {
        private readonly ICategoryDAL _CategoryDal;

        public CategoriesController(ICategoryDAL CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }

        [HttpPost]
        public IActionResult Add(Category entity)
        {
            Category added = _CategoryDal.Add(entity);
            if (added != null && added.Id > 0)
            {
                return Ok(added);
            }
            else
            {
                return BadRequest("Ekleme işlemi başarısız oldu!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category single = _CategoryDal.GetById(id);
            if (single != null && single.Id > 0)
            {
                return Ok(single);
            }
            else
            {
                return NotFound("Aradığınız kayıt bulunamadı!");
            }
        }


        [HttpPut]
        public IActionResult Update(Category entity)
        {
            Category updated = _CategoryDal.Update(entity);
            if (updated != null && updated.Id > 0)
            {
                return Ok(updated);
            }
            else
            {
                return BadRequest("Güncelleme işlemi başarısız!");
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IList<Category> list = _CategoryDal.GetList();
            if (list != null && list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound("Burada hiç kayıt bulunmadı!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            bool result = _CategoryDal.Delete(id);
            if (result)
            {
                return Ok("Silme işlemi başarılı!");
            }
            else
            {
                return BadRequest("Güncelleme işlemi başarısız!");
            }
        }

        [HttpPost("filter")]
        public IActionResult GetFiltered(Category spec)
        {
            var query = _CategoryDal.GetList();
            if (query != null)
            {
                if (spec.PersonId > 0)
                {
                    query = query.Where(x => x.PersonId == spec.PersonId).ToList();
                }
                if (!string.IsNullOrEmpty(spec.Name))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(spec.Name.ToLower())).ToList();
                }
                if (query.Count == 0)
                {
                    return NotFound("Aradığınız kriterlere uygun sonuç bulunmadı!");
                }
            }

            return Ok(query);
        }

    }
}