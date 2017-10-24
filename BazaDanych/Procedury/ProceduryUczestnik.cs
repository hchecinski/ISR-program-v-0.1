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
using System.Windows;

namespace BazaDanych.Procedury
{
    public class ProceduryUczestnik : IPolecenia<Uczestnik>
    {

        public void EdytujElement(Uczestnik element)
        {
            var data = element.DataUrodzenia.ToString("yyyyMMdd");
            string zapytanie = $"Update Uczestnicy " +
                $"SET Imie = '{element.Imie}', " +
                $"Nazwisko = '{element.Nazwisko}', " +
                $"DataUrodzenia = DATE({data}), " +
                $"NumerTelefonu =  '{element.NumerTelefonu}', " +
                $"Email = '{element.Email}', " +
                $"Subskrypcja = {element.Subskrypcja}, " +
                $"Uwagi = '{element.Uwagi}', " +
                $"Miasto = '{element.Miasto}', " +
                $"Dzielnica = '{element.Dzielnica}' " +
                $"WHERE Id = {element.Id}";

            using (MySqlConnection db = new MySqlConnection(Baza.ConnectionString()))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var wynik = db.Execute(zapytanie);
                        if (wynik > 0)
                            transaction.Commit();
                        else
                        {
                            transaction.Rollback();
                            throw new Exception("Edytowanie uczestnika do bazy nie powiodło się.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public Uczestnik PobierzElement(int id)
        {
            Uczestnik uczestnik = new Uczestnik();
            string zapytanie = $"SELECT * FROM Uczestnicy WHERE Id = {id}";
            using (MySqlConnection db = new MySqlConnection(Baza.ConnectionString()))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        uczestnik = db.Query<Uczestnik>(zapytanie).SingleOrDefault();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return uczestnik;
        }

        public void UsunElement(int id)
        {
            string zapytanie = $"Update Uczestnicy " +
                $"SET CzyAktywny = 0 " +
                $"WHERE Id = {id}";

            using (MySqlConnection db = new MySqlConnection(Baza.ConnectionString()))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var wynik = db.Execute(zapytanie);
                        if (wynik > 0)
                            transaction.Commit();
                        else
                        {
                            transaction.Rollback();
                            throw new Exception("Usuwanie uczestnika do bazy nie powiodło się.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
               
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
            catch (Exception ex)
            {
                return -1;
            }
    
            return wynik;
        }

    }

}
