using System;
using KanbanBoard.Infrastructure;

namespace KanbanBoard.Database {
    public class Project : MongoDocument {
        public string         Name         { get; set; }
        public DateTimeOffset DeadlineDate { get; set; }
        public string         Description  { get; set; }
    }

    public class Task : MongoDocument {
        public string         Title        { get; set; }
        public Guid           ProjectId    { get; set; }
        public DateTimeOffset DeadlineDate { get; set; }
        public string         Description  { get; set; }
        public string         Priority     { get; set; }
        public string         Status       { get; set; }
    }

    public class Person : MongoDocument {
        public string Name  { get; set; }
        public string Image { get; set; }
    }
}