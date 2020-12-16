using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TODOWebAPI.Models;

namespace TODOWebAPI.DataAccess
{
    public class TodoData
    {
        public List<TodoModel> GetAllTodos()
        {

            List<TodoModel> output = new List<TodoModel>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

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

                        output.Add(new TodoModel(id, title, isCompleted));

                    }
                }

            }

            return output;

        }

        public TodoModel GetTodoById(int id)
        {

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetTodoById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {

                    string title = dataReader["Title"].ToString();
                    bool isCompleted = (bool)dataReader["IsCompleted"];

                    return new TodoModel(id, title, isCompleted);
                }
            }
        }


        public int AddTodo(string title)
        {

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddTodo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);


                //SqlParameter outputParam = new SqlParameter();
                //outputParam.ParameterName = "@Id";
                //outputParam.SqlDbType = SqlDbType.Int;
                //outputParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outputParam);

                con.Open();

                int id = (int)cmd.ExecuteScalar();

                return id;

            }
        }


        public int DeleteTodoById(int id)
        {

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTodoById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();

                int response = cmd.ExecuteNonQuery();

                return response;

            }
        }

    }
}