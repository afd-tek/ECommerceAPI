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
    public class OrdersController : ControllerBase, IEntityController<Order>
    {
        private readonly IOrderDAL _OrderDal;

        public OrdersController(IOrderDAL OrderDal)
        {
            _OrderDal = OrderDal;
        }

        [HttpPost]
        public IActionResult Add(Order entity)
        {
            Order added = _OrderDal.Add(entity);
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
            Order single = _OrderDal.GetById(id);
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
        public IActionResult Update(Order entity)
        {
            Order updated = _OrderDal.Update(entity);
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
            IList<Order> list = _OrderDal.GetList();
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
            bool result = _OrderDal.Delete(id);
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
        public IActionResult GetFiltered(Order spec)
        {
            var query = _OrderDal.GetList();
            if (query != null)
            {
                if (spec.OrderFrom > 0)
                {
                    query = query.Where(x => x.OrderFrom == spec.OrderFrom).ToList();
                }
                if (spec.OrderTo > 0)
                {
                    query = query.Where(x => x.OrderTo == spec.OrderTo).ToList();
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