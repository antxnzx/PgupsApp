using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    [Table("abbreviations")]
    public class AbbreviationModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public int DictionaryId { get; set; }
    }
}
