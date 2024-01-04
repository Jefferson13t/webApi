using Microsoft.AspNetCore.Http;

namespace WebApi.ViewModel
{
    public class PersonViewModel{
        public string Name { get; set; }
        public int Age { get; set; }

        public IFormFile Photo { get; set; }
    }
}