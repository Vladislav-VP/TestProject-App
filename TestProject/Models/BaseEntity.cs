﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Entities
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public DateTime CreationDateTime { get; set; }
    }
}
