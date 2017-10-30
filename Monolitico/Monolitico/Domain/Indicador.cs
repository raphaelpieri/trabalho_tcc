using System;

namespace Monolitico.Domain
{
    public class Indicador
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string NomeIndicador { get; set; }
        public decimal PorcentagemGanha { get; set; }
        public decimal Valor { get; set; }

        public decimal Ganho => Valor + (Valor * PorcentagemGanha / 100);
    }
}