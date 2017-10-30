using System.Collections.Generic;
using IndicadoresRead.DataBaseAcess;
using IndicadoresRead.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IndicadoresRead.Controllers
{
    [Route("/api/[controller]")]
    public class IndicadorController: Controller
    {
        private readonly IndicadorDao _indicadorDao;

        public IndicadorController(IndicadorDao indicadorDao)
        {
            _indicadorDao = indicadorDao;
        }
        
        [HttpGet]
        public IEnumerable<Indicador> Get()
        {
            var indicador = _indicadorDao.Obter();
            return indicador;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Indicador request)
        {
            this._indicadorDao.Inserir(request);
            return Ok(new
            {
                sucess = true,
                retorno = "Sucesso"
            });
        }
        
    }
}