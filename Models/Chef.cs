using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ChefsDishes.Models
    {
        public class Chef
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int ChefId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }
            
            [Required]
            [DataType(DataType.Date)]
            [PastDates]
            public DateTime DOB { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime

            public DateTime CreatedAt {get;set;}=DateTime.Now;
            public DateTime UpdatedAt {get;set;}=DateTime.Now;
            public List<Dish> ChefDishes {get;set;}
        }
    }