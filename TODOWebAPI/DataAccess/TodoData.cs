using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TODOWebAPI.Models;

namespace TODOWebAPI.DataAccess
{
    public class TodoData : ITodoData
    {

        private readonly string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<TodoDto> GetAllTodos()
        {

            List<TodoDto> output = new List<TodoDto>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTodos", con);
                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string title = dataReader["Title"].ToString();
                        bool isCompleted = (bool)dataReader["IsCompleted"];

                        output.Add(new TodoDto(id, title, isCompleted));

                    }
                }

            }

            return output;

        }

        public TodoDto GetTodoById(int id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetTodoById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    if(dataReader.Read())
                    {
                    string title = (string)dataReader["Title"];
                    bool isCompleted = (bool)dataReader["IsCompleted"];

                    return new TodoDto(id, title, isCompleted);
                    }

                    return null;

                }
            }
        }


        public int AddTodo(string title)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);

                con.Open();

                int id = (int)cmd.ExecuteScalar();

                return id;

            }
        }

        public int UpdateTodo(TodoDto Todo)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Todo.Id);
                cmd.Parameters.AddWithValue("@title", Todo.Title);
                cmd.Parameters.AddWithValue("@isCompleted", Todo.IsCompleted);


                //SqlParameter outputParam = new SqlParameter();
                //outputParam.ParameterName = "@Id";
                //outputParam.SqlDbType = SqlDbType.Int;
                //outputParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outputParam);

                con.Open();

                return cmd.ExecuteNonQuery(); ;

            }
        }

        public int DeleteTodoById(int id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTodoById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();

                return cmd.ExecuteNonQuery();
            }
        }
    }
}