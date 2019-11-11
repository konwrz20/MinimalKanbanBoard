using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KanbanBoard.Controllers {
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Person>> Get() {
            return null;
        }

        [HttpPost]
        public async Task Post(Model.Person person) { }

        [HttpPut("{id}")]
        public async Task Put(long id, Model.Person person) { }

        [HttpDelete("{id}")]
        public async Task Delete(long id) { }
    }
}