using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    [Table("answers")]
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        [Column("AnswerId")]
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public int TestId { get; set; }

    }
}
