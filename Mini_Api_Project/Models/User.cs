using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_CORE_TRY.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    
}