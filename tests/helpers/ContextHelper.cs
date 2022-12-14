using Tryitter.Models;
using Tryitter.Requests;

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
  public static IEnumerable<Student> CreateTestStudents()
  {
    return new List<Student> {
      new Student {
        Id = 3,
        Name = "Mário",
        Email = "mario@gmail.com",
        Password = "1234",
        Current_Module = "Aceleração C#",
        Status = "Working",
        CreatedAt = new DateTime(2021, 10, 17),
        UpdatedAt = new DateTime(2021, 10, 17),
      }
    };
  }
  public static IEnumerable<Student> UpdateTestStudents()
  {
    return new List<Student> {
      new Student {
        Id = 1,
        Name = "Fábio",
        Email = "fab10_lima@hotmail.com",
        Password = "123456789",
        Current_Module = "Ciência da Computação top",
        Status = "Studying",
        CreatedAt = new DateTime(2021, 10, 17),
        UpdatedAt = new DateTime(2021, 10, 17),
      }
    };
  }
    public static IEnumerable<Login> LoginTestStudents()
  {
    return new List<Login> {
      new Login {
        Email = "fab10_lima@hotmail.com",
        Password = "123456789",
      }
    };
  }
}