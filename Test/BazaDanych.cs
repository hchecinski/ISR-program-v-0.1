using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using BazaDanych.Pomocnicze;
using BazaDanych.Procedury;
using BazaDanych.Model;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class BazaDanychTest
    {
        [TestMethod]
        public void PolaczenieTest()
        {
            using (var cnn = new MySqlConnection(Baza.ConnectionString()))
            {
                cnn.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, cnn.State);
            }
        }

        [TestMethod]
        public void WczytajDaneTest()
        {
            var pu = new ProceduryUczestnik();
            var dane = pu.WczytajDane().ToList();
            Assert.IsTrue(dane != null && dane.Count > 0);
        }

        /// <summary>
        /// Trzeba najpierw usunąć z bazy kolesia
        /// </summary>
        [TestMethod]
        public void DodajUczestnikTest()
        {
            var uczestnik = new Uczestnik()
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                DataUrodzenia = DateTime.Now,
                Miasto = "Łódź",
                Dzielnica = "Widzew",
                Email = "janKowalski@wp.pl",
                Uwagi = "jakies uwagi",
                NumerTelefonu = "888-888-888",
                Subskrypcja = true
            };

            var procedura = new ProceduryUczestnik();
            var wynik = procedura.ZapiszElement(uczestnik);
            Assert.AreEqual(1, wynik);
        }
    }
}
