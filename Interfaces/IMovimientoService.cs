﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IMovimientoService
    {
        Task<List<Producto>> ObtenerProductosAsync();
        Task RegistrarEntradaSalidaAsync(int productoId, int cantidad, string tipo, int usuarioId);



    }
}
