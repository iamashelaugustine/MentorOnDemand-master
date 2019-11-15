using System;
using System.Collections.Generic;
using System.Text;
using MOD.AuthLibrary.Models;

namespace MOD.AuthLibrary.Repositories
{
    public interface IAdminRepository
    {
        bool AddSkill(Skill model);

        public IEnumerable<MODUser> GetStudents();

        public IEnumerable<MODUser> GetMentors();
        MODUser GetUser(string id);
        bool DeleteUser(MODUser user);
    }
}
