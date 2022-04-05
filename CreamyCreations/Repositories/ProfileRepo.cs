using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Models;
using Microsoft.AspNetCore.Mvc;
using CreamyCreations.ViewModels;

namespace CreamyCreations.Repositories
{
    public class ProfileRepo
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UpdateProfile(UserProfileVM currtUser)
        {
            var currentUser = _context.Users.FirstOrDefault(user => user.UserId == currtUser.UserId);
            currentUser.Email = currtUser.Email;
            currentUser.FirstName = currtUser.FirstName;
            currentUser.LastName = currtUser.LastName;
            _context.SaveChanges();
            return true;
        }
    }
}
