using Cabelleza.Dados;
using Cabelleza.Dominio.Entidades;
using Cabelleza.web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

[Route("api/[controller]")]
[ApiController]
public class SalaoController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalaoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public async Task<ActionResult<Salao>> CadastrarSalao([FromForm] Salao salao, [FromForm] IFormFile? Imagem)
    {
        Console.WriteLine(salao);

        try
        {
            if (Imagem != null && Imagem.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Imagem.CopyToAsync(memoryStream);
                    salao.Imagem = memoryStream.ToArray();  // Converte a imagem para um array de bytes e armazena no banco
                }
            }

            salao.Guid = Guid.NewGuid();

            _context.Salao.Add(salao);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        return CreatedAtAction(nameof(GetSalao), new { id = salao.Guid }, salao);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginViewModel loginModel)
    {
        if (string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Senha))
        {
            return BadRequest("E-mail e senha são obrigatórios.");
        }

        var salao = await _context.Salao.FirstOrDefaultAsync(s => s.EmailSalao == loginModel.Email);

        if (salao == null)
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        if (salao.Senha != loginModel.Senha)
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        return Ok(new { message = "Login realizado com sucesso", salaoId = salao.Guid });
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<Salao>> GetSalao(Guid id)
    {
        var salao = await _context.Salao.FindAsync(id);

        if (salao == null)
        {
            return NotFound();
        }

        return salao;
    }
}
