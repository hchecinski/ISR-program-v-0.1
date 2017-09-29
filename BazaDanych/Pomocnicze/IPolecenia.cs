using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Pomocnicze
{
    public interface IPolecenia<T>
    {
        IEnumerable<T> WczytajDane();
        T PobierzElement(int id);
        int EdytujElement(int id);
        int ZapiszElement(T element);
        int UsunElement(int id);
    }
}
