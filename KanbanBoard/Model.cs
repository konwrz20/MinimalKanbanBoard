using System;

namespace KanbanBoard {
    public static class Model {
        public class Project {
            public Guid           Id           { get; set; }
            public string         Name         { get; set; }
            public DateTimeOffset DeadlineDate { get; set; }
            public string         Description  { get; set; }
        }

        public class Task {
            public Guid           Id           { get; set; }
            public string         Title        { get; set; }
            public Guid           ProjectId    { get; set; }
            public DateTimeOffset DeadlineDate { get; set; }
            public string         Description  { get; set; }
            public Priority       Priority     { get; set; }
            public Status         Status       { get; set; }
        }

        public enum Priority { Low, Medium, High }

        public enum Status { Backlog, ToDo, InProgress, Done }

        public class Person {
            public Guid   Id    { get; set; }
            public string Name  { get; set; }
            public string Image { get; set; }
        }
    }
}