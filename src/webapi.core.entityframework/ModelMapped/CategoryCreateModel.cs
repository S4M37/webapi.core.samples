using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.core.entityframework.ModelMapped
{
    public class CategoryCreateModel
    {
        [Required]
        [Display(Name = "name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
