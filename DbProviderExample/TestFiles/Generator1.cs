#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Generator;

namespace TestFiles
{
    public class Generator1
    {
        public void Check()
        {
            var dbp = new DBProvider();

            Declarator generator = dbp
                .WithGenerator();
            var q = generator
                .WithQuery(@"
select 1 {0} {1} {2} {3} {4} {5} {6} {7} where 1 = @val1
GO
select 1 {0} {1} {2} {3} {4} {5} {6} {7} where 1 = @val2
")
                .DeclareOption("1", "union", "except")
                .DeclareOption("2", "select 2", "select 20", "select 200", "select 2000")
                .DeclareOption("3", "except", "union")
                .DeclareOption("4", "select 3", "select 30", "select 300", "select 3000")
                .DeclareOption("5", "except", "union")
                .DeclareOption("6", "select 4", "select 40", "select 400", "select 4000")
                .DeclareOption("7", "except", "union")
                .DeclareOption("8", "select 5", "select 50", "select 500", "select 5000")
                .MakeGenerator()
                .BindToOption("terminalType", true)
                .GenerateSql();

        }
    }
}
