﻿using System;
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
        public async Task Post(Model.Project project, CancellationToken cancellationToken) {
            await _database.Insert(project.ToDocument(), cancellationToken);
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