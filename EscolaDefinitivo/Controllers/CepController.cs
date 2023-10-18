using EscolaDefinitivo.Integracoes.Interfaces;
using EscolaDefinitivo.Repositorio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDefinitivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;
        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;   
        }

        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> ListarEndereco(string cep) 
        {
           var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if(responseData == null) 
            {
                return BadRequest("Cep não encontrado");
            }
            return Ok(responseData);    
        }
    }
}
