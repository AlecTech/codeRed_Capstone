## Problem Definition

* Employee Directory App

Problem Definition: Some companies have an Excel spreadsheet to keep track of Employee Directory. This App would be useful for the intranet network of a small to medium company. Human Resources staff can use it when logged in to the companies intranet or on a shared drive when granted access to this App.
Intranet - An intranet is a computer network for sharing information, collaboration tools, operational systems, and other computing services within an organization, usually to the exclusion of access by outsiders.

## Scope (in-scope items, and out-of-scope items)

* In-scope:
1) Sign-in Page.
a) Login Name
b) Password

2) Sign-up Page.
a) First Name
b) Last Name
c) Email
d) Password
e) Confirm Password

3) Admin Console that consists of:
a) Create Record button
b) Edit Record button
c) Details Record button
d) Delete Record button

4) Create Record Page
a) First Name
b) Last Name
c) Email field
d) Phone field
e) Age field
f) City field
g) Department field

5) Show Details Record
a) First Name field
b) Last Name
c) Email field
d) Phone field
e) Age field
f) City field
g) Department field

6) Validations:
a) Server Side

* Out-of-Scope:
1) Search Option
a) By Email
b) By Last Name

2) Filter checkbox to display List of Employees that were Laid Off

3) Input Properties, extra fields:
a) HiredDate - when person was hired.
b) FiredDate - when person was fired.
c) ModifiedDate - when record was modified last time.
d) TimesModified - how many times record was modified.

4) Show Details Page
h) Hired Date field
i) Fired Date field
j) Modified Date field
k) TimesModified field

5) Re-format Table Media Query for Mobile View

6) Set custom cookie session for 1 Day

7) Collapse NavBar to Hamburger menu on Mobile view

8) Sorting: By Last Name, By Email, By Date Hired, Group By Department

9) Validation:
a) Client Side - JQuery
b) Business logic validation
c) Over-Posting URL

## Citation

* DateTime formats 

https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.boundfield.dataformatstring?redirectedfrom=MSDN&view=netframework-4.8#System_Web_UI_WebControls_BoundField_DataFormatString

* RegEx validation for allowed email domain names

https://stackoverflow.com/questions/5554524/only-allow-registrations-from-specific-email-domains

* RegEx validation for allowed phone format

https://stackoverflow.com/questions/28904826/phone-number-validation-mvc

* Sorting by Lastname, Dates, Departments

https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-5.0

* Re-format table CSS code

https://css-tricks.com/responsive-data-tables/

* Logo 3D effect CSS code

https://codepen.io/ryandsouza13/pen/yEBJQV

* Figma Presentation WireFrames

https://www.figma.com/file/qvfW7WVl8IXbr0MG5ZiP3n/Wireframing-for-codeRed-Capstone?node-id=0%3A1

* Identity Page

https://www.c-sharpcorner.com/article/using-asp-net-core-3-0-identity-with-mysql/

* Trello Board Link

https://trello.com/b/Q00eKKMS/capstone-project

* Packages

a.	Microsoft.AspNetCore.Identity.EntityFrameworkCore
b.	Microsoft.AspNetCore.Identity.UI
c.	Microsoft.AspNetCore.Mvc.NewtonsoftJson
d.	Microsoft.AspNetCore.SpaServices.Extensions
e.	Microsoft.EntityFrameworkCore.Design
f.	Microsoft.EntityFrameworkCore.Sqlite
g.	Microsoft.EntityFrameworkCore.SqlServer
h.	Microsoft.EntityFrameworkCore.Tools
i.	Microsoft.VisualStudio.Web.CodeGeneration.Design
j.	Pomelo.EntityFrameworkCore.MySql

