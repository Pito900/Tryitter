using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models;

public class Student
{
  [Key]
  public int Id { get; set; }

  [StringLength(100)]
  [Required(ErrorMessage = "Name is required")]
  public string Name { get; set; }

  [StringLength(100)]
  [Required(ErrorMessage = "Email is required")]
  public string Email { get; set; }

  [StringLength(100)]
  [Required(ErrorMessage = "Password is required")]
  public string Password { get; set; }

  [StringLength(100)]
  [Required(ErrorMessage = "Module is required")]
  public string Current_Module { get; set; }

  [StringLength(100)]
  [Required(ErrorMessage = "Status is required")]
  public string Status { get; set; }

  [InverseProperty("Student")]
  public ICollection<Post>? Posts { get; set; }

  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }
}