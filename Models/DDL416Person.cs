using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    [Table("DDL416Person")]


    public class DDL416Person {
    
    [Key]
    public string? PersonId {get; set;}
    public string? FullName {get; set;}
    
    public string? Address {get; set;}
   
    }
}