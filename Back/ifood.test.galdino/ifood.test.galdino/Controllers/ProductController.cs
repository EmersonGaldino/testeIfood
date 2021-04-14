using ifood.test.galdino.api.Controllers.Base;
using ifood.test.galdino.domain.Entity.Product;
using ifood.test.galdino.service.Interface.Product;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ifood.test.galdino.api.Models.Product;


namespace ifood.test.galdino.api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : BaseController
    {
        private IProductService productService => GetService<IProductService>();
        private IMapper mapper => GetService<IMapper>();

        [HttpGet]
        [SwaggerOperation(Summary = "Listar produtos", Description = "Lista ade produtos cadastrados")]
        [SwaggerResponse(200, "Lista de produtos", typeof(List<ProductEntity>))]
        public async Task<IActionResult> Get()
        {
            try
            {

                return await AutoResult(async () => await productService.GetAll());

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna produto unico", Description = "traz apenas o produto selecionado")]
        [SwaggerResponse(200, "Lista um produto", typeof(List<ProductEntity>))]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var data = await productService.GetOne(id);

                return data == null ? NoContent() : Success(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria produto", Description = "Cria um produto e retorna seu id")]
        [SwaggerResponse(200, "Produto criado", typeof(List<ProductEntity>))]
        public async Task<IActionResult> Post([FromBody] ProductViewModel model)
        {
            try
            {
                var data = await productService.Post(new ProductEntity { description = model.Description, image = model.Image, value = model.Value });

                return data == 0 ? NoContent() : Success(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Altera produto unico", Description = "Altera apenas o produto enviado")]
        [SwaggerResponse(200, "Produto alterado com sucesso", typeof(ProductEntity))]
        public async Task<IActionResult> Put(int id, [FromBody] ProductViewModel model)
        {
            try
            {
                return await productService.Put(
                    new ProductEntity
                    {
                        description = model.Description, 
                        image = model.Image,
                        value = model.Value, 
                        id = id, dateupdate = DateTime.Now,
                        active = model.Active
                    }) ? Success()  : NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta produto unico", Description = "Deleta apenas o produto enviado")]
        [SwaggerResponse(200, "Produto deletado com sucesso", typeof(ProductEntity))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                return await productService.Delete(id) ? NoContent() : Success();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