![alt text](https://github.com/AlecTech/codeRed_Capstone/tree/oneTable/installed_Packages.jpg?raw=true)

## Installation Instruction

### Installation Guide

* Getting Started
1.	Open Visual Studio Community 2019
2.	Clone repository: https://github.com/TECHCareers-by-Manpower/capstone-project-codered.git
3.	Install packages: 
a.	Microsoft.AspNetCore.Identity.EntityFrameworkCore
b.	Microsoft.AspNetCore.Identity.UI
c.	Microsoft.AspNetCore.Mvc.NewtonsoftJson
d.	Microsoft.AspNetCore.SpaServices.Extensions
e.	Microsoft.EntityFrameworkCore.Design
f.	Microsoft.EntityFrameworkCore.Sqlite
g.	Microsoft.EntityFrameworkCore.SqlServer
h.	Microsoft.EntityFrameworkCore.Tools
i.	Microsoft.VisualStudio.Web.CodeGeneration.Design
j.	Pomelo.EntityFrameworkCore.MySql
 
4.	Run 2 commands to create migration and update database in this order:
a.	dotnet ef migrations add InitialMigration --context codeRed_Capstone.Models.CompanyContext
b.	dotnet ef database update --context codeRed_Capstone.Models.CompanyContext
Note: Copy past might not work sometimes. If so just type it manually. 
 

5.	Make sure your XAMPP server up and running. If you don’t have XAMPP server installed, please see procedure below.
6.	Run the program by clicking IIS Express button. 
7.	Register to get access.

* How to use the App:

8.	First time access - at the start HR would have to register and choose unique email address to be recognized by the app upon next login.
9.	Once logged in HR staff would be able (if need so) change setting of the login system and apply 2 way authentication system.
10.	Primary display will show a list of all employees with-in the company hierarchy.
11.	This App will allow HR staff to Search this list by email address and by last name if needed. Search by Last name will take into consideration that more than 1 entity can exist with the same last name.
12.	There will be a toggle checkbox as well which will allow to filter out all entities that are already laid off and delete them.
13.	This list will also allow sorting my Last name in ascending order, Group By Departments, sort by Email address and sort by Hired Date in chronological order.
14.	Each Entity will also have an email hyper link which allows to contact person by email.
15.	Each Entity will have 3 action icons: Edit, Display and Delete.
a) Edit will allow to edit any field previously entered during creation of the entity and also add Fired Date to the entity id this person was laid off.
b) Display will allow to see all fields again and on to of that to see when this entry was last edited(timestamp). This Display page will also be used for search results and error messages if certain entity was not found.
c) Delete option will have a pop up message warning that "you are about to delete a person" and Delete page were HR staff can change their mind before final deletion.
16.	Last feature that this table will have a user friendly layout of this table for the phone devices, because tables are hard to fit on the small screen, upon small screen detection by the media query. Table will be re-formatted in to block view design.
17.	Finally there will be a logout button at the top right corner that allows HR staff to logout when editing or updating is done.

* How to install XAMPP server
https://blog.templatetoaster.com/install-xampp-on-windows/

## List of Test Cases

### Testing Plan:

1)	Registration Page
a.	Empty fields cannot be submitted
i.	Error messages will appear next to each field and a list of all of them at the top of the form. ( This is client side validation)
b.	First and Last Names cannot have alphanumeric characters(including trailing spaces)
i.	Error message will say “Can not have number or special character”. ( This is client side validation)
c.	Email field has to follow special format: anything@company.ca or anything@company.com . Only company.ca or company.com email domains allowed
i.	Error message will say: “ Registration limited to company.ca or company.com”. ( This is client side validation)
d.	Email has to have domain name: john@ is not allowed, john@company also not allowed.
i.	Error message will say: “Invalid email address”. ( This is client side validation)
e.	Email has to be unique: Database will check if email already exists.
i.	Error message will say: “User name 'jalba@company.ca' is already taken.”
f.	Email has to be less than 60 characters long.
i.	There would be no error message, instead this input field would simply stop taking characters.
g.	Password cannot be less than 6 or more than 100 characters: I must have at least 1 Capital, at least one numeric. 
i.	Error message will say: 
“The Password must be at least 6 and at max 100 characters long.” 
ii.	Error message will say: 
Passwords must have at least one digit ('0'-'9').
Passwords must have at least one uppercase ('A'-'Z').
( This is client side validation)
h.	Password Confirmation has to match chosen password field.
i.	Error message will say: “The password and confirmation password do not match.”

2)	Login Page 
a.	Empty fields cannot be submitted
i.	Error will appear next to each field and a list of all of them at the top of the form. It will say: “Email fields is required” and “Password fields is required”
b.	Email field has to follow special format: anything@company.ca or anything@company.com . Only company.ca or company.com email domains allowed
i.	Error message will say: “Registration limited to company.ca or company.com”. ( This is client side validation)
c.	Email has to have domain name: john@ is not allowed, john@company also not allowed.
i.	Error message will say: “Invalid email address”. “Invalid email format”( This is client side validation)
d.	Email has to be present inside db to login: ex. [ jchan@company.ca {Qwer1234} or jalba@company.ca {Password1}]
i.	Error will show up if email not found: “Invalid login attempt”
e.	Password would be checked against existing records
i.	Error will show up if password doesn’t match: “Invalid login attempt” 
ii.	Upon successful login you would be taken to the Home page which is Index.cshtml page with table and 5 records (seeding data).
f.	Checkbox “Remember me” allows you to keep your credentials for 14 days by default with session.

3)	Home Page
a.	Top Hyper Links 
i.	Home – redirects you back to Index.cshtml (Home page)
ii.	Settings – Takes you to account settings where you can:
1.	Add phone number to your account
2.	Change Password
3.	Set Two-Factor authentication
iii.	Logout – will take you back to login page and won’t be able to log back in even if you type (Employee/Index at the URL). When you try to bypass authentication page it will simple redirect you back to login page. 
b.	Navbar
i.	Checkbox “Laid of only” – if you check this and click Show! It will display only those employees that were fired. 
ii.	“Back to full list” hyper link – will reload full list of records.
iii.	Search by Email field – will help you find people by email.
1.	If you try to submit empty record it will display error message: “ Email is required” (Client side validation done by JQuery). 
2.	If you bypass JQuery validation, then Server side validation will say the same error: “Email not provided”. One of the ways to test it – you can comment { @*data-val="true" data-val-required="Email is required"*@}  on line 25 inside Index.cshtml and run program again. Another way to test it is if you just type spaces and hit enter.
3.	If you somehow bypass JQuery validation and IsNullOrWhiteSpace validation(inside EmployeeController.cs), it will return another error: “The email address is required” message which is done by Model validation inside Employee.cs
4.	If you provide anything that’s not inside database it will jump inside Details view and display error message: “Email not Found”.
5.	If you provide valid email address with trailing spaces at the back or front it will trim them and still give you your result inside Details View.
6.	If you capitalize all letters of the email it will still give you correct result. It’s not case sensitive.
7.	If you capitalize and add trailing spaces at the back it will still give you correct result.
Note: This Database only holds one unique email address for each entity  so it will always return one result. Unlike with Last Name Search option. 
iv.	Search by Last Name field – will help you find people by Last Name.
1.	If you try to submit empty record it will display error message: “Last Name is required” (Client side validation done by JQuery). 
2.	If you bypass JQuery validation, then Server side validation will say the same error: “Last Name not provided”. One of the ways to test it – you can comment { @*data-val="true" data-val-required="Last Name is required"*@} on line 25 inside Index.cshtml and run program again. Another way to test it is if you just type spaces and hit enter.
3.	If you provide anything that’s not inside database it will jump inside Details View and display error message: “Last Name not Found”.
4.	If you provide valid Last Name with trailing spaces at the back or front it will trim them and still give you your result inside Details View.
5.	If you capitalize all letters of the Last Name it will still give you correct result. It’s not case sensitive.
6.	If you capitalize and add trailing spaces at the back it will still give you correct result.
7.	If there more than 1 match it will list all the results one after another
c.	Sorting features
i.	Last Name sorting.
1.	By default Home page loads entire list in ascending alphabetical order
2.	If you click on Last Name (hyper link) it will sort the same list in descending alphabetical order.
ii.	Email sorting.
1.	The same applies for the email, if you click on the Email hyper link if will list all records in ascending or descending alphabetical order depending in the initial state. 
iii.	Department sorting.
1.	If you click on the Department hyper link it will group them by Department, which allows to see when department is the largest. 
iv.	Hired On sorting.
1.	Then you click Hired On hyper link it reloads entire list in chronological order , which allows to see more senior employees vs. junior ones. 
d.	Create button – takes you to Create Form which has 8 input fields and 2 buttons( Create and Back to List)
i.	Empty Fields – validation does not allow submitting empty fields. Error message will appear next to each field to indicate that it has to be filled out. 
ii.	First and Last Name fields will have the same validations:
1.	If you use Numbers or Special characters or Trailing spaces in your name it won’t accept it. Error message will say: “Can not have numbers or special characters”. This validation is done by RegEx inside Employee Model.
2.	If you try to type names longer than 60 characters long it won’t accept it. This exception is handled by MaxLength attribute inside Employee model. 
3.	If you type 1 letter it will accept as a valid name.
4.	I decided that there could be more than 1 person with exact first and last name. That’s why there is no unique validation for names in this database. That’s why search by last name works with multiple matching entities if it finds any.
iii.	Email field – validation allows alphanumeric characters and capitals. Numeric characters only disabled for the .com extension portion
1.	Entering invalid email format will trigger format error validation. Error message will say: “Invalid Email Address” if following format examples are entered: [a@],[a@b.]    
2.	 Entering invalid email format will trigger format error validation. Error message will say: “Invalid Email Format” if following format example is entered: [a@b], [a@b.1]
3.	If you enter email that find exact match in the database it will throw an error message that says: “Email already exists”. That’s why emails in this database has to be unique. 
4.	If you enter email longer than 100 characters long it will not accept it. MaxLenght attribute is used for that.
iv.	Phone field – Protected by RegEx which will try to enforce following format (###)###-####.
1.	If you type any alphabetical or special characters it will trigger error message that says: “ Phone format should be: (###)###-####
2.	If you type more than 10 integers it will trigger error message that says: “ Phone format should be: (###)###-####
3.	If you type more than 10 integers it will trigger error message that says: “ Phone format should be: (###)###-####
4.	If you type trailing spaces after digits it will trigger error message that says: “ Phone format should be: (###)###-####
v.	Age field – This is a simple validation controlled by [Range] attribute
1.	It will not accept digits less than 16 or more than 100. Error message: “The Age field must be between 16 and 100”
2.	This field won’t also accept any letters. Error message: “The age field is required”
3.	This field also has arrows up and down indicating that this is an integer field only. 
vi.	City field will have similar validation like Names
1.	If you use Numbers or Special characters or Trailing spaces in your name it won’t accept it. Error message will say: “Can not have numbers or special characters”. This validation is done by RegEx inside Employee Model.
2.	If you try to type names longer than 100 characters long it won’t accept it. This exception is handled by MaxLength attribute inside Employee model. 
3.	If you type 1 letter it will accept as a valid name.
vii.	Department field – is pre selected options.
1.	You can not leave it blank or not selected. Error message will say: “Department not selected”
2.	This is a drop down menu that’s why there is not much validation here.
viii.	Hired On fields – its a DateType data type that could be left blank by the user, but will not be left blank by database because it has Default value NOW().
1.	If you leave it blank then current date will be assigned automatically.
2.	If you try assign future date it will trigger error message that says: “Hired date can not be into the future”. This is done by CurrentDate attribute which was customized in the separate class called CurrentDateAttribute inside Common folder.
3.	If you pick today or older dates it will accept your input.
4.	Model validation will enforce {0:d} date format which looks like the following example: “2020-12-01” (yyyy-mm-dd)
ix.	Create button will create a new record and take you back to the list if all fields a validated.
x.	Back to List button will take you back to home page.
e.	Every Email is hyper link and is tied to mailto client, which allows you to send an email right away to the person of interest. 
f.	Pencil icon = Edit button – this takes you to the Edit view where you can update any of the fields plus new field for the Fired Date. 
i.	Empty Fields – validation does not allow submitting empty fields. Error message will appear next to each field to indicate that it has to be filled out. Except one last field Fired Date because its allowed to be NULL in the data base.
ii.	ALL FIELDS HAVE IDENTICAL VALIDATION AS CREATE PAGE EXCEPT FIRED DATE.
iii.	If you try assign future Fired date it will trigger error message that says: “Fired date can not be into the future”. This is done by CurrentDate attribute which is customized  in the separate class called CurrentDateAttribute inside Common folder.
iv.	If you try to enter Fired Date before Hired Date it will trigger error message:” Can not Fire before Hire”. This validation is done by the IValidatableObject at the end of Employee Model.
v.	All other dates in between present date and Hired date are valid. 
g.	Info Icon = Details button – this takes you to the details view where you can find one more parameter that shows last Modified DateTime. That Helps to track changes that were applied by the HR.
i.	One of the ways to test it is to change something inside Edit View and check back inside Details view to see if this last update triggered this Modification Date to change. 
h.	Trash Icon = Delete button – this takes you to the Delete view and allows you to view and double check details of that person that you trying to delete.
i.	On click JS event triggers a popup message that giving a user last chance to change their mind and says: “You are about to delete this Employee, are you sure?”. 
i.	Final feature that we can test is collapsible Table, once you shrink the screen beyond max-width: 760px Media query re-formats the table into more user friendly block-view layout.  
i.	Notice that font-size gets bigger when it happens and Sorting feature stays, except for inactive table headings like Age or Phone which become hidden from the user.
ii.	Also NavBar collapses to a hamburger menu for a better representation. 




