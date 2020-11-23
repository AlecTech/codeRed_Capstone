using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codeRed_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        //OrderBy Code borrowed from https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-5.0
        public async Task<IActionResult> Index(string sortOrder)
        {   //Nov20 added viewbag to access Dates later inside views
            ViewBag.Employees = GetDates();
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewData["DepSortParm"] = String.IsNullOrEmpty(sortOrder) ? "dep_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var emps = from s in _context.Employees
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    emps = emps.OrderByDescending(s => s.LastName);
                    break;
                case "email_desc":
                    emps = emps.OrderByDescending(s => s.Email);
                    break;
                case "dep_desc":
                    emps = emps.OrderByDescending(s => s.Department);
                    break;
                default:
                    emps = emps.OrderBy(s => s.LastName);
                    break;
            }
            return View(await emps.AsNoTracking().ToListAsync());
            //return View(await _context.Employees.ToListAsync());
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
            //ValidationException exception = new ValidationException();
            //if (string.IsNullOrEmpty(lastName))
            //{
            //    ModelState.AddModelError("Last Name is required.");
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
        public async Task<IActionResult> DetailsByPhone(string phone)
        {
            //ValidationException exception = new ValidationException();
            //if (string.IsNullOrEmpty(lastName))
            //{
            //    ModelState.AddModelError("Last Name is required.");
            //}

            if (phone == null)
            {
                return NotFound(new Exception("Phone not found"));
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Phone == phone);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create(int ID =0)
        {
            return View(new Employee());
        }
        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Nov20 Changed BIND method to regular data management with explicit declaration due to issue with Write to DB 
        public async Task<IActionResult> Create(string firstName, string lastName, string email, string phone, int age, string city, string department, DateTime HiredDate)
        {
            //Nov20 add 2 objects and append HireDate separately from another Table
            var employee = new Employee { FirstName = firstName, LastName = lastName, Email = email, Phone = phone, Age = age, City = city, Department = department };
            var employeeDate = new EmployeeDate { HiredDate = HiredDate };
            employee.EmployeeDates.Add(employeeDate);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        //NOV 21 
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Phone,Age,City,Department,FiredDate")] Employee employee)
        //public async Task<IActionResult> Edit(int id, string firstName, string lastName, string email, string phone, int age, string city, string department, DateTime firedDate)
        {
            //var employee = new Employee { FirstName = firstName, LastName = lastName, Email = email, Phone = phone, Age = age, City = city, Department = department };
            //var employeeDate = new EmployeeDate { FiredDate = firedDate };
            //employee.EmployeeDates.Add(employeeDate);
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
        //Nov20 Adding List on Dates from foreign Table
        public List<EmployeeDate> GetDates()
        {
            List<EmployeeDate> results;
            using (CompanyContext context = new CompanyContext())
            {
                //results = _context.Books.Include(x => x.Author).Include(x => x.Borrows).Where(x => x.Borrows.Any(y => y.Book.Title != null)).ToList();
                results = _context.EmployeeDates.Include(x => x.Employee).ToList();
                return results;
            }
        }

        public List<Employee> GetDates2()
        {
            List<Employee> results;
            using (CompanyContext context = new CompanyContext())
            {
                //results = _context.Books.Include(x => x.Author).Include(x => x.Borrows).Where(x => x.Borrows.Any(y => y.Book.Title != null)).ToList();
                results = _context.Employees.Include(x => x.EmployeeDates).ToList();
                return results;
            }
        }
    }
}
