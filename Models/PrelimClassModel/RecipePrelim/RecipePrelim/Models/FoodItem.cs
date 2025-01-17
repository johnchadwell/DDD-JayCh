﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<IngredientItem> IngredientItem { get; set; }
        public FoodItemType FoodItemType { get; set; }
    }

}
