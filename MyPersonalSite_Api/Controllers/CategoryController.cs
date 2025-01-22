using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSite_Api.DAL.ApiContext;
using MyPersonalSite_Api.DAL.Entity;

namespace MyPersonalSite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetAction(int id) 
       
        {
            using  var c = new Context();
            var values=c.Categories.Find(id);
            if (values != null) 
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            using var c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Created("", category);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var values = c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category category)
        {
            using var c = new Context();
            var values = c.Find<Category>(category.CategoryId);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.CategoryName = category.CategoryName;
                c.Update(values);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
