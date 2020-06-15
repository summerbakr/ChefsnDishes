using System.ComponentModel.DataAnnotations;
    using System;
using System.Collections.Generic;

namespace ChefsDishes.Models
    {
        public class Dish
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int DishId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string

            [Required]
            public string Name { get; set; }

            [Required]
            [Range(0,Int32.MaxValue)]
            public int Calories{ get; set; }
            
            [Required]
            public string Description { get; set; }
            [Required]
            [Range(1,5)]
            public int Tastiness{ get; set; }

            public DateTime CreatedAt {get;set;}=DateTime.Now;
            public DateTime UpdatedAt {get;set;}=DateTime.Now;
            public int ChefId {get;set;}
            public Chef DishCreator {get; set;}
        }
    }