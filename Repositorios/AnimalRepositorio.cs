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
                animal.NomeAnimal = animal.NomeAnimal;
                animal.AnimalRaca = animal.AnimalRaca;
                animal.AnimalTipo = animal.AnimalTipo;
                animal.AnimalCor = animal.AnimalCor;
                animal.AnimalSexo = animal.AnimalSexo;
                animal.AnimalObservacao = animal.AnimalObservacao;
                animal.AnimalFoto = animal.AnimalFoto;
                animal.AnimalDtDesaperecimento = animal.AnimalDtDesaperecimento;
                animal.AnimalDtEncontro = animal.AnimalDtEncontro;
                animal.AnimalStatus = animal.AnimalStatus;
                animal.UsuarioId = animal.UsuarioId;
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
