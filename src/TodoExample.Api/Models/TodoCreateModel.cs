using System.ComponentModel.DataAnnotations;

namespace TodoExample.Api.Models
{
    public class TodoCreateModel
    {
        [Required]
        public string Task { get; set; }
    }
}