using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace ASPNETMVCFORMDemo.Models
{
    public enum Gender
    {
        Female, Male
    }
    public class EmployeeInfo
    {
        
        public int EmployeeID { get; set; }

        [Display(Name = "Given Name")]
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        
        [Display(Name = "SurName")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Annual Salary")]
        [Range(1, 2000000)]
        public double  AnnualSalary { get; set; }

        [Display(Name = "Department")]
        [Range(1, 1000)]
        public int  DepartmentId { get; set; }

        [Display(Name = "City")]
        
        //public int CityId { get; set; }
        
        public IEnumerable<SelectListItem> CityId { get; set; }

        public int[] SelectedCities { get; set; }

    }
}