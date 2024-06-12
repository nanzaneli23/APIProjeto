using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        private readonly Contexto _dbContext;

        public AnimalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AnimalModel>> GetAll()
        {
            return await _dbContext.Animal.ToListAsync();
        }

        public async Task<AnimalModel> GetById(int id)
        {
            return await _dbContext.Animal.FirstOrDefaultAsync(x => x.AnimalId == id);
        }

        public async Task<AnimalModel> InsertAnimal(AnimalModel animal)
        {
            await _dbContext.Animal.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<AnimalModel> UpdateAnimal(AnimalModel Animal, int id)
        {
            AnimalModel animal = await GetById(id);
            if (animal == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                animal.NomeAnimal = Animal.NomeAnimal;
                animal.AnimalRaca = Animal.AnimalRaca;
                animal.AnimalTipo = Animal.AnimalTipo;
                animal.AnimalCor = Animal.AnimalCor;
                animal.AnimalSexo = Animal.AnimalSexo;
                animal.AnimalObservacao = Animal.AnimalObservacao;
                animal.AnimalFoto = Animal.AnimalFoto;
                animal.AnimalDtDesaperecimento = Animal.AnimalDtDesaperecimento;
                animal.AnimalDtEncontro = Animal.AnimalDtEncontro;
                animal.AnimalStatus = Animal.AnimalStatus;
                animal.UsuarioId = Animal.UsuarioId;
                _dbContext.Animal.Update(animal);
                await _dbContext.SaveChangesAsync();
            }
            return animal;

        }

        public async Task<bool> DeleteAnimal(int id)
        {
            AnimalModel animal = await GetById(id);
            if (animal == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Animal.Remove(animal);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
