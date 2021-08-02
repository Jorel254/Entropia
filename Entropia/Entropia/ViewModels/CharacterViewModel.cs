using Entropia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Entropia.ViewModels
{
    class CharacterViewModel : ModelBase
    {
        private string longWord;
        private double _Entropia;
        char[] partes;
        public List<Character> characters { get; set; }
        public Character character { get; set; }

        public ICommand EntropiaCommand { get; set; }
        public string LongWord
        {
            get => longWord;
            set
            {
                longWord = value;
                OnPropertyChanged();
            }
        }
        public double Entropia
        {
            get => _Entropia;
            set
            {
                _Entropia = value;
                OnPropertyChanged();
            }
        }
        public CharacterViewModel()
        {
            character = new Character();
            characters = new List<Character>();
            EntropiaCommand = new Command(Generar);
        }

        private void Generar(object obj)
        {
            Entropia = 0;
            if (longWord==null)
            {
                App.Current.MainPage.DisplayAlert("Advertencia", "Introduzca un texto para continuar","Aceptar");
            }else
            {
                partes = longWord.ToCharArray(0, longWord.Length);
                Contabilizar(partes);
                Promedios();
                CalcularEntropia();
                Limpiar();

            }
        }
        private void Contabilizar(char[] vs)
        {
            foreach (char item in vs)
            {
                character = new Character(item, 1, 0);
                bool sum = false;
                if (characters.Count <= 0)
                {
                    characters.Add(character);
                }
                else
                {
                    for (int i = 0; i < characters.Count; i++)
                    {

                        if (characters[i].Word.Equals(character.Word))
                        {
                            characters[i].Amount++;
                            sum = true;
                        }

                    }
                    if (!sum)
                    {
                        characters.Add(character);
                    }

                }

            }
        }
        private void Promedios()
        {
            double frecuenciatotal=0;
            foreach (Character item in characters)
            {
                frecuenciatotal += item.Amount;
            }
            double res;
            for (int i = 0; i < characters.Count; i++)
            {
                res = characters[i].Amount / frecuenciatotal;
                characters[i].Average =res;
            }

        }
        private void CalcularEntropia()
        {
          
            foreach (Character item in characters)
            {
                Entropia += item.Average*(Math.Log((1 / item.Average), 2));
            }
            
        }
        private void Limpiar()
        {
            partes = new char[0];
            characters.Clear();
            LongWord = "";
        }
    }
}
