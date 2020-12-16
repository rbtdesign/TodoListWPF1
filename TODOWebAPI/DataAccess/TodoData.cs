using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                cmd.Connection = con;
                con.Open();

                //SqlDataReader output = cmd.ExecuteReader();


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


    }
}