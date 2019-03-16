namespace SharedModels
{
    public class LaborModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Fase { get; set; }
        public string Fecha { get; set; }
    }

    public class LaborSimpleModel
    {
        public int Id { get; set; }
        public string Estado { get; set; }
    }
}
