using ifood.test.galdino.repository.Context;
using ifood.test.galdino.repository.Interface.User;

namespace ifood.test.galdino.repository.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        #region .::Constructor
        private readonly DbContext context;
        public UserRepository(DbContext context)
        {
            this.context = context;
        } 
        #endregion
    }
}
