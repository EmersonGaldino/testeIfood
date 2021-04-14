using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ifood.test.galdino.domain.Entity.Response;
using ifood.test.galdino.domain.Entity.User;
using ifood.test.galdino.domain.Infraestructure;
using ifood.test.galdino.domain.Infraestructure.Auth;
using ifood.test.galdino.domain.Utils.Enum;
using ifood.test.galdino.service.Interface;
using ifood.test.galdino.service.Interface.User;

namespace ifood.test.galdino.service.User
{
    public class UserService : IUserService
    {
        #region .::Constructor
        private readonly Authentication authentication;
        private readonly IWebRequestService webRequestService;
        public UserService(Infraestructure configs, IWebRequestService webRequestService)
        {
            this.authentication = configs.Authentication;
            this.webRequestService = webRequestService;
        } 
        #endregion

        #region .::Methods
        public async Task<RepsonseAuth> Post(UserEntity user)=>
            await webRequestService.RequestJsonSerialize<RepsonseAuth>(
                      $"{authentication.BaseHost}{authentication.Url}", null, ETypeMethod.POST, Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user.Login}:{user.Password}")), null, null);


        #endregion
    }
}
