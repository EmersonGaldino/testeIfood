using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using ifood.test.galdino.api.Models.Base;
using ifood.test.galdino.domain.Utils.Exceptions;

namespace ifood.test.galdino.api.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected TService GetService<TService>() => (TService)HttpContext.RequestServices.GetService(typeof(TService));
        protected IActionResult Success(object data = null) => Ok(new SuccessResponse<object>(data));
        protected async Task<IActionResult> AutoResult<T>(Func<Task<T>> func)
        {
            try
            {
                return Ok(await func());
            }
            catch (ValidationException validEx)
            {
                var erroBuilder = new StringBuilder();
                foreach (var error in validEx.Errors)
                    erroBuilder.AppendLine(error.ErrorMessage);
                return BadRequest(erroBuilder.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
