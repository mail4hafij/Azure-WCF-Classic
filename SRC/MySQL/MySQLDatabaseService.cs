using log4net;
using System;
using System.Data.Common;
using SRC.LIB;
using MySql.Data.MySqlClient;

namespace SRC.MySQL
{
    public class MySQLDatabaseService : DatabaseService, IMySQLDatabaseService
    {
        private readonly IStaticConfig _staticConfig;
        private static readonly ILog Log = LogManager.GetLogger(typeof(MySQLDatabaseService));

        public MySQLDatabaseService(IStaticConfig staticConfig)
        {
            _staticConfig = staticConfig;
        }

        public override string Name()
        {
            return "mysql";
        }

        public override DbConnection Create()
        {
            return new MySqlConnection(_staticConfig.ConnectionStringMySQL);
        }

        public override void Open(DbConnection con)
        {
            con.Open();
        }

        public override void Close(DbConnection con)
        {
            try
            {
                con?.Close();
            }
            catch (Exception exc)
            {
                Log.Error("Error when closing connection", exc);
            }
        }
    }
}
