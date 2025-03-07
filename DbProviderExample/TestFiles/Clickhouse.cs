using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFiles
{
    internal class Clickhouse
    {
        public void Method()
        {
            var dbp = new DBProvider();

            dbp.ExecuteNonQuery(@"
select 1
GO
select 2
");

            dbp.ExecuteNonQuery(@"
select * from information_schema.tables
");

            dbp.ExecuteNonQuery(@"
SELECT
    database,
    table,
    formatReadableSize(sum(bytes)) as size
FROM system.parts
WHERE
    active
GROUP BY database, table
ORDER BY table;
");

            dbp.ExecuteNonQuery(@"
select non_existent_column from information_schema.tables
");
        }
    }
}
