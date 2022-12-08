using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models;

public class Picture
{
  [Key]
  public int Id { get; set; }

  [StringLength(300)]
  [Required(ErrorMessage = "Data is required")]
  public string Data { get; set; }

  public int PostId { get; set; }

  [ForeignKey("PostId")] 
  public Post Post { get; set; }
  
}