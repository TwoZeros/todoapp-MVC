using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using todoapp.Models;
using todoapp.Repository.Interfaces;

namespace todoDap.Repositories
{
    public class TodoRepository : IRepository<TaskTodo>
    {
        private string connetcionString;
        public TodoRepository()
        {
            connetcionString = @"Server=ANDREY-PC\SQLEXPRESS;Database=todo-data;Trusted_Connection=True;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connetcionString);
            }
        }
     

        public void Create(TaskTodo item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sQuery = @"INSERT INTO TaskTodo(Name, Date, Description, Completed) VALUES(@Name, @Date, @Description, @Completed)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }

        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sQuery = @"Delete from TaskTodo where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskTodo> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sQuery = @"Select * from TaskTodo";
                dbConnection.Open();
                return dbConnection.Query<TaskTodo>(sQuery);
            }
        }

        public TaskTodo GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sQuery = @"Select * from TaskTodo where Id=@Id";
                dbConnection.Open();
                return dbConnection.Query<TaskTodo>(sQuery, new { Id= id }).FirstOrDefault();
            }
        }

     
        public void Update(TaskTodo item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sQuery = @"UPDATE TaskTodo SET Name=@Name,Date=@Date,Description=@Description,Completed=@Completed where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }
    }

}