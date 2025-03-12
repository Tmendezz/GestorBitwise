using System;
using System.Collections.Generic;

namespace GestorBitwise.ENTITY;

public partial class DetalleVenta
{
    public int Id { get; set; }

    public int? Ventaid { get; set; }

    public int? ProductoId { get; set; }

    public string? MarcaProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public string? CategoriaProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Venta? Venta { get; set; }
}
