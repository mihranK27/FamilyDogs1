using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyDogs.Models.Request
{
    public class DogsCreateRequest
    {
        [Required(ErrorMessage = "dog name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "name must be between 30 and 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage="dog breed is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "breed must be between 30 and 2 characters")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "dog color is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "color must be between 10 and 2 characters")]
        public string Color { get; set; }

        [Required(ErrorMessage = "dog size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "dog living area is required")]
        [Display(Name = "Living Area")]
        public string LivingArea { get; set; }

        [Required(ErrorMessage = "dog life length is required")]
        [Display(Name = "Life Span")]
        public string LifeExpectancy { get; set; }
  
        [Required]
        [Display(Name = "Shedding")]
        public int ShedScore { get; set; }

        [Required]
        [Display(Name = "Aggression")]
        public int AgressiveScore { get; set; }

        [Required]
        [Display(Name = "Exercise")]
        public int ExerciseScore { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}