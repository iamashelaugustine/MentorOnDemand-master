using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // DELETE: api/Admin/66
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

        //BLOCK: api/Admin/block/{id}
        [HttpPut("block/{id}")]
        public IActionResult BlockUser(string id)
        {
            var user = repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            if (id == user.Id)
            {
                user.Status = "blocked";
                bool result = repository.BlockUser(user);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NotFound();
        }

        //BLOCK: api/Admin/unblock/{id}
        [HttpPut("unblock/{id}")]
        public IActionResult UnblockUser(string id)
        {
            var user = repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            if (id == user.Id)
            {
                user.Status = "active";
                bool result = repository.UnblockUser(user);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NotFound();
        }


        [Route("technologylist")]
        [HttpGet]
        public IActionResult GetTechnologies()
        {
            var technologies = repository.GetTechnologies();
            if (!technologies.Any())
            {
                return NoContent();
            }
            return Ok(technologies);
        }


        // POST: api/Admin
        [Route("addtechnology")]
        [HttpPost]

        public IActionResult Post([FromBody] Technology technology)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddTechnology(technology);
                if (result)
                {
                    return Created("AddTechnology", technology.Id);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }


        // GET: api/Admin/5
        [HttpGet("technology/{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var technologies = repository.GetTechnology(id);
            if (technologies == null)
            {
                return NotFound();
            }
            return Ok(technologies);
        }


        // PUT: api/Technology/5
        [HttpPut("updatetechnology/{id}")]
        public IActionResult Put(int id, [FromBody] Technology technology)
        {
            if (ModelState.IsValid && id == technology.Id)
            {
                bool result = repository.UpdateTechnology(technology);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("technology/{id}")]
        public IActionResult DeleteTechnology(int id)
        {
            var technology = repository.GetTechnology(id);
            if (technology == null)
            {
                return NotFound();
            }
            bool result = repository.DeleteTechnology(technology);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        // GET: api/Admin/5
        [HttpGet("getmentor/{mentormail}")]
        public IActionResult GetMentor(string mentormail)
        {
            var mentor = repository.GetMentor(mentormail);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        // POST: api/Admin/addcourse
        [Route("addcourse")]
        [HttpPost]

        public IActionResult Post([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddCourse(course);
                if (result)
                {
                    return Created("AddCourse", course.Id);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }


        [Route("courselist/{id}")]
        [HttpGet]
        public IActionResult GetCourseList(string id)
        {
            var courses = repository.GetCourseList(id);
            if (!courses.Any())
            {
                return NoContent();
            }
            return Ok(courses);
        }


        [Route("completedcourselist/{id}")]
        [HttpGet]
        public IActionResult GetCompletedCourseList(string id)
        {
            var courses = repository.GetCompletedCourseList(id);
            if (!courses.Any())
            {
                return NoContent();
            }
            return Ok(courses);
        }

        [Route("courses")]
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = repository.GetCourses();
            if (!courses.Any())
            {
                return NoContent();
            }
            return Ok(courses);
        }


        // POST: api/Admin/addcourse
        [Route("mentorupdateprofile")]
        [HttpPost]

        public IActionResult UpdateProfile([FromBody] Mentorprofile profile)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.UpdateProfile(profile);
                if (result)
                {
                    return Created("UpdateProfile", profile.Id);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }


        // GET: api/Admin/5
        [HttpGet("getmentorprofile/{id}")]
        public IActionResult GetMentorProfile(string id)
        {
            var mentor = repository.GetMentorProfile(id);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        // GET: api/Admin/5
        [HttpGet("getuserid/{usermail}")]
        public IActionResult GetUserByMail(string usermail)
        {
            var user = repository.GetUserByMail(usermail);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        // POST: api/Admin
        [Route("addtraining")]
        [HttpPost]

        public IActionResult Post([FromBody] Training training)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddTraining(training);
                if (result)
                {
                    return Created("AddTraining", training.Id);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }

        [Route("traininglist/{id}")]
        [HttpGet]
        public IActionResult GetTrainingList(string id)
        {
            var trainings = repository.GetTrainingList(id);
            if (!trainings.Any())
            {
                return NoContent();
            }
            return Ok(trainings);
        }


        [Route("completedtraininglist/{id}")]
        [HttpGet]
        public IActionResult GetCompletedTrainingList(string id)
        {
            var trainings = repository.GetCompletedTrainingList(id);
            if (!trainings.Any())
            {
                return NoContent();
            }
            return Ok(trainings);
        }
    }
}