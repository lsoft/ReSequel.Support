#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace TestFiles
{
    public class GenericMethod
    {
        public void Check()
        {
            IDataModel dataModel = null;

            dataModel.ExecuteGeneric<GenericMethod>(
                "select 1 a",
                new
                {
                    A = 1,
                    B = 2
                }
                );

            var q = "select 1 a";
            dataModel.ExecuteGeneric<GenericMethod>(
                q,
                new
                {
                    A = 1,
                    B = 2
                }
                );

            const string qc = "select 1 a";
            dataModel.ExecuteGeneric<GenericMethod>(
                qc,
                new
                {
                    A = 1,
                    B = 2
                }
                );
        }
    }
}
