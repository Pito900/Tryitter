using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;

namespace Tryitter.Controllers;

public interface IStudentController
{
  public Task<ActionResult<Student[]>> GetAllStudents();
  public Task<ActionResult<Student>> GetStudent(int id);
  public Task<ActionResult<Student>> CreateStudent(Student student);
  public Task<ActionResult<Student>> UpdateStudent(Student student);
  public Task<ActionResult> DeleteStudent(int id);
}