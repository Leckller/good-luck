using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodLuck.Models;

class User
{
    [Key]
    public int UserId { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }

    [InverseProperty("User")]
    public ICollection<Day>? Days { get; set; }
}