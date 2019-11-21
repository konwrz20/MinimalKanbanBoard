using System;
using MinimalKanbanBoard.Database;

namespace MinimalKanbanBoard {
    public static class Mapper {
        public static Model.Person ToModel(this Person p) =>
            new Model.Person {Id = p.Id, Name = p.Name, Image = p.Image};

        public static Person ToDocument(this Model.Person p) => new Person {Id = p.Id, Name = p.Name, Image = p.Image};

        public static Model.Task ToModel(this Task t) =>
            new Model.Task {
                Id           = t.Id,
                Name         = t.Name,
                ProjectId    = t.ProjectId,
                DeadlineDate = t.DeadlineDate,
                Description  = t.Description,
                Priority     = Enum.Parse<Model.Priority>(t.Priority, ignoreCase: true),
                Status       = Enum.Parse<Model.Status>(t.Status, ignoreCase: true),
            };

        public static Task ToDocument(this Model.Task t) =>
            new Task {
                Id           = t.Id,
                Name         = t.Name,
                ProjectId    = t.ProjectId,
                DeadlineDate = t.DeadlineDate,
                Description  = t.Description,
                Priority     = t.Priority.ToString(),
                Status       = t.Status.ToString(),
            };

        public static Model.Project ToModel(this Project p) =>
            new Model.Project {
                Id = p.Id, Name = p.Name, DeadlineDate = p.DeadlineDate, Description = p.Description,
            };

        public static Project ToDocument(this Model.Project p) =>
            new Project {
                Id = p.Id, Name = p.Name, DeadlineDate = p.DeadlineDate, Description = p.Description,
            };
    }
}