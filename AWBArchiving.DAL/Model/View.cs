using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBArchiving.DAL.Model
{
    [Table("View")]
    public class View
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Database")]
        public int DatabaseId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string TableName { get; set; }
        public string ColumnsCSV { get; set; }
        public string SearchColumnsCSV { get; set; }
        public virtual ArchivingDB Database { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
