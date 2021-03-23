using System;
using MySqlConnector;
namespace ocmariadbconnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CheckMariaDbConnection objTest = new CheckMariaDbConnection();
            objTest.CheckConn();
        }


    }

    public class CheckMariaDbConnection
    {        
        public void CheckConn()
        {
            while(true)
            {
                try
                {
                    var constr = @"server=localhost;port=3305;database=sampledb;uid=raghav;password=raghav;";
                    using (MySqlConnection conn = new MySqlConnection(constr))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from employee", conn);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
    }
}
