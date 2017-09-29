using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    public class Warsztat
    {
        public int Id { get; set; } = -1;
        public string Temat { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public string Prowadzacy { get; set; } = string.Empty;
        public DateTime Data { get; set; } = new DateTime();

        public IEnumerable<Uczestnik> ListaUczestnikow { get; set; } = null;

        public override string ToString()
        {
            return Temat;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^
                   Temat.GetHashCode() ^
                   Opis.GetHashCode() ^
                   Prowadzacy.GetHashCode() ^
                   Data.GetHashCode() ^
                   ListaUczestnikow.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Warsztat)
            {
                var w = obj as Warsztat;
                return w.Id == Id &&
                       w.Temat == Temat &&
                       w.Opis == Opis &&
                       w.Prowadzacy == Prowadzacy &&
                       w.Data == Data &&
                       w.ListaUczestnikow == ListaUczestnikow;
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
