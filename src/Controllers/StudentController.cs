using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Tryitter.Requests;
using Tryitter.Repositories;
using Tryitter.Services;
using Tryitter.Models;

namespace Tryitter.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StudentController : ControllerBase, IStudentController
{
  readonly IRepository _repository;

  public StudentController(IRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  [Route("login")]
  public async Task<ActionResult<string>> Login([FromBody] Login login)
  {
    Student? student = await _repository.Login(login);

    if (student == null)
    {
      return NotFound("User not found");
    }

    return TokenGenerator.Generate(student);
  }

  [HttpGet]
  public async Task<ActionResult<Student[]>> GetAllStudents()
  {
    IEnumerable<Student> students = await _repository.GetAll<Student>();

    return Ok(students);
  }

  [HttpGet("{id:int}", Name = "GetStudent")]
  public async Task<ActionResult<Student>> GetStudent(int id)
  {
    Student? student = await _repository.GetOne<Student>(id);

    if (student == null)
    {
      return NotFound("Student not found");
    }

    return Ok(student);
  }

  [HttpPost]
  [Authorize(Policy = "Student")]
  public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
  {
    Student createdStudent = await _repository.Create(student);

    return CreatedAtAction("GetStudent", new { id = createdStudent.Id }, createdStudent);
  }

  [HttpPut]
  [Authorize(Policy = "Student")]
  public async Task<ActionResult<Student>> UpdateStudent([FromBody] Student student)
  {
    await _repository.Update(student);

    return Ok(student);
  }

  [HttpDelete("{id:int}")]
  [Authorize(Policy = "Student")]
  public async Task<ActionResult> DeleteStudent(int id)
  {
    Student? student = await _repository.GetOne<Student>(id);

    if (student == null)
    {
      return NotFound("Student not found");
    }

    await _repository.Delete(student);

    return NoContent();
  }
}