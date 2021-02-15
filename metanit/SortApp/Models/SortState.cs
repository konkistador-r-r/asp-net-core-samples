using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp.Models
{
    // В классе User есть три свойства(не считая Id), по которым можно вести сортировку: Name, Age, Company.
    // Сортировка может быть по возрастанию и по убыванию.
    // Таким образом, получаем шесть критериев сортировки.
    // Это перечисление хранит критерии сортировки в виде числовых констант.
    public enum SortState
    {
        NameAsc = 0,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AgeAsc, // по возрасту по возрастанию
        AgeDesc,    // по возрасту по убыванию
        CompanyAsc, // по компании по возрастанию
        CompanyDesc // по компании по убыванию
    }
}
