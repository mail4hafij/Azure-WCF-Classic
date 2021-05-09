using System.Configuration;

namespace SRC
{
    public class StaticConfig : IStaticConfig
    {
        public StaticConfig()
        {
            var helloWorld = ConfigurationManager.ConnectionStrings["HelloWorld"];
            ConnectionStringHelloWorld = helloWorld?.ConnectionString;

            var loremIpsum = ConfigurationManager.ConnectionStrings["LoremIpsum"];
            ConnectionStringLoremIpsum = loremIpsum?.ConnectionString;

            var mysql = ConfigurationManager.ConnectionStrings["mysql"];
            ConnectionStringMySQL = mysql?.ConnectionString;
        }

        public string ConnectionStringHelloWorld { get; protected set; }

        public string ConnectionStringLoremIpsum { get; protected set; }

        public string ConnectionStringMySQL { get; protected set; }
    }
}
