using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MinimalKanbanBoard.Database;
using MinimalKanbanBoard.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Task = System.Threading.Tasks.Task;

namespace MinimalKanbanBoard.Controllers {
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase {
        private readonly IMongoDatabase _database;

        public ProjectController(IMongoDatabase database) {
            _database = database;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Project>> Get(CancellationToken cancellationToken) {
            var documents = await _database.GetAll<Project>(cancellationToken: cancellationToken);
            return documents.Select(doc => doc.ToModel());
        }

        [HttpPost]
        public async Task<Model.Project> Post(Model.Project project, CancellationToken cancellationToken) {
            project.Id = Guid.NewGuid();
            await _database.Insert(project.ToDocument(), cancellationToken);
            return project;
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, Model.Project project, CancellationToken cancellationToken) {
            await _database.Update(id, project.ToDocument(), cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken) {
            await _database.Delete<Project>(id, cancellationToken);
        }
    }
}