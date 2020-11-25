using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codeRed_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using codeRed_Capstone.Models.Exceptions;
//using System.ComponentModel.DataAnnotations;

namespace codeRed_Capstone.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly CompanyContext _context;

        public EmployeeController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // GET: Employee/DetailsBySurname/5
        public async Task<IActionResult> DetailsBySurname(string lastName)
        {
            ValidationException exception = new ValidationException();
            lastName = !string.IsNullOrWhiteSpace(lastName) ? lastName.Trim() : null;

            using (CompanyContext context = new CompanyContext())
            {
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    exception.ValidationExceptions.Add(new Exception("Last Name Not Provided"));
                }

                // Category ID fails parse.
                // Common validation points (5) and (5a).
                int n;
                bool isNumeric = int.TryParse(lastName, out n);
                if (isNumeric)
                {
                    exception.ValidationExceptions.Add(new Exception("ID Not Valid string"));
                }
                else
                {
                    // Category ID exists.
                    // Common validation point (7).
                    if (!context.Employees.Any(x => x.LastName == lastName))
                    {
                        exception.ValidationExceptions.Add(new Exception("Last Name Does Not Exist"));
                    }
                }

                if (lastName.Length > 30)
                {
                    // Name too long
                    // Common validation point (3).
                    exception.ValidationExceptions.Add(new Exception("The Maximum Length of a Last Name is 30 Characters"));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

            }

            //if (string.IsNullOrEmpty(lastName))
            //{
            //    ModelState.AddModelError("Last Name is required.");
            //}

            //if (Request.Query.Count > 0)
            //{
            //    try
            //    {

            //        var results = _context.EmployeeDates.Include(x => x.Employee).Where(y => y.Employee.LastName == lastName).ToList();
            //        if(results.Exists)
            //        {
            //            Details(lastName);
            //            //ViewBag.Message = $"Successfully Created Product {name}!";
            //        }

            //    }
            //    // Catch ONLY ValidationException. Any other Exceptions (FormatException, DivideByZeroException, etc) will not get caught, and will break the whole program.
            //    catch (ValidationException e)
            //    {

            //        ViewBag.LastName = lastName;
            //        ViewBag.Message = "There exist problem(s) with your submission, see below.";
            //        ViewBag.Exception = e;
            //        ViewBag.Error = true;
            //    }
            //}

            if (lastName == null)
            {
                return NotFound(new Exception("Last Name not found"));
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.LastName == lastName);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // GET: Employee/DetailsByEmail/5
        public async Task<IActionResult> DetailsByEmail(string email)
        {
            //ValidationException exception = new ValidationException();
            //if (string.IsNullOrEmpty(lastName))
            //{
            //    ModelState.AddModelError("Last Name is required.");
            //}

            if (email == null)
            {
                return NotFound(new Exception("Email not found"));
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Email == email);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create(int ID =0)
        {
            //var model = new Employee();
            //model.ValidationValidFrom = DateTime.Today;
            return View(new Employee());
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,Age,City,Department,HiredDate")] Employee employee)
        {
            //var model = new Employee();
            //model.ValidationValidFrom = DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Phone,Age,City,Department,HiredDate,FiredDate")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
