using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychic_Test.Data
{
    public class Psyphic
    {
        static int Number;
        public string Name { get; init; } = $"Экстрасенс {++Number}";
        public float Credibility { get; protected set; }

        private Random random;
        private List<sbyte> _Guesses { get; init; } = new List<sbyte>();
        public IReadOnlyList<sbyte> Guesses => _Guesses.AsReadOnly();

        public Psyphic()
        {
            random = new Random(Number);
        }

        public sbyte GetNewGuess()
        {
            sbyte newguess = (sbyte)random.Next(10, 99);
            _Guesses.Add(newguess);
            return newguess;
        }
        public void AddCreditibility()
        {
            Credibility += 0.01f;
        }
        public void ReduceCreditibility()
        {
            Credibility -= 0.01f;
        }
    }
}
