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
    public class CategoriesProductsController : ControllerBase, IEntityController<CategoriesProduct>
    {
        private readonly ICategoriesProductDAL _CategoriesProductDal;

        public CategoriesProductsController(ICategoriesProductDAL CategoriesProductDal)
        {
            _CategoriesProductDal = CategoriesProductDal;
        }

        [HttpPost]
        public IActionResult Add(CategoriesProduct entity)
        {
            CategoriesProduct added = _CategoriesProductDal.Add(entity);
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
            CategoriesProduct single = _CategoriesProductDal.GetById(id);
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
        public IActionResult Update(CategoriesProduct entity)
        {
            CategoriesProduct updated = _CategoriesProductDal.Update(entity);
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
            IList<CategoriesProduct> list = _CategoriesProductDal.GetList();
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
            bool result = _CategoriesProductDal.Delete(id);
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
        public IActionResult GetFiltered(CategoriesProduct spec)
        {
            var query = _CategoriesProductDal.GetList();
            if (query != null)
            {
                if (spec.CategoryId > 0)
                {
                    query = query.Where(x => x.CategoryId == spec.CategoryId).ToList();
                }
                if (spec.ProductId > 0)
                {
                    query = query.Where(x => x.ProductId == spec.ProductId).ToList();
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