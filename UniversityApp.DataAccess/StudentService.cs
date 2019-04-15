using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using UniversityApp.Models;

namespace UniversityApp.DataAccess
{

    public class StudentService : EntityService<Student>, IService<Student>
    {

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


        public bool Insert(Student student)
        {
            var factory = DbProviderFactories.GetFactory(_providerName);

            var connection = factory.CreateConnection();
            connection.ConnectionString = _connectionString;
            _adapter = factory.CreateDataAdapter();

            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = $"select * from Student";
            _adapter.SelectCommand = selectCommand;

            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = $"insert into Student([Name], GroupId) Values(\'{student.Name}\', {student.GroupId})";
            _adapter.InsertCommand = insertCommand;

            try
            {
                DataSet data = new DataSet();
                _adapter.Fill(data, "Student");

                data.Tables["Student"].Rows.Add(new object[] { student.Id, student.Name, student.GroupId });

                _adapter.Update(data, "Student");
                _adapter.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }

        public bool Update(int oldItemId, Student newItem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int rowId)
        {
            try
            {
                var factory = DbProviderFactories.GetFactory(_providerName);

                var connection = factory.CreateConnection();
                connection.ConnectionString = _connectionString;
                _adapter = factory.CreateDataAdapter();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "select * from Student";
                _adapter.SelectCommand = selectCommand;

                var deleteCommand = connection.CreateCommand();
                deleteCommand.CommandText = $"delete Student where Id={rowId.ToString()}";

                _adapter.DeleteCommand = deleteCommand;

                var usersCommandBuilder = factory.CreateCommandBuilder();
                usersCommandBuilder.DataAdapter = _adapter;

                
                DataSet data = new DataSet();
                _adapter.Fill(data, "Student");
                
                data.Tables["Student"].Rows[rowId].BeginEdit();

                data.Tables["Student"].Rows[rowId].Delete();

                data.Tables["Student"].Rows[rowId].EndEdit();

                _adapter.Update(data, "Student");
                _adapter.Dispose();

            }
            catch (Exception exception)
            {
               Console.WriteLine(exception.Message);
                //  throw;
                return false;
            }
            return true;
        }
    }
}