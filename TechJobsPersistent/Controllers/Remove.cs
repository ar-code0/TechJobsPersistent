using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;

namespace TechJobsPersistent.Controllers
{
    public class Remove : Controller
    {
        JobDbContext context;

        public Remove(JobDbContext context)
        {
            this.context = context;
        }

        public IActionResult Job(int id)
        {

            context.Jobs.Remove(context.Jobs.Find(id));
            context.SaveChanges();
            return Redirect("/Home");
        }
        public IActionResult Employer(int id)
        {

            context.Employers.Remove(context.Employers.Find(id));
            context.SaveChanges();
            return Redirect("/Employer");
        }

        public IActionResult Skill(int id)
        {

            context.Skills.Remove(context.Skills.Find(id));
            context.SaveChanges();
            return Redirect("/Skill");
        }

    }
}
