using Common.Generator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDBProvider
    {

        void ExecuteNonQuery(string q);
    }

    public interface IDataModel
    {
        void ExecuteGeneric<T>(string q1, object parameter, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
    }


    public class DBProvider : IDBProvider
    {
        public string SqlText
        {
            get;
            set;
        }

        public void UnrelatedMethod(string q)
        {
        }



        public void PrepareQuery(string q1, string q2)
        {
        }

        public void PrepareQuery(string q)
        {
        }

        public void PrepareQuery(string query, CommandType type)
        {
        }




        public void ExecuteNonQuery(string q)
        {
        }



        public async Task ExecuteQueryAsync(string queryString)
        {
        }

        public void ExecuteQuery(string queryString)
        {
        }

        public void ExecuteQuery(string queryString, int commandTimeout)
        {
        }




        public void ExecuteScaler()
        {
        }

        public void ExecuteScaler(string queryString)
        {
        }

        public Declarator WithGenerator(
            )
        {
            return
                new Declarator();
        }
    }

}

