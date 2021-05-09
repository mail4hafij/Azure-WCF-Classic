using SRC.LIB;
using SRC.HelloWorld;
using SRC.LoremIpsum;
using SRC.MySQL;

namespace SRC
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IHelloWorldDatabaseService _helloWorldDatabaseService;
        private readonly ILoremIpsumDatabaseService _loremIpsumDatabaseService;
        private readonly IMySQLDatabaseService _mySqlDatabaseService;


        public UnitOfWorkFactory(IHelloWorldDatabaseService helloWorld, ILoremIpsumDatabaseService loremIpsum, IMySQLDatabaseService mysql)
        {
            _helloWorldDatabaseService = helloWorld;
            _loremIpsumDatabaseService = loremIpsum;
            _mySqlDatabaseService = mysql;
        }

        public IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true)
        {
            var unitOfWork = new HelloWorldUnitOfWork(_helloWorldDatabaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }

        
        public ILoremIpsumUnitOfWork CreateAndBeginTransactionForLoremIpsum(bool useChangeTracking = true)
        {
            var unitOfWork = new LoremIpsumUnitOfWork(_loremIpsumDatabaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }

        public IMySQLUnitOfWork CreateAndBeginTransactionForMySQL(bool useChangeTracking = true)
        {
            var unitOfWork = new MySQLUnitOfWork(_mySqlDatabaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }

    }
}
