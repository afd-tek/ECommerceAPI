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
    public class PeopleController : ControllerBase, IEntityController<Person>
    {
        private readonly IPersonDAL _PersonDal;

        public PeopleController(IPersonDAL PersonDal)
        {
            _PersonDal = PersonDal;
        }

        [HttpPost]
        public IActionResult Add(Person entity)
        {
            Person added = _PersonDal.Add(entity);
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
            Person single = _PersonDal.GetById(id);
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
        public IActionResult Update(Person entity)
        {
            Person updated = _PersonDal.Update(entity);
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
            IList<Person> list = _PersonDal.GetList();
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
            bool result = _PersonDal.Delete(id);
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
        public IActionResult GetFiltered(Person spec)
        {
            var query = _PersonDal.GetList();
            if (query != null)
            {
                if (!string.IsNullOrEmpty(spec.FullName))
                {
                    query = query.Where(x => x.FullName.ToLower().Contains(spec.FullName.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(spec.Phone))
                {
                    query = query.Where(x => x.Phone.ToLower().Contains(spec.Phone.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(spec.Email))
                {
                    query = query.Where(x => x.Email == spec.Email).ToList();
                }
                if (!string.IsNullOrEmpty(spec.Password))
                {
                    query = query.Where(x => x.Password.ToLower().Contains(spec.Password.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(spec.DeviceToken))
                {
                    query = query.Where(x => x.DeviceToken.ToLower().Contains(spec.DeviceToken.ToLower())).ToList();
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