using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOD.AuthLibrary.Models;

namespace MOD.AuthLibrary.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        MODContext context;
        public AdminRepository(MODContext context)
        {
            this.context = context;
        }
        public bool AddSkill(Skill model)
        {
            return true;
        }

        public bool BlockUser(MODUser user)
        {
            try
            {

                context.MODUsers.Update(user);
                int result = context.SaveChanges();
                if (result > 0) //result>0 since result has no.of records updated
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUser(MODUser user)
        {
            try
            {
                context.MODUsers.Remove(user);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<MODUser> GetMentors()
        {
            var mentors = from a in context.MODUsers
                          join ma in context.UserRoles on a.Id equals ma.UserId
                          where ma.RoleId == "2"
                          select a;
            return mentors;
        }

        public IEnumerable<MODUser> GetStudents()
        {
            var stud = from a in context.MODUsers
                       join ma in context.UserRoles on a.Id equals ma.UserId
                       where ma.RoleId == "3"
                       select a;
            return stud;
        }

        public MODUser GetUser(string id)
        {
            return context.MODUsers.Find(id);
        }

        public bool UnblockUser(MODUser user)
        {
            try
            {

                context.MODUsers.Update(user);
                int result = context.SaveChanges();
                if (result > 0) //result>0 since result has no.of records updated
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool AddTechnology(Technology tech)
        {
            try
            {
                var technology = new Technology
                {
                    TechnologyName = tech.TechnologyName,
                    Commission = tech.Commission,
                };
                context.Technologies.Add(technology);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public bool DeleteTechnology(Technology id)
        {
            try
            {
                context.Technologies.Remove(id);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


       public IEnumerable<Technology> GetTechnologies()
        {
            return this.context.Technologies.Select(c => new Technology
            {
                Id = c.Id,
                TechnologyName = c.TechnologyName,
                Commission = c.Commission
            });
        }


        public bool UpdateTechnology(Technology technology)
        {
            try
            {
                context.Technologies.Update(technology);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Technology GetTechnology(int id)
        {
            return context.Technologies.Find(id);
        }
                


        public MODUser GetMentor(string mentormail)
        {            
                var mentor = (from a in context.MODUsers
                              where a.Email == mentormail
                              select a).First();
                return mentor;            
        }

        public bool AddCourse(Course crs)
        {
            try
            {
                var course = new Course
                {
                    TechnologyId = crs.TechnologyId,
                    MentorId = crs.MentorId,
                    TechnologyName = crs.TechnologyName,
                    Commission = crs.Commission,
                    StartDate = crs.StartDate,
                    EndDate = crs.EndDate,
                    CourseFee = crs.CourseFee
                };
                context.Courses.Add(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<Course> GetCourseList(string id)
        {
            var course = from a in context.Courses
                         where a.MentorId == id && a.EndDate >= DateTime.Today
                         select a;
            return course;
        }

        public IEnumerable<Course> GetCompletedCourseList(string id)
        {
            var course = from a in context.Courses
                         where a.MentorId == id && a.EndDate <= DateTime.Today
                         select a;
            return course;
        }
    }
}
