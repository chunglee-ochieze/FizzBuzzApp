using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Serilog.Events;

namespace FizzBuzzApp.Data
{
    public static class FizzBuzz
    {
        public static List<string> GetFizzBuzz(int number = 0)
        {
            var response = new List<string>();

            try
            {
                if (number == 0)
                    number = 100;//this can be made to be an input, to improve the dynamics of the implementation

                if (number >= 0)
                {
                    for (var i = 1; i <= number; i++)
                    {
                        response.Add(FizzBuzzGenerator(i));
                    }

                    LogHandler.WriteLog("FizzBuzz generated successfully.", LogEventLevel.Information);
                }
                else
                    response.Add("negative");
            }
            catch (Exception ex)
            {
                LogHandler.WriteLog(ex.Message, LogEventLevel.Error);
                response.Add("error");
            }

            return response;
        }

        public static string FizzBuzzGenerator(int i)
        {
            return i switch
            {
                _ when i % 15 == 0 => "fizz buzz",
                _ when i % 5 == 0 => "buzz",
                _ when i % 3 == 0 => "fizz",
                _ => i.ToString()
            };
        }
    }
}
