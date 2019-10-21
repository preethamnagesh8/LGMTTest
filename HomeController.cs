using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string name)
        {
            SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
            conn.Open();

            SqlCommand command = new SqlCommand("Select id from [table1] where name=" + name, conn);
            command.Parameters.AddWithValue("@zip", "india");
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["id"]));
                }
            }

            conn.Close();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
