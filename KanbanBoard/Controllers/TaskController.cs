using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KanbanBoard.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TaskDocument = KanbanBoard.Database.Task;

namespace KanbanBoard.Controllers {
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase {
        private readonly IMongoDatabase _database;

        public TaskController(IMongoDatabase database) {
            _database = database;
        }

        [HttpGet("{projectId}")]
        public async Task<IEnumerable<Model.Task>> Get(Guid projectId, CancellationToken cancellationToken) {
            var documents =
                await _database.GetAll<TaskDocument>(document => document.ProjectId == projectId, cancellationToken);
            return documents.Select(doc => doc.ToModel());
        }

        [HttpPost]
        public async Task Post(Model.Task task, CancellationToken cancellationToken) {
            await _database.Insert(task.ToDocument(), cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, Model.Task task, CancellationToken cancellationToken) {
            await _database.Update(id, task.ToDocument(), cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken) {
            await _database.Delete<TaskDocument>(id, cancellationToken);
        }
    }
}