using GestorBitwise.BLL.Interfaces;
using GestorBitwise.DAL.Interfaces;
using GestorBitwise.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorBitwise.BLL.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _context;

        public CategoriaService(IGenericRepository<Categoria> context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> Lista()
        {
            IQueryable<Categoria> query = await _context.Consultar();
            return query.ToList();
        }
        public async Task<Categoria> Crear(Categoria entidad)
        {
            try
            {
                Categoria categoriaCreada = await _context.Crear(entidad);
                if (categoriaCreada.Id == 0)
                    throw new TaskCanceledException("No se pudo crear la Categoria");

                return categoriaCreada;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> Editar(Categoria entidad)
        {
            try
            {
                Categoria categoriaEncontrada = await _context.Obtener(c => c.Id == entidad.Id);
                //mapeo de forma manual, sin automapper, ya que son solo dos entidades
                categoriaEncontrada.Descripcion = entidad.Descripcion;
                categoriaEncontrada.EsActivo = entidad.EsActivo;

                bool respuesta = await _context.Editar(categoriaEncontrada);
                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar la Categoria");

                return categoriaEncontrada;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                Categoria categoriaEncontrada = await _context.Obtener(c => c.Id == id);

                if (categoriaEncontrada == null)
                    throw new TaskCanceledException("La Categoria que desea eliminar no existe");

                bool respuesta = await _context.Eliminar(categoriaEncontrada);

                return respuesta;
            }
            catch
            {
                throw;
            }
        }


    }
}
