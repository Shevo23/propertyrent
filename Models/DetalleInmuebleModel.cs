namespace InmueblesWeb.Models
{
    public class DetalleInmuebleModel
    {
        public int IdDetalleInmueble { get; set; }
        public int NumRecamaras { get; set; }
        public int NumBanos { get; set; }
        public int NumServicios { get; set; }
        public int NumEstacionamientos { get; set; }
        public int ConAlberca { get; set; }
        public int NumM2 { get; set; }
        public int NumTotal { get; set; }
        public int IdContratoInmueble { get; set; }
        public int IdInmueble { get; set; }
    }
}
