using System;
using System.Collections.Generic;

namespace GestorBitwise.ENTITY;

public partial class Venta
{
    public int Id { get; set; }

    public string? NumeroVenta { get; set; }

    public string? DocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
