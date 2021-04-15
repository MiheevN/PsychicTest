using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Psychic_Test.Data
{

    public class TestingGroup
    {
        public List<Psyphic> Psyphics { get; set; } = new List<Psyphic>();
        public List<sbyte> CurrentGuesses { get; init; } = new List<sbyte>();
        public List<sbyte> EnteredNumbers { get; init; } = new List<sbyte>();
        public sbyte LastSecretNumber { get; protected set; }
        public Action On_Checked { get; set; }
        public TestingGroup()
        {
            byte Count = (byte)new Random().Next(2, 6);
            for (int i = 0; i < Count; i++)
            {
                Psyphics.Add(new Psyphic());
            }
        }

        public void MakeGuesses()
        {
            CurrentGuesses.Clear();
            foreach (var Psy in Psyphics)
            {
                CurrentGuesses.Add(Psy.GetNewGuess());
            }
        }

        public void CheckGuess(sbyte secret)
        {
            LastSecretNumber = secret;
            EnteredNumbers.Add(secret);
            for (int i = 0; i < CurrentGuesses.Count; i++)
            {
                if (LastSecretNumber == CurrentGuesses[i])
                    Psyphics[i].AddCreditibility();
                else
                    Psyphics[i].ReduceCreditibility();
            }
            On_Checked?.Invoke();
        }
    }
}
