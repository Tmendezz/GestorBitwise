﻿using System;
using System.Collections.Generic;

namespace GestorBitwise.ENTITY;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
