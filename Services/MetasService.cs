using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_DavidRosario.DAL;
using Parcial1_Ap1_DavidRosario.Models;
using System.Linq.Expressions;

namespace Parcial1_Ap1_DavidRosario.Services
{
	public class MetasService
	{
		private readonly Contexto _contexto;

        public MetasService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Crear(Metas meta)
        {
            if (!await Existe(meta.MetaId))
                return await Insertar(meta);
            else
				return await Modificar(meta);
		}
		private async Task<bool> Existe(int id)
		{
			return await _contexto.Metas.AnyAsync(m => m.MetaId == id);
		}
		private async Task<bool> Insertar(Metas meta)
		{
			_contexto.Metas.Add(meta);
			return await _contexto.SaveChangesAsync() > 0;
		}
		private async Task<bool> Modificar(Metas meta)
		{
			_contexto.Metas.Update(meta);
			var modifico = await _contexto.SaveChangesAsync() > 0;
			_contexto.Entry(meta).State = EntityState.Detached;
			return modifico;
		}
		public async Task<bool> Eliminar(Metas meta)
		{
			var elimino = _contexto.Metas
				.Where(m => m.MetaId == meta.MetaId).ExecuteDeleteAsync();

			return await elimino > 0;
		}
		public async Task<Metas?> Buscar(int id)
		{
			return await _contexto.Metas
				.AsNoTracking()
				.Where(m => m.MetaId == id)
				.FirstOrDefaultAsync();
		}

		public async Task<Metas?> BuscarDescripcion(string descripcion)
		{
			return await _contexto.Metas
				.AsNoTracking()
				.Where(m => m.Descripcion == descripcion)
				.FirstOrDefaultAsync();
		}
		public async Task<List<Metas>> Listar(Expression<Func<Metas,bool>> criterio)
		{
			return await _contexto.Metas
				.AsNoTracking()
				.Where(criterio)
				.ToListAsync();
		}
	}
}
