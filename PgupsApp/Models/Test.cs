using SQLite;

namespace PgupsApp.Models
{
    [Table("tests")]
    public class Test
    {
        [PrimaryKey, AutoIncrement]
        [Column("TestId")]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        [Column("TestName")]
        public string Name { get; set; }


    }
    

    
}
