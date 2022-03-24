using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalInformation.Models;

namespace PersonalInformation.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonalDbContext _context;

        public PeopleController(PersonalDbContext context)
        {
            _context = context;
        }

   
        public IActionResult Index()
        {
            var list = _context.Personz.ToList();
            return View(list);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var person = await _context.Personz.FindAsync(Id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



     
        
        public async Task<IActionResult> Create(Person person)
        {
            if (person.Id == 0)
            {
                await _context.AddAsync(person);
            }
            else
            {
                _context.Update(person);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Person(int? Id)
        {
            Person person;
            if (Id.HasValue)
            {
                person = _context.Personz.Find(Id);

            }
            else
            {
                person = new Person();
            }
            return View(person);
        }

    }
}

