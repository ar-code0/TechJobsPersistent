using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {

        JobDbContext context;

        public EmployerController(JobDbContext context)
        {
            this.context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> theEmployers = context.Employers.ToList();
            return View(theEmployers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel viewModel = new AddEmployerViewModel();
            return View(viewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (context.Employers.Where(x => x.Name == viewModel.Name).ToList().Count == 0)
                {
                    Employer theEmployer = new Employer
                    {
                        Name = viewModel.Name,
                        Location = viewModel.Location
                    };
                    context.Employers.Add(theEmployer);
                    context.SaveChanges();
                }
                return Redirect("Index");
            }
            return View("Add", viewModel);
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = context.Employers.Find(id);
            return View("About", theEmployer);
        }
    }
}
