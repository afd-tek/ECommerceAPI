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
    public class OrderLineItemsController : ControllerBase, IEntityController<OrderLineItem>
    {
        private readonly IOrderLineItemDAL _OrderLineItemDal;

        public OrderLineItemsController(IOrderLineItemDAL OrderLineItemDal)
        {
            _OrderLineItemDal = OrderLineItemDal;
        }

        [HttpPost]
        public IActionResult Add(OrderLineItem entity)
        {
            OrderLineItem added = _OrderLineItemDal.Add(entity);
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
            OrderLineItem single = _OrderLineItemDal.GetById(id);
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
        public IActionResult Update(OrderLineItem entity)
        {
            OrderLineItem updated = _OrderLineItemDal.Update(entity);
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
            IList<OrderLineItem> list = _OrderLineItemDal.GetList();
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
            bool result = _OrderLineItemDal.Delete(id);
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
        public IActionResult GetFiltered(OrderLineItem spec)
        {
            var query = _OrderLineItemDal.GetList();
            if (query != null)
            {
                if (spec.OrderId > 0)
                {
                    query = query.Where(x => x.OrderId == spec.OrderId).ToList();
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

        [HttpPost("bulk")]
        public IActionResult BulkInsert(List<OrderLineItem> items)
        {
            var res = _OrderLineItemDal.BulkInsert(items);
            if (res != null && res.Count == items.Count)
            {
                foreach (OrderLineItem i in res)
                {
                    if (i == null || i.Id <= 0)
                    {
                        return BadRequest("İşlem başarısız!");
                    }
                }

                return Ok(res);
            }
            return BadRequest("İşlem başarısız!");
        }
    }
}