using System.ComponentModel.DataAnnotations;

namespace WebAppDemo1.Models;
public class CloudEngineer
{
    [Key]
    public int CEID { get; set; }
    public string? CEName { get; set; }

    public string? CELocation {  get; set; }

}
