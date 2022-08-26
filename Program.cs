using System;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ReadJSonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var configurationBuilder = new ConfigurationBuilder ();
            configurationBuilder.SetBasePath (Directory.GetCurrentDirectory ());
            configurationBuilder.AddJsonFile ("testdata.json", optional : true, reloadOnChange : true);
 
            IConfigurationRoot configuration = configurationBuilder.Build ();
 
            Console.WriteLine (configuration.GetConnectionString ("SqlDB"));
            Console.WriteLine (configuration.GetConnectionString ("OracleDB"));
            Console.WriteLine (configuration.GetConnectionString ("MangoDB"));

            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:QA").Value);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:Stage").Value);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest:Prod").Value);

            Console.WriteLine (configuration.GetSection ("ConnectionStrings:SqlDB").Value);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings:OracleDB").Value);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings:MangoDB").Value);
        
            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["SqlDB"]);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["OracleDB"]);
            Console.WriteLine (configuration.GetSection ("ConnectionStrings")["MangoDB"]);

            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest")["QA"]);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest")["Stage"]);
            Console.WriteLine (configuration.GetSection ("ApplicationUnderTest")["Prod"]);
        }
    }
}
