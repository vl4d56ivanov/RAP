using System.ComponentModel.DataAnnotations;

namespace RAP.UI.Models
{
    public class ServiceTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}