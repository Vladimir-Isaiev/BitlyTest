using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace BitlyTest.Infrastructure
{
    public class Record
    {
        [Key]
        public int ID { get; set; }
        public string FullRecord { get; set; }       
        public DateTime CreatedDate { get; set; }

        public Record()
        {
            FullRecord = "full";            
            CreatedDate = DateTime.Now;
        }


        public static bool operator >(Record r1, Record r2)
        {
            return r1.ID > r2.ID;
        }
        public static bool operator <(Record r1, Record r2)
        {
            return r1.ID < r2.ID;
        }
    }
}
