using SQLite;

namespace NOTATNIK.Models.Database
{
    /// <summary> 
    /// Klasa pomocnicza do bazy danych.
    /// </summary> 
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
