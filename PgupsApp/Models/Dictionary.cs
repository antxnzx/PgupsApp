using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    [Table("dictionaries")]
    public class Dictionary
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        [Column("DictionaryName")]
        public string Name { get; set; }
    }
}
