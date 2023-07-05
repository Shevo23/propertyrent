namespace InmueblesWeb.Models
{
    public class InmueblesModel
    {
        public int IdInmueble { get; set; }

        public string? NombreInmueble { get; set; }
        public string? Descripcion { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public decimal? CostoTotal { get; set; }
        public decimal? CostoMensual { get; set; }
        public decimal? CostoMto { get; set; }
        public int? Nuevo { get; set; }
        public int? Antiguedad { get; set; }
        public int IdTipoPropiedad { get; set; }
        public int IdAsentamiento { get; set; }
        public int idEstatusInmueble { get; set; }
        public int IdUsuario { get; set; }
    }
}
