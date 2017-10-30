using System.Data.SqlClient;
using Dapper;
using IndicadoresWrite.Domain;
using Microsoft.Extensions.Configuration;

namespace IndicadoresWrite.DataBaseAcess
{
    public class IndicadorDAO
    {
        private readonly IConfiguration _configuration;

        public IndicadorDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void Inserir(Indicador indicador)
        {
            
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("Microservice")))
            {

                conexao.Execute("INSERT INTO dbo.Indicadores (Id, Sigla, NomeIndicador, PorcentagemGanha, Valor) VALUES (@Id, @Sigla, @NomeIndicador, @PorcentagemGanha, @Valor)",
                    indicador);
            }
        }
    }
}