using System.Data;

namespace StatkiTUCK
{
    class Statistics
    {
        public DataTable History { get; }

        public Statistics ()
        {
            History = new DataTable();
            DataColumn[] cols =
            {
                new DataColumn("ID", typeof(string)),
                new DataColumn("X", typeof(short)),
                new DataColumn("Y", typeof(short)),
                new DataColumn("TargetHit", typeof(bool))
            };
            cols[0].AutoIncrement = true;
            cols[0].AutoIncrementSeed = 1;
            History.Columns.AddRange(cols);
            
        }

        public void AddEntry(short x, short y, bool hit)
        {
            DataRow dr = History.NewRow();
            dr["X"] = x;
            dr["Y"] = y;
            dr["TargetHit"] = hit;
            History.Rows.Add(dr);
        }

        public bool AlreadyExists(short x, short y)
        {
            if (History.Select("[X] = '" + x + "' AND [Y] = '" + y +"'").Length > 0)
                return true;
            else return false;
        }

    }
}
