using System.Text.Json;
using System.Net;
using Tryitter.Models;

namespace Tryitter.Test;

public class StudentTest : IClassFixture<TestApplicatioFactory>
{
  readonly string baseURL = "api/Student";
  readonly HttpClient _client;
  readonly JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };

  public StudentTest(TestApplicatioFactory factory)
  {
    _client = factory.CreateClient();
  }

  [Theory(DisplayName = "GET api/Student deve retornar todos os estudantes")]
  [MemberData(nameof(AllStudents))]
  public async Task TestGetAllStudents(IEnumerable<Student> expectedStudents)
  {
    HttpResponseMessage response = await _client.GetAsync(baseURL);
    Stream streamContent = response.Content.ReadAsStream();
    IEnumerable<Student> students = JsonSerializer.Deserialize<IEnumerable<Student>>(streamContent, serializerOptions)!;

    response.StatusCode.Should().Be(HttpStatusCode.OK);
    students.Should().BeEquivalentTo(expectedStudents);
  }

  public static TheoryData<IEnumerable<Student>> AllStudents =>
    new ()
    {
      ContextHelper.GetTestStudents()
    };

    [Theory(DisplayName = "GET api/Student/1 deve retornar o estudante correto")]
  [MemberData(nameof(OneStudent))]
  public async Task TestGetOneStudent(Student expectedStudent)
  {
    HttpResponseMessage response = await _client.GetAsync($"{baseURL}/1");
    Stream streamContent = response.Content.ReadAsStream();
    Student student = JsonSerializer.Deserialize<Student>(streamContent, serializerOptions)!;

    response.StatusCode.Should().Be(HttpStatusCode.OK);
    student.Should().BeEquivalentTo(expectedStudent);
  }

  public static TheoryData<Student> OneStudent =>
    new ()
    {
      ContextHelper.GetTestStudents().First()
    };
}