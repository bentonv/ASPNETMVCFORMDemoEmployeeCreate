using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVCFORMDemo.Models;
/*Benton Valenzuela lab2
 I tried to extend the idea by adding a multi select. 
i rant into an issue with validation. I think I could combine the code from the two HTTP posts into a single block
*/
namespace ASPNETMVCFORMDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var model = new EmployeeInfo
            {

                SelectedCities = new[] { 2 },
                CityId = GetCities()
            };
            return View(model);
        }

       
        private SelectListItem[] GetDepartments()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Text = "Accounting", 
                Value = "101",
                Selected = true
            });

            list.Add(new SelectListItem()
            {
                Text = "Human Resources",
                Value = "105",
               
            });

            list.Add(new SelectListItem()
            {
                Text = "Information Technology",
                Value = "110",
                
            });
            list.Add(new SelectListItem()
            {
                Text = "Executive",
                Value = "115",
               
            });
            return list.ToArray();
        }

        
        private List<SelectListItem> GetCities()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Napa", Value = "1" });
            items.Add(new SelectListItem() { Text = "Calistoga", Value = "2" });
            items.Add(new SelectListItem() { Text = "St Helena", Value = "3" });
            items.Add(new SelectListItem() { Text = "American Canyon", Value = "4" });
            return items;
        }
        public ActionResult Create()
        {
            ViewData["Departments"] = GetDepartments();
            ViewData["Cities"] = GetCities();
            //call get departments method then assign it to viewdata dictionary
            //create new object model and pass it to view method
            return View(new Models.EmployeeInfo());
        }

        [HttpPost]
        public ActionResult Create(EmployeeInfo e)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    SaveEmployeeToDatabase(e);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewData["Departments"] = GetDepartments();
            ViewData["Cities"] = GetCities();
            return View(e);
        }

        //[HttpPost]
        //public ActionResult Index(EmployeeInfo model)
        //{
        //    model.CityId = GetCities();
        //    if (model.SelectedCities != null)
        //    {
        //        List<SelectListItem> selectedItems = model.CityId.Where(p => model.SelectedCities.Contains(int.Parse(p.Value))).ToList();
        //        foreach (var City in selectedItems)
        //        {
        //            City.Selected = true;
        //            ViewBag.Message += City.Text + " | ";
        //        }
        //    }
        //    return View(model);
        //}
        private void SaveEmployeeToDatabase(EmployeeInfo e)
        {
            throw new ApplicationException("Could not save employee to database");
        }
    }
}