using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodLuck.Models;

class Day
{
    [Key]
    public int DayId { get; set; }
    public string date { get; set; }
    public int clover
    {
        get { return this.clover; }
        set
        {
            if (this.clover < 4)
            {
                this.clover = 4;
            }
            this.clover = clover;
        }
    }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}