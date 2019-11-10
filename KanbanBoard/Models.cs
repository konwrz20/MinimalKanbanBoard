using System;
using Microsoft.AspNetCore.Identity;

namespace KanbanBoard {
    public class Models {
        public class Project {
            public long           Id           { get; set; }
            public string         Name         { get; set; }
            public DateTimeOffset DeadlineDate { get; set; }
            public string         Description  { get; set; }
        }

        public class Task {
            public long           Id           { get; set; }
            public string         Title        { get; set; }
            public long           ProjectId    { get; set; }
            public DateTimeOffset DeadlineDate { get; set; }
            public string         Description  { get; set; }
            public Priority       Priority     { get; set; }
            public Status         Status       { get; set; }
        }

        public enum Priority { Low, Medium, High }

        public enum Status { Backlog, ToDo, InProgress, Done }

        public class Person {
            public long   Id    { get; set; }
            public string Name  { get; set; }
            public string Image { get; set; }
        }
    }
}