using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel Usuario, int id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuario. UsuarioNome= usuario.UsuarioNome;
                usuario.UsuarioTelefone = usuario.UsuarioTelefone;
                usuario.UsuarioEmail = usuario.UsuarioEmail;
                usuario.UsuarioSenha = usuario.UsuarioSenha;
                
                _dbContext.Usuario.Update(usuario);
                await _dbContext.SaveChangesAsync();
            }
            return usuario;

        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

