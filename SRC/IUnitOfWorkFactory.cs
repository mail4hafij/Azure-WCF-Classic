using SRC.HelloWorld;
using SRC.LoremIpsum;
using SRC.MySQL;

namespace SRC
{
    public interface IUnitOfWorkFactory
    {
        IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true);

        ILoremIpsumUnitOfWork CreateAndBeginTransactionForLoremIpsum(bool useChangeTracking = true);

        IMySQLUnitOfWork CreateAndBeginTransactionForMySQL(bool useChangeTracking = true);

    }
}
