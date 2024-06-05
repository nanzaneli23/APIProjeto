﻿namespace Api.Models
{
    public class AnimalModel
    {
        public int AnimalId { get; set; }

        public string NomeAnimal { get; set; } = string.Empty;


        public string AnimalRaca { get; set; } = string.Empty;

        public string AnimalTipo { get; set; } = string.Empty;

        public string AnimalCor { get; set; } = string.Empty;

        public string AnimalSexo { get; set; } = string.Empty;

        public string AnimalObservacao { get; set; } = string.Empty;

        public string AnimalFoto { get; set; } = string.Empty;

        public DateTime AnimalDtDesaperecimento { get; set; }

        public DateTime? AnimalDtEncontro { get; set; }

        public byte AnimalStatus { get; set; }

        public int UsuarioId { get; set; }



        public static implicit operator List<object>(AnimalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
