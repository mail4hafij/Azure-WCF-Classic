using System.Collections.Generic;
using System.Linq;
using SRC.LIB;

namespace SRC.HelloWorld.Repository.Cat
{
    public class CatRepository : HelloWorldBaseRepository, ICatRepository
    {
        public CatRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {
            // Construct the repository with a given unitOfWork/dbContext.
        }

        public List<SRC.HelloWorld.Data.Model.Cat> LoadAll()
        {
            // Always return DB models (no hidding here).
            return _unitOfWork.Context.Cats.OrderByDescending(c => c.CatId).ToList<Data.Model.Cat>();
        }

        public void Add(SRC.HelloWorld.Data.Model.Cat cat)
        {
            _unitOfWork.Context.Cats.Add(cat);
        }
    }
}
