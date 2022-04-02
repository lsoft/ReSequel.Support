using Common;

using DBP = Common.DBProvider;

namespace TestFiles
{
    public class ConstString
    {
        public const string Query1 = "select 1 a";
        public const string Query2 = "select 1 b";

        public const string PartCommon = "select 0;";
        public const string Part1 = "select 1;";
        public const string Part2 = "select 2;";
        public const string Part3 = "select 3;";

        public const string Query3 = PartCommon + Part1;
        public const string Query4 = PartCommon + Part2;
        public const string Query5 = PartCommon + Part3;

        public void Execute()
        {

            var dbp = new DBP();

            dbp.PrepareQuery(Query1);
            dbp.PrepareQuery(Query2);

            dbp.ExecuteNonQuery(Query1);
            dbp.ExecuteNonQuery(Query2);
            dbp.ExecuteNonQuery(Query5);

        }

    }

}
