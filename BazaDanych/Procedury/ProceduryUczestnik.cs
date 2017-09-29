using BazaDanych.Model;
using BazaDanych.Pomocnicze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BazaDanych.Procedury
{
    public class ProceduryUczestnik : IPolecenia<Uczestnik>
    {

        public int EdytujElement(int id)
        {
            throw new NotImplementedException();
        }

        public Uczestnik PobierzElement(int id)
        {
            throw new NotImplementedException();
        }

        public int UsunElement(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Uczestnik> WczytajDane()
        {
            using (var cnn = new MySqlConnection(Baza.ConnectionString()))
            {
                cnn.Open();
                return cnn.Query<Uczestnik>("SELECT * FROM Uczestnicy");
            }
        }

        public int ZapiszElement(Uczestnik element)
        {
            int wynik = 0;
            try
            {
                using (var cnn = new MySqlConnection(Baza.ConnectionString()))
                {
                    cnn.Open();
                    using (var transactionScope = cnn.BeginTransaction())
                    {
                        wynik = cnn.Execute("insert into Uczestnicy ( imie, nazwisko, dataurodzenia, numertelefonu, email, subskrypcja, uwagi, miasto, dzielnica, datarejestracji, czyaktywny ) " +
                                                    "values ( {Imie}, {Nazwisko}, DATE({DataUrodzenia}), {NumerTelefonu}, {Email}, {Subskrypcja}, {Uwagi}, {Miasto}, {Dzielnica}, NOW(), 1 );");
                    }
                }

            }
            catch(Exception ex)
            {
                return -1;
            }

            return wynik;
        }
    }
}
