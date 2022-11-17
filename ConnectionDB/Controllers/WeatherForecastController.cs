using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionDB.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*        const string conString = "Data Source=desktop-upsr7ng; Integrated Security=SSPI; Initial Catalog=Job_manegment";
        */
        SqlConnection xc;
        SqlCommand xcmd;

        [HttpPost]
        public string Seekerdata([FromBody] WeatherForecast seeker)
        {

            try
            {
                using (xc = new SqlConnection("Data Source=desktop-upsr7ng; Integrated Security=SSPI; Initial Catalog=Job_manegment"))
                {
                    using (xcmd = new SqlCommand(@"INSERT INTO seeker(ID,Name) 
                                            VALUES( @id ,@name)", xc))

                        // xcmd.Connection = xc;
                        /*                    xcmd.CommandType = CommandType.Text;
                                            xcmd.CommandText = @"INSERT INTO seeker(ID,Name) 
                                                    VALUES(@ID,@Name)";
                        */

                        xcmd.Parameters.AddWithValue("@id", seeker.seekerid);
                    xcmd.Parameters.AddWithValue("@name", seeker.seekername);


                    xc.Open();
                    xcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }




        [HttpGet]
        public string ret(int a, string b)
        {
            a = 1;
            b = "a";

            return a + b;
        }
    }

}

/*                        catch (SqlException e)
                                           {
                                               MessgeBox.Show(e.Message.ToString(), "Error Message");
                                           }

                                       }
                                   }*/
/*
                xc = new SqlConnection(conString);
                if (xc.State == ConnectionState.Closed)
                {
                    xc.Open();
                }
*/
/*xcmd = new SqlCommand("seeker", xc);
    xcmd.CommandType = CommandType.StoredProcedure;
    xcmd.Parameters.AddWithValue("@ID", seeker.ID);
    xcmd.Parameters.AddWithValue("@Name", seeker.Name);
    //xc.Open();
    int i = xcmd.ExecuteNonQuery();

    if (i > 0)
    {
        Console.WriteLine("Uer Registered");
    }
    else
    {
        Console.WriteLine("Something went wrong");
    }*/
/*
                xcmd.CommandText = "INSERT INTO seeker(ID, Name) " +
                    "VALUES(@ID, @Name)";

                xcmd.Parameters.Add(new SqlParameter("@ID", seeker.ID));
                xcmd.Parameters.Add(new SqlParameter("@Name", seeker.Name));
                xcmd.ExecuteNonQuery();
                xc.Close();
                }*/
