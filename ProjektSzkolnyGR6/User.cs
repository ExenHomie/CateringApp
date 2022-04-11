using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektSzkolnyGR6
{
    public class User
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [MaxLength(30)]
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
    }
}
