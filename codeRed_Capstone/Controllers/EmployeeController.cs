using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using codeRed_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using codeRed_Capstone.Models.Exceptions;
//Dec7 added for post protection
//using System.Net;

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
        public async Task<IActionResult> Index(string sortOrder, bool filter)
        {   //sorting and checkbox filtering added here
       
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewData["DepSortParm"] = String.IsNullOrEmpty(sortOrder) ? "dep_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var emps = from s in _context.Employees
                       select s;

            if (filter)
            {
                emps = emps.Where(s => s.FiredDate != null);
            }

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
                case "Date":
                    emps = emps.OrderBy(s => s.HiredDate);
                    break;
                case "date_desc":
                    emps = emps.OrderByDescending(s => s.HiredDate);
                    break;
                default:
                    emps = emps.OrderBy(s => s.LastName);
                    break;
            }
            return View(await emps.AsNoTracking().ToListAsync());
      
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool employeeFound = EmployeeExists(id.Value);

            if(!employeeFound)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

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
         public IActionResult DetailsBySurname(string lastName)
        //public IActionResult DetailsBySurname(string lastName)
        {
            lastName = !string.IsNullOrWhiteSpace(lastName) ? lastName.Trim() : null;
            //============= my validation ===================
            if (string.IsNullOrWhiteSpace(lastName))
            {
                ModelState.AddModelError("LastName", "Last Name not Provided");               
            }

            bool exists;
            if (!(exists = _context.Employees.Any(m => m.LastName == lastName)))
            {              
                ModelState.AddModelError("LastName", "Last Name not found");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var employee = _context.Employees.Where(m => m.LastName == lastName);
                return View(employee);
            }
   
        }
        // GET: Employee/DetailsByEmail/5
        public async Task<IActionResult> DetailsByEmail(string email)
        //public IActionResult DetailsByEmail(string email)
        {
            //Nov 25 Added validation logic to Search option
            email = !string.IsNullOrWhiteSpace(email) ? email.Trim() : null;

            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("Email", "Email not Provided");
            }

            bool exists;  
            if (!(exists = _context.Employees.Any(m => m.Email == email)))
            {
                ModelState.AddModelError("Email", "Email not found");
            }        

            if (!ModelState.IsValid)
            {
                return View();
            }           
            else
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Email == email);
                return View(employee);
            }                         
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
            employee.FirstName = !string.IsNullOrWhiteSpace(employee.FirstName) ? employee.FirstName.Trim() : null;
            if (string.IsNullOrWhiteSpace(employee.FirstName))
            {
                ModelState.AddModelError("FirstName", "First Name not Provided");
            }

            employee.LastName = !string.IsNullOrWhiteSpace(employee.LastName) ? employee.LastName.Trim() : null;
            if (string.IsNullOrWhiteSpace(employee.LastName))
            {
                ModelState.AddModelError("LastName", "Last Name not Provided");
            }

            employee.Email = !string.IsNullOrWhiteSpace(employee.Email) ? employee.Email.Trim() : null;
            if (string.IsNullOrWhiteSpace(employee.Email))
            {
                ModelState.AddModelError("Email", "Email not Provided");
            }

            bool exists;
            if (exists = _context.Employees.Any(m => m.Email == employee.Email))
            {          
                ModelState.AddModelError("Email", "Email already exists");
            }

            string departmentNotSelected = "null";
            if (employee.Department == departmentNotSelected)
            {
                ModelState.AddModelError("Department", "Department not selected");
            }

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
            bool employeeFound = EmployeeExists(id.Value);

            if (!employeeFound)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                //return HttpNotFound();
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Phone,Age,City,Department,HiredDate,FiredDate, TimesModified")] Employee employee)
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

                    employee = await _context.Employees.Where(e => e.ID == employee.ID).FirstOrDefaultAsync();
                    employee.TimesModified += 1;
                    // _context.Entry(employee).State = EntityState.Modified;

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
            bool employeeFound = EmployeeExists(id.Value);

            if (!employeeFound)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

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

        //public void GetRecordByID(string email)
        public Employee GetRecordByID(string email)
        {
            //Debug.WriteLine($"DATA - GetBookByID({id})");

            ValidationException exception = new ValidationException();
            using (var context = new CompanyContext())
            {

                
                int parsedEmail = 0;
                if (string.IsNullOrWhiteSpace(email))
                {
                    exception.ValidationExceptions.Add(new Exception("Email Not Provided"));
                }
                else
                {
                    
                    // Common validation points (5) and (5a).
                    if (int.TryParse(email, out parsedEmail))
                    {
                        exception.ValidationExceptions.Add(new Exception("Email Not Valid, please enter string"));
                    }
                    else
                    {
                        // Category ID exists.
                        // Common validation point (7).
                        if (!context.Employees.Any(x => x.Email == email))
                        {
                            exception.ValidationExceptions.Add(new Exception("Email Does Not Exist"));
                        }
                    }

                }
            }

            if (exception.ValidationExceptions.Count > 0)
            {
                throw exception;
            }
            return _context.Employees.Where(x => x.Email == email).Single();
        }

    }
}