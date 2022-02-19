using System;
using System.ComponentModel.DataAnnotations;

namespace TodoExample.Api.Models
{
    public class TodoModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Task { get; set; }
    }
}