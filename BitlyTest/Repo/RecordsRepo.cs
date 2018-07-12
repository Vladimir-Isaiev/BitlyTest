using BitlyTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitlyTest.Repo
{
    public class RecordsRepo
    {
        RecordContext db;
        public RecordsRepo(RecordContext _dB)
        {
            db = _dB;
        }


        public string GetShortRecord(string fullRecord)
        {
            Uri uri;
            DateTime dateTime = DateTime.Now;

            if (dateTime.Day == 1)
            {
                foreach (Record r in db.Records)
                {
                    if ((dateTime - r.CreatedDate).Days > 7)
                    {
                        db.Records.Remove(r);
                    }
                }
            }

            try
            {
                uri = new Uri(fullRecord);
            }
            catch
            {
                return "Invalid URI";
            }


            foreach (Record r in db.Records)
            {
                if (r.FullRecord == uri.AbsoluteUri)
                {
                    return "http://localhost:54460/" + r.ID.ToString("D6");
                }
            }

            Record record = new Record();
            record.FullRecord = uri.AbsoluteUri;
            record.CreatedDate = dateTime;

            db.Records.Add(record);
            db.SaveChanges();
            //record = db.Records.First(r => r.FullRecord == record.FullRecord);
            return "http://localhost:54460/" + record.ID.ToString("D6");
        }

        public string Route(string shortRecord)
        {
            int idRecord = Convert.ToInt32(shortRecord);
            Uri uri = new Uri(db.Records.First(r => r.ID == idRecord).FullRecord);
            return uri.AbsoluteUri;
        }
    }
}
   