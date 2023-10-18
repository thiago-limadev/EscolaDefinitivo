using EscolaDefinitivo.Repositorio.Response;
using Refit;

namespace EscolaDefinitivo.Repositorio.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]

        Task<ApiResponse<ViaCepResponse>> ObterDados(string cep);  
    }
}
