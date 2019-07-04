﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Models
{
    public class TodoItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
