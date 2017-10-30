using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monolitico.DataBasesAcess;
using Monolitico.Domain;

namespace Monolitico.Controllers
{
    [Route("/api/[controller]")]
    public class IndicadorController : Controller
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
            request.Id = Guid.NewGuid();
            this._indicadorDao.Inserir(request);
            return Ok(new
            {
                sucess = true,
                retorno = "Sucesso"
            });
        }
    }
}