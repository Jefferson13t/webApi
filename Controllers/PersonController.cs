using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.ViewModel;
using WebApi.Repository;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : ControllerBase {

        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository){
            this._personRepository = personRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add([FromForm] PersonViewModel personView){
            var filePath = Path.Combine("Storage", personView.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            personView.Photo.CopyTo(fileStream);

            var person = new Person(personView.Name, personView.Age, filePath);
            _personRepository.Add(person);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(){
            var employees = _personRepository.Get();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(string id){
            var person = _personRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(person.Photo);

            return File(dataBytes, "image/png");
        }
    }
}