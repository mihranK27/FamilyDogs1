using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDogs.Domain
{
    public class Dog
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        [Display(Name = "Living Area")]
        public string LivingArea { get; set; }

        [Display(Name = "Life Span")]
        public string LifeExpectancy { get; set; }

        [Display(Name = "Shedding")]
        public int ShedScore { get; set; }

        [Display(Name = "Aggression")]
        public int AgressiveScore { get; set; }

        [Display(Name = "Exercise")]
        public int ExerciseScore { get; set; }

        [Display(Name = "Total")]
        public int TotalScore { get; set; }

        public string Image { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Dog()
        {
            Id = 0;
        }
    }
}