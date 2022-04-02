using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace TestFiles
{
    public class ExtensionMethod
    {
        public void CheckExtension()
        {
            var dbp = new DBProvider();

            dbp.ExecuteExtension(
                1,
                "select 1 union select 2",
                2);
        }
    }
}
