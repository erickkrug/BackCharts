namespace RechartsAPI.Models
{
    public class AtdParametroModel
    {
        public int EmpresaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<int> Servicos { get; set; }

    }
}
