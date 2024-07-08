using ApiVentas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVentas.DTOs
{
    public class CompraDTO
    {
        public string NumeroCompra { get; set; }
        public decimal Total { get; set; }
        public int IdDireccion { get; set; }
        public int IdTarjeta { get; set; }
        public List<DetalleCompraDTO> RefDetalleCompra { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
