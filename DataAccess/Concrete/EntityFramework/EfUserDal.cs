using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOpertionClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOpertionClaim.OperationClaimId
                             where userOpertionClaim.UserId == user.Id
                             select new OperationClaim() { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
