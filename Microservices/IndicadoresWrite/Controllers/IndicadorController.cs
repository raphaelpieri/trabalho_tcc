using System;
using IndicadoresWrite.DataBaseAcess;
using IndicadoresWrite.Domain;
using IndicadoresWrite.Integracao;
using Microsoft.AspNetCore.Mvc;

namespace IndicadoresWrite.Controllers
{
    [Route("/api/[controller]")]
    public class IndicadorController: Controller
    {
        private readonly IndicadorDAO _indicadorDao;
        private readonly IndicadoresIntegracao _integracao;

        public IndicadorController(IndicadorDAO indicadorDao, IndicadoresIntegracao integracao)
        {
            _indicadorDao = indicadorDao;
            _integracao = integracao;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Indicador request)
        {
            request.Id = Guid.NewGuid();
            _indicadorDao.Inserir(request);
            _integracao.EnviarIndicador(request);
            return Ok(new
            {
                sucess = true,
                retorno = "Sucesso"
            });
        }
    }
}