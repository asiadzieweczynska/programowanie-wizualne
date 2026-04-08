namespace projekt3
{
    [Serializable]
    public class Osoba
    {
        public int ID { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public int Wiek { get; set; }
        public string Stanowisko { get; set; } = string.Empty;
    }
}
