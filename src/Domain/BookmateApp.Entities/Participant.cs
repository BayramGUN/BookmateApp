using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmateApp.Entities;

public class Participant : IEntity
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}
