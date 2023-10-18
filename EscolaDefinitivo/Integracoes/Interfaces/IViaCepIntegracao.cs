using EscolaDefinitivo.Repositorio.Response;

namespace EscolaDefinitivo.Integracoes.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
