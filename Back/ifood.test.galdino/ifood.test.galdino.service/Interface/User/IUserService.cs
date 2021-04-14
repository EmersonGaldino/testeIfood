using System.Threading.Tasks;
using ifood.test.galdino.domain.Entity.Response;
using ifood.test.galdino.domain.Entity.User;

namespace ifood.test.galdino.service.Interface.User
{
    public interface IUserService
    {
        Task<RepsonseAuth> Post(UserEntity user);
    }
}
