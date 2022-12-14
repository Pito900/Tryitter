using System.Text.Json;
using System.Net;
using Tryitter.Models;
using System.Text;
using Tryitter.Services;
using System.Net.Http.Headers;
using Tryitter.Requests;

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

  [Theory(DisplayName = "POST api/Student deve criar um novo student.")]
  [MemberData(nameof(CreateStudent))]
  
  public async Task TestCreateStudent(Student expectedStudent)
  {
    var content = new StringContent(JsonSerializer.Serialize(expectedStudent), Encoding.UTF8, "application/json");
    var response = await _client.PostAsync(baseURL, content);

    response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
  }
  public static TheoryData<Student> CreateStudent =>
  new ()
  {
    ContextHelper.CreateTestStudents().First()
  };

  [Theory(DisplayName = "PUT api/Student deve Atualizar o student.")]
  [MemberData(nameof(UpdateStudent))]
  public async Task TestUpdateStudent(Student student)
  {
    
    var token = TokenGenerator.Generate(student);
    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    
    var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
    var response = await _client.PutAsync(baseURL, content);

    response.Should().NotBeNull();
  }
  public static TheoryData<Student> UpdateStudent =>
  new ()
  {
    ContextHelper.UpdateTestStudents().First()
  };

  [Theory(DisplayName = "POST api/Student/login deve fazer o login.")]
  [MemberData(nameof(LoginStudent))]
  public async Task TestLoginStudent(Login login)
  {
    var content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");
    var response = await _client.PostAsync("api/Student/login", content);
    
    response.Should().NotBeNull();
  }
  public static TheoryData<Login> LoginStudent =>
  new ()
  {
    ContextHelper.LoginTestStudents().First()
  };
}