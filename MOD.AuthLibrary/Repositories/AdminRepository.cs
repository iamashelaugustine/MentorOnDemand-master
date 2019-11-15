﻿using System;
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
    }
}
