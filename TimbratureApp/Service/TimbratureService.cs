namespace TimbratureApp.Service
{
    public class TimbratureService
    {
        public List<TimbraturaPersona> Timbrature { get; } = new List<TimbraturaPersona>();
    }

    public class TimbraturaPersona
    {
        public DateTime DataOra { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public int IdUtente { get; set; }
    }
}
