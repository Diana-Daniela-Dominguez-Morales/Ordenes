using System.ComponentModel.DataAnnotations;

namespace search.Models
{
    public class OrderHedModel
    {
        //public string username { get; set; }
        //public string password { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string Direccion { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }

    }
}
