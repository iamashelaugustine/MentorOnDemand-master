using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.AuthLibrary.Models;
using MOD.AuthLibrary.Repositories;

namespace MOD.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [Route("mentorlist")]
        [HttpGet]
        public IActionResult GetMentors()
        {
            var mentors = repository.GetMentors();
            if (!mentors.Any())
            {
                return NoContent();
            }
            return Ok(mentors);
        }


        [Route("studentlist")]
        [HttpGet]
        public IActionResult GetStudents()
        {
            var stud = repository.GetStudents();
            if (!stud.Any())
            {
                return NoContent();
            }
            return Ok(stud);
        }


        // GET: api/Admin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] Skill model)
        {
            if (ModelState.IsValid)
            {
                repository.AddSkill(model);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            bool result = repository.DeleteUser(user);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
