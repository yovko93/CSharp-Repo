using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserJsonInputModel
    {
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        //[MinLength(1)]
        public IEnumerable<CardJsonInputModel> Cards { get; set; }
    }
}
