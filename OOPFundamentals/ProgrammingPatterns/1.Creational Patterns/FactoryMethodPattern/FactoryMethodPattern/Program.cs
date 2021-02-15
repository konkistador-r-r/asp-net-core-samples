using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    /*
        Допустим, мы создаем программу для сферы строительства. Возможно, вначале мы захотим построить многоэтажный панельный дом. 
        И для этого выбирается соответствующий подрядчик, который возводит каменные дома. 
        Затем нам захочется построить деревянный дом и для этого также надо будет выбрать нужного подрядчика.
    */
    class Program
    {
        static void Main(string[] args)
        {             
            Developer dev = Developer.Create(DeveloperType.Panel, "ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = Developer.Create(DeveloperType.Wood, "Частный застройщик");
            House house = dev.Create();

            dev = Developer.Create(DeveloperType.Break, "Частный застройщик 2");
            House house3 = dev.Create();

            Console.ReadLine();
        }
    }

    /*
        В качестве абстрактного класса Product здесь выступает класс House. 
        Его две конкретные реализации - PanelHouse и WoodHouse представляют типы домов, которые будут строить подрядчики. 
        В качестве абстрактного класса создателя выступает Developer, определяющий абстрактный метод Create(). 
        Этот метод реализуется в классах-наследниках WoodDeveloper и PanelDeveloper. 
        
        И если в будущем нам потребуется построить дома какого-то другого типа, например, кирпичные, то мы можем с легкостью создать новый класс кирпичных домов, 
        унаследованный от House, и определить класс соответствующего подрядчика. Таким образом, система получится легко расширяемой. 
        
        Правда, недостатки паттерна тоже очевидны - для каждого нового продукта необходимо создавать свой класс создателя.
     */

    /*
        As the result we`ve got separate ProductCreator for each Product. Client use concreate ProductCreator to get instance of some Product.
        Client get Products of different exact type and manage them by reference of abstract type.
     */

    
}
