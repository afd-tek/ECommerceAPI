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
    public class CommentsController : ControllerBase, IEntityController<Comment>
    {
        private readonly ICommentDAL _CommentDal;

        public CommentsController(ICommentDAL CommentDal)
        {
            _CommentDal = CommentDal;
        }

        [HttpPost]
        public IActionResult Add(Comment entity)
        {
            Comment added = _CommentDal.Add(entity);
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
            Comment single = _CommentDal.GetById(id);
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
        public IActionResult Update(Comment entity)
        {
            Comment updated = _CommentDal.Update(entity);
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
            IList<Comment> list = _CommentDal.GetList();
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
            bool result = _CommentDal.Delete(id);
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
        public IActionResult GetFiltered(Comment spec)
        {
            var query = _CommentDal.GetList();
            if (query != null)
            {
                if (spec.ProductId > 0)
                {
                    query = query.Where(x => x.ProductId == spec.ProductId).ToList();
                }
                if (spec.PersonId > 0)
                {
                    query = query.Where(x => x.PersonId == spec.PersonId).ToList();
                }
                if (query.Count == 0)
                {
                    return NotFound("AAradığınız kriterlere uygun sonuç bulunmadı!");
                }
            }

            return Ok(query);
        }
    }
}