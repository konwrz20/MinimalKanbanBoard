using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KanbanBoard.Controllers {
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Project>> Get() {
            return null;
        }

        [HttpPost]
        public async Task Post(Models.Project project) { }

        [HttpPut("{id}")]
        public async Task Put(long id, Models.Project project) { }

        [HttpDelete("{id}")]
        public async Task Delete(long id) { }
    }
}