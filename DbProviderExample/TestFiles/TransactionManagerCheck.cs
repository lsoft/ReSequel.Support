using Common;
using System.Data.SqlClient;

namespace TestFiles
{
    public class TransactionManagerCheck
    {
        public void Execute()
        {
            var tm = new TransactionManager();

            tm.PrepareQuery("select 1 a \r\nunion all \r\nselect 2 a");
            tm.PrepareQuery("select 1 a" + "\r\nunion all" + "\r\nselect 2 a");
            tm.PrepareQuery(string.Format("select {0}", 1));
        }

    }

}
