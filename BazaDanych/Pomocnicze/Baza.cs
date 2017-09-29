using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Pomocnicze
{
    public static class Baza
    {
        private static string server = "mysql.sh197108.website.pl";
        private static string databaseName = "sh197108_1";
        private static string userName = "sh197108_hch";
        private static string password = "wolny123";

        public static string POBIERZ_UCZESTNIKOW = "Uczestnik_GetAll";
        public static string ZAPISZ_UCZESTNIKA = "Uczestnik_SetUczestnik";

        public static string ConnectionString()
        {
            return $"server={server};database={databaseName};uid={userName};pwd={password};";
        }
    }
}
