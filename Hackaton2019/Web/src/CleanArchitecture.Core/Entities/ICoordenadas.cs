namespace CleanArchitecture.Core.Entities
{
    public interface ICoordenadas
    {
        double Latitud { get; set; }
        double Longitud { get; set; }
        string Poligono { get; set; }
    }
}