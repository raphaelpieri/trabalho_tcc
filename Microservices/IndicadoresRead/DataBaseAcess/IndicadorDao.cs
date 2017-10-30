using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using IndicadoresRead.Domain;
using Microsoft.Extensions.Configuration;

namespace IndicadoresRead.DataBaseAcess
{
    public class IndicadorDao
    {
        private readonly IConfiguration _configuration;

        public IndicadorDao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Indicador> Obter()
        {
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("Microservice")))
            {
                return conexao.Query<Indicador>("SELECT Id, Sigla, NomeIndicador, PorcentagemGanha, Valor " +
                                                "FROM dbo.Indicadores ");
            }
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