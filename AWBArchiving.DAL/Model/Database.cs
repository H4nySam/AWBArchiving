using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBArchiving.DAL.Model
{
    public class ArchivingDB
    {
        [Key]
        public int Id { get; set; }
        public string DBName { get; set; }
        public string ConnString { get; set; }
        public virtual ICollection<View> Views { get; set; }

    }
}
