using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Controllers {
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase {
        [HttpGet("{projectId}")]
        public async Task<IEnumerable<Models.Task>> Get(long projectId) {
            return null;
        }

        [HttpPost]
        public async Task Post(Models.Task task) { }

        [HttpPut("{id}")]
        public async Task Put(long id, Models.Task task) { }

        [HttpDelete("{id}")]
        public async Task Delete(long id) { }
    }
}