using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models;

public class Post
{
  [Key]
  public int Id { get; set; }

  [StringLength(300)]
  [Required(ErrorMessage = "Content is required")]
  public string Content { get; set; }

  public int StudentId { get; set; }

  [ForeignKey("StudentId")] 
  public Student Student { get; set; }

  [InverseProperty("Post")]
  public ICollection<Picture> Pictures { get; set; }

  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }
}