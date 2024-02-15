using Microsoft.Data.SqlClient;
using TodoApp.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TodoApp.Models
{
    public class DAL
    {
        public Response GetAllTodos(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from todo", connection);
            DataTable dt = new DataTable();
            List<Todo> lstTodos = new List<Todo>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Todo todo = new Todo();

                    todo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);

                    todo.Title= Convert.ToString(dt.Rows[i]["Title"]);

                    todo.DueOn = Convert.ToDateTime(dt.Rows[i]["DueOn"]);
                    todo.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);

                    todo.Descrip = Convert.ToString(dt.Rows[i]["Descrip"]);
             
                    todo.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);




                    lstTodos.Add(todo);
                    


                }
            }
            if (lstTodos.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listTodo = lstTodos;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.listTodo = null;

            }
            return response;
        }

        public Response AddTodo(SqlConnection connection, Todo todo)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO todo (Descrip,IsActive,Title,DueOn,CreatedOn) VALUES('" + todo.Descrip + "','" + todo.IsActive + "','" + todo.Title + "','" + todo.DueOn + "',GETdATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Todo added.";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";


            }
            return response;

        }

        public Response DeleteTodo(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from todo WHERE Id = '" + id + "' ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Todo Deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Todo deleted fail";


            }
            return response;

        }

        public Response UpdateTodo(SqlConnection connection, Todo todo)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("UPDATE todo SET Descrip='" + todo.Descrip + "', Title='" + todo.Title + "', IsActive='" + todo.IsActive + "',DueOn='" + todo.DueOn + "' WHERE Id = '" + todo.Id + "'", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Todo updated.";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No todo updated";


            }
            return response;

        }

       
    }
}
