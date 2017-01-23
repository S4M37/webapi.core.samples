using System.ComponentModel.DataAnnotations;

namespace webapi.core.entityframework.ModelMapped
{
    public class BusinessCreateModel
    {
        [Required]
        [Display(Name = "categoryId")]
        public string CategoryId { get; set; }

        [Required]
        [Display(Name = "name")]
        [MaxLength(140)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "adress")]
        [MaxLength(240)]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "x")]
        public double X { get; set; }

        [Required]
        [Display(Name = "y")]
        public double Y { get; set; }
    }
}
