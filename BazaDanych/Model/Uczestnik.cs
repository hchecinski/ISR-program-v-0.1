using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    public class Uczestnik
    {
        public int Id { get; set; } = -1;
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public DateTime DataUrodzenia { get; set; } = new DateTime();
        public string NumerTelefonu { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Subskrypcja { get; set; } = false;
        public string Uwagi { get; set; } = string.Empty;
        public string Miasto { get; set; } = string.Empty;
        public string Dzielnica { get; set; } = string.Empty;
        public DateTime DataRejestracji { get; set; } = new DateTime();
        public bool CzyAktywny { get; set; } = false;

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Uczestnik)
            {
                var u = obj as Uczestnik;
                return u.Id == Id &&
                       u.Imie == Imie &&
                       u.Nazwisko == Nazwisko &&
                       u.DataUrodzenia == DataUrodzenia &&
                       u.NumerTelefonu == NumerTelefonu &&
                       u.Email == Email &&
                       u.Subskrypcja == Subskrypcja &&
                       u.Uwagi == Uwagi &&
                       u.Miasto == Miasto &&
                       u.Dzielnica == Dzielnica &&
                       u.DataRejestracji == DataRejestracji &&
                       u.CzyAktywny == CzyAktywny;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^
                   Imie.GetHashCode() ^
                   Nazwisko.GetHashCode() ^
                   DataUrodzenia.GetHashCode() ^
                   NumerTelefonu.GetHashCode() ^
                   Email.GetHashCode() ^
                   Subskrypcja.GetHashCode() ^
                   Uwagi.GetHashCode() ^
                   Miasto.GetHashCode() ^
                   Dzielnica.GetHashCode() ^
                   DataRejestracji.GetHashCode() ^
                   CzyAktywny.GetHashCode(); ;
        }
    }
}
