using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    [Table("questions")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        [Column("QuestionId")]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }


    }
}
