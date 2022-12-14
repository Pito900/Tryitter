using Tryitter.Models;

namespace Tryitter.Test;

public static class ContextHelper
{
  public static IEnumerable<Student> GetTestStudents()
  {
    return new List<Student> {
      new Student {
        Id = 1,
        Name = "Fábio",
        Email = "fab10_lima@hotmail.com",
        Password = "123456789",
        Current_Module = "Ciência da Computação",
        Status = "Studying",
        CreatedAt = new DateTime(2021, 10, 17),
        UpdatedAt = new DateTime(2021, 10, 17),
      },
      new Student {
        Id = 2,
        Name = "Francisco",
        Email = "",
        Password = "123456789",
        Current_Module = "Aceleração C#",
        Status = "Working",
        CreatedAt = new DateTime(2021, 10, 17),
        UpdatedAt = new DateTime(2021, 10, 17),
      },
      new Student {
        Id = 3,
        Name = "Fernando",
        Email = "",
        Password = "123456789",
        Current_Module = "Aceleração C#",
        Status = "Working",
        CreatedAt = new DateTime(2021, 10, 17),
        UpdatedAt = new DateTime(2021, 10, 17),
      }
    };
  }
}