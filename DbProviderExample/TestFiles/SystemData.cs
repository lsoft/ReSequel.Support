using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFiles
{
    class SystemData
    {
        public void Check()
        {
            var cmd1 = new SqlCommand();
            cmd1.CommandText = @"select 10 a 
union all 
select 20";

            var cmd2 = new SqlCommand();
            cmd2.CommandText = @"create table #t (id int)";

            var cmd3 = new SqlCommand();
            cmd3.CommandText = @"declare @t table (id int)";

            var cmd4 = new SqlCommand();
            cmd4.CommandText = string.Format("select {0}", 1);

            var cmd5 = new SqlCommand();
            cmd5.CommandText = @"select 1
where
    @a_b = convert(bit, 1)
    and @b_c_def = ''
    and @ghj = convert(uniqueidentifier, '')
";
        }

    }
}
