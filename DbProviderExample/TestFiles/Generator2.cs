#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace TestFiles
{
    public class BaseGenerator2
    {
        protected const string Part2OptionName = "part2";
    }

    public class Generator2 : BaseGenerator2
    {
        public void Check()
        {
            var dbp = new DBProvider();

            var generator = dbp
                .WithGenerator();
            generator
                .WithQuery("select 1 {0} {1} {2} {3} {4} {5} {6} {7} {8} {9}")
                .DeclareOption("1", "union", "except")
                .DeclareOption("2", "select 2", "select 20")
                .DeclareOption("3", "except", "union")
                .DeclareOption("4", "select 3", "select 30")
                .DeclareOption("5", "except", "union")
                .DeclareOption("6", "select 4", "select 40")
                .DeclareOption("7", "except", "union")
                .DeclareOption("8", "select 5", "select 50")
                .DeclareOption("9", "except", "union")
                .DeclareOption("10", "select 6", "select 60")
                ;

        }
    }
}
