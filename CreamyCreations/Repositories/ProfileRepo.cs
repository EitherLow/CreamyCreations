using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreamyCreations.Repositories
{
    public class ProfileRepo
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UpdateProfile(User user, int userId)
        {
            var currentUser = _context.Users.FirstOrDefault(user => user.UserId == userId);
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            _context.SaveChanges();
            return true;
        }
    }
}
