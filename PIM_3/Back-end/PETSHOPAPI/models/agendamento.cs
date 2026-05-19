namespace PETSHOPAPI.models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string NomePet { get; set; }
        public string Servico { get; set; }
        public DateTime DataHora { get; set; }
    }
}