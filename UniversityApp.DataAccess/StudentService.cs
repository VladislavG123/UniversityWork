using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Configuration;
using UniversityApp.Models;

namespace UniversityApp.DataAccess
{
    public class StudentService
    {
        readonly string _providerName;
        readonly string _connectionString;

        public StudentService()
        {
            _providerName = ConfigurationManager.ConnectionStrings["appConnection"].ProviderName;
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

        }

        public List<Student> Select()
        {
            var factory = DbProviderFactories.GetFactory(_providerName);
            var connection = factory.CreateConnection();

            connection.ConnectionString = _connectionString;

            var adapter = factory.CreateDataAdapter();


            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = "select * from Student";
            adapter.SelectCommand = selectCommand;

            DataSet data = new DataSet();

            adapter.Fill(data, "Student");

            List<Student> tablesData = new List<Student>();
            
            for (int i = 0; i < data.Tables["Student"].Rows.Count; i++)
            {
                tablesData.Add(new Student
                {
                    Id = (int)data.Tables["Student"].Rows[i]["Id"],
                    Name = data.Tables["Student"].Rows[i]["Name"].ToString(),
                    GroupId = (int)data.Tables["Student"].Rows[i]["GroupId"],
                }
                );
            }
            adapter.Dispose();
            return tablesData;
        }


        public bool Insert(string name, int groupId)
        {
            var factory = DbProviderFactories.GetFactory(_providerName);
            var connection = factory.CreateConnection();

            connection.ConnectionString = _connectionString;

            var adapter = factory.CreateDataAdapter();


            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = $"insert into Student(Name, GroupId) VALUES({name},{groupId})";
            adapter.InsertCommand = insertCommand;

            DataSet data = new DataSet();

            adapter.Fill(data, "Student");
            
        }


    }
}

