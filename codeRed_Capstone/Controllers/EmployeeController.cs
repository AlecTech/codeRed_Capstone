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
//using System.ComponentModel.DataAnnotations;
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
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Employees.ToListAsync());
        //}

        // GET: Employee
        public async Task<IActionResult> Index(string sortOrder)
        {   //Nov20 added viewbag to access Dates later inside views
            //ViewBag.Employees = GetDates2();
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

            var employees =  _context.Employees.Where(m => m.LastName == lastName);
               // .FirstOrDefaultAsync(m => m.LastName == lastName);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            return View(employees);
        }
        // GET: Employee/DetailsByEmail/5
        public async Task<IActionResult> DetailsByEmail(string email)
        //public IActionResult DetailsByEmail(string email)
        {
            //Nov 25 Added validation logic to Search option
            //if (email == "333")

            //string exists;
            bool exists;
            //exists = _context.Employees.FirstOrDefaultAsync(m => m.Email == email).ToString();
            if (!(exists = _context.Employees.Any(m => m.Email == email)))
            {
                //return NotFound(new Exception("Email not found"));
                ModelState.AddModelError("Email", "Email not found");

            }

            //var employee = await _context.Employees
            //    .FirstOrDefaultAsync(m => m.Email == email);

            //if (employee == null)
            //{
            //    return NotFound();
            //}

            if (!ModelState.IsValid)
            {
                return View();
            }
               
            else
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Email == email);
                return View(employee);
            }
                
            //return  View("~/Views/Employee/Index.cshtml");
        }
        // GET: Employee/Create
        public IActionResult Create(int ID =0)
        {
            //var model = new Employee();
            //model.ValidationValidFrom = DateTime.Today;
            return View(new Employee());
        }

        //[AcceptVerbs("GET", "POST")]
        //public IActionResult VerifyPhone(
        //[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] string phone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Json($"Phone {phone} has an invalid format. Format: ###-###-####");
        //    }

        //    return Json(true);
        //}

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
                //VerifyPhone();
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

//=============work area for search by email
//ValidationException exception = new ValidationException();
//email = !string.IsNullOrWhiteSpace(email) ? email.Trim() : null;
//=============================================================
//if (Request.Query.Count > 0)
//if(email != null)
// {
// try
//  {
//GetRecordByID(email);
//var results = _context.Employees.Include(x => x.Employee).Where(x => x.Employee.Email == email).ToList();
//if (results.Exists)
// }
// Catch ONLY ValidationException. Any other Exceptions (FormatException, DivideByZeroException, etc) will not get caught, and will break the whole program.
// catch (ValidationException e)
//    {
//        ViewBag.Email = email;
//        ViewBag.Message = "There exist problem(s) with your submission, see below.";
//        ViewBag.Exception = e;
//        ViewBag.Error = true;
//    }
//}

//exception.ValidationExceptions.Add(new Exception("Email Not Provided"));

//else if (!_context.Employees.Any(x => x.Email.ToUpper() != email.ToUpper()))
//{
//    exception.ValidationExceptions.Add(new Exception("Email doesn't exist"));
//}

//if (exception.ValidationExceptions.Count > 0)
//{
//    throw exception;
//}

//var employee = await _context.Employees
//            .FirstOrDefaultAsync(m => m.Email == email);
//var employee = _context.Employees
//            .FirstOrDefaultAsync(m => m.Email == email);

//return View(employee);


//else
//{
//    // Name is a duplicate.
//    // Not a common validation point necessarily, but does perform (2).
//    if(_context.Employees.Any(x => x.Email.ToUpper() == email.ToUpper()))
//    {
//        var employee = await _context.Employees
//            .FirstOrDefaultAsync(m => m.Email == email);
//        return View(employee);
//        //ViewBag.Employee = GetRecordByID(id);   
//        //exception.ValidationExceptions.Add(new Exception("Name Already Exists"));
//    }
//    else
//    {


//if (name.Length > 30)
//{
//    // Name too long
//    // Common validation point (3).
//    exception.ValidationExceptions.Add(new Exception("The Maximum Length of a Name is 30 Characters"));
//}
//else
//{
//    if (name.ToUpper() == "PAPER CUPS" && parsedCategoryID == context.Categories.Where(x => x.Name == "Kitchen").Single().ID)
//    {
//        exception.ValidationExceptions.Add(new Exception("Only Glass Glasses Allowed Here"));
//    }
//}
//}
//}
//=======================================================================
//if (string.IsNullOrEmpty(lastName))
//{
//    ModelState.AddModelError("Last Name is required.");
//}
//===============================
//if (Request.Query.Count > 0)
//{
//    try
//    {

//        var results = _context.Employees.Include(x => x.Employee).Where(x => x.Employee.Email == email).ToList();
//        //if (results.Exists)
//    }
//    // Catch ONLY ValidationException. Any other Exceptions (FormatException, DivideByZeroException, etc) will not get caught, and will break the whole program.
//    catch (ValidationException e)
//    {
//        ViewBag.Email = email;
//        ViewBag.Message = "There exist problem(s) with your submission, see below.";
//        ViewBag.Exception = e;
//        ViewBag.Error = true;
//    }
//}
//=====================