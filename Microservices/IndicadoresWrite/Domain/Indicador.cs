using System;

namespace IndicadoresWrite.Domain
{
    public class Indicador
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string NomeIndicador { get; set; }
        public decimal PorcentagemGanha { get; set; }
        public decimal Valor { get; set; }
    }
}