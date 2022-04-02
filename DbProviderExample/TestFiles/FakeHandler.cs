using Common;

namespace TestFiles
{
    public class FakeHandler
    {
        public void Execute()
        {
            var fdbp = new FakeDbProvider();

            fdbp.SqlText = "select 10 a union all select 20";
            fdbp.PrepareQuery("select 1 a \r\nunion all \r\nselect 2 a");
        }

    }


}
