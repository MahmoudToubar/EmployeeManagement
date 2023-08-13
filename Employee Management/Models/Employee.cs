using Employee_Management.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }



        [Required(ErrorMessage = "Enter Name")]
        [StringLength(100, ErrorMessage = "Name must be less than 100")]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "ID must be a number")]
        public int ID { get; set; }


        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID should be 14 numbers")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "National ID must be a number")]
        public string NationalId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [CheckAge(minAge: 18, ErrorMessage = "Employee must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }



        
        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                    age--;
                return age;
            }
            set
            {

            }
        }


        public string Account { get; set; }

        public string LineOfBusiness { get; set; }
      
        public string Language { get; set; }
  
        public string LanguageLevel { get; set; }
    }
}
