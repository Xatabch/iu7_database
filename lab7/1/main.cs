using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    class Wines
    {
        public int id { get; set; }
        public string title { get; set; }
        public string variety { get; set; }
        public int price { get; set; }
        public string country { get; set; }
    }

    class Descriptions
    {
        public int wine { get; set; }
        public string description { get; set; }
    }

    class FirstTask
    {
        static void Main(string[] args)
        {
            IList<Wines> winesList = new List<Wines>
            {
                new Wines() { id=1, title="Title1", price=12, variety="Variety1", country="Country1" },
                new Wines() { id=2, title="Title2", price=13, variety="Variety2", country="Country2" },
                new Wines() { id=3, title="Title3", price=20, variety="Variety2", country="Country3" },
                new Wines() { id=4, title="Title4", price=80, variety="Variety2", country="Country4" },
                new Wines() { id=5, title="Title5", price=40, variety="Variety5", country="Country5" },
                new Wines() { id=6, title="Title6", price=40, variety="Variety6", country="Country6" }
            };

            IList<Descriptions> descriptionList = new List<Descriptions>
            {
                new Descriptions() { wine=1, description="Description1" },
                new Descriptions() { wine=2, description="Description2" },
                new Descriptions() { wine=3, description="Description3" },
                new Descriptions() { wine=4, description="Description4" },
                new Descriptions() { wine=5, description="Description5" },
                new Descriptions() { wine=6, description="Description6" }
            };

            // Вывод всех значений
            foreach (var i in winesList)
                Console.WriteLine(i.id + "|" + i.title + " | " + i.variety + " | " + i.country + " | " + i.price);


            Console.WriteLine();
            // 1. Запрос: цены больше 15
            Console.WriteLine("1. Запрос: ");
            var result_1 = from w in winesList
                           let pr = 15
                           where w.price > pr
                           select w.title;

            foreach (var i in result_1)
                Console.WriteLine(i);

            Console.WriteLine();
            // 2. Запрос: Variety2 и сортировка по price
            Console.WriteLine("2. Запрос: ");
            var result_2 = from w in winesList
                               where w.variety == "Variety2"
                               orderby w.price descending
                               select $"Price is {w.price}";
                               
            foreach (var i in result_2)
                Console.WriteLine(i);

            Console.WriteLine();
            // 3. Запрос ofType wines - title
            Console.WriteLine("3. Запрос: ");
            var result_3 = from w in winesList.OfType<Wines>()
                              select w.title;

            foreach (var i in result_3)
                Console.WriteLine(i);

            Console.WriteLine();
            // 4. Запрос ofType Cars - engine
            Console.WriteLine("4. Запрос: ");
            var result_4 = from w in winesList
                           group w by w.price into priceGroup
                           select new { first = priceGroup.Key, words = priceGroup.Count() };

            foreach (var item in result_4)
                Console.WriteLine("{0} имеет {1} элемента/ов", item.first, item.words);

            Console.WriteLine();
            // 5. Запрос ofType Cars - engine
            Console.WriteLine("5. Запрос: ");
            var result_5 = from w in winesList
                           join d in descriptionList on w.id equals d.wine
                           select new { winetitle = w.title, description = d.description };


            foreach (var item in result_5)
                Console.WriteLine("{0} имеет описание {1}", item.winetitle, item.description);
        }
    }
}