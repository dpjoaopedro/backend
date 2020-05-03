using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Data;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/users")]
    public class EscolaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] DataContext context)
        {
            try
            {
                var users = await context.Escolas.ToListAsync();

                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Não foi resgatar escolas");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] DataContext context,
            int id)
        {
            try
            {
                var user = await context.Escolas.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Não foi possível resgatar escola");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(
                    [FromServices] DataContext context,
                    [FromBody]Escola model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                model.Ativo = true;
                context.Escolas.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Não foi possível incluir a escola");
            }
        }

        [HttpDelete("{id}")]
        [Route("")]
        public async Task<IActionResult> Delete(
                    [FromServices] DataContext context,
                    int id)
        {
            try
            {
                var user = await context.Escolas.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return NotFound();

                context.Escolas.Remove(user);
                await context.SaveChangesAsync();
                return Ok("escola removida com sucesso!");
            }
            catch
            {
                return StatusCode(500, "Não foi possível deletar a escola");
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(
                    [FromServices] DataContext context,
                    [FromBody]Escola model)
        {
            try
            {
                var user = await context.Escolas.FirstOrDefaultAsync(x => x.Id == model.Id);

                user.Nome = model.Nome;
                user.Ativo = model.Ativo;

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (user == null)
                    return NotFound();

                context.Escolas.Update(user);
                await context.SaveChangesAsync();
                return Ok("escola atualizado com sucesso!");
            }
            catch
            {
                return StatusCode(500, "Não foi possível deletar o escola");
            }
        }
    }
}