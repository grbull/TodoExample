using System.ComponentModel.DataAnnotations;

namespace TodoExample.Api.Models
{
    public class TodoUpdateModel
    {
        [Required]
        public string Task { get; set; }
    }
}