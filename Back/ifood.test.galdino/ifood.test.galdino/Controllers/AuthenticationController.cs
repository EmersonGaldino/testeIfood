using ifood.test.galdino.api.Controllers.Base;
using ifood.test.galdino.api.Models.User;
using ifood.test.galdino.domain.Entity.User;
using ifood.test.galdino.service.Interface.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ifood.test.galdino.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        #region .::Constructor
        private IUserService userService => GetService<IUserService>();
        #endregion

        #region .::Methods
        [HttpPost]
        [SwaggerOperation(Summary = "Validar login", Description = "Valida suas credenciais para acesso a aplicação")]
        [SwaggerResponse(200, "Login relalizado com sucesso", typeof(UserEntity))]
        public async Task<IActionResult> Post([FromBody] UserViewModel model)
        {
            try
            {
                var result = await userService.Post(new UserEntity { Password = model.Password, Login = model.Login });
                return Success(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        #endregion
    }
}
