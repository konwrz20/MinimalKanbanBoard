using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KanbanBoard.Database;
using KanbanBoard.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Task = System.Threading.Tasks.Task;

namespace KanbanBoard.Controllers {
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase {
        private readonly IMongoDatabase _database;

        public PersonController(IMongoDatabase database) {
            _database = database;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Person>> Get(CancellationToken cancellationToken) {
            var documents = await _database.GetAll<Person>(cancellationToken: cancellationToken);
            return documents.Select(doc => doc.ToModel());
        }

        [HttpPost]
        public async Task Post(Model.Person person, CancellationToken cancellationToken) {
            await _database.Insert(person.ToDocument(), cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, Model.Person person, CancellationToken cancellationToken) {
            await _database.Update(id, person.ToDocument(), cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken) {
            await _database.Delete<Person>(id, cancellationToken);
        }
    }
}