using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace Lab07
{
    [Table (Name = "Wine")]
    public class WineTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public string title { get; set; }

        [Column]
        public string variety { get; set; }

        [Column]
        public int price { get; set; }

        [Column]
        public int country_id { get; set; }

        [Column]
        public int description_id { get; set; }

    }

    [Table (Name = "Country")]
    public class CountryTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public string country{ get; set; }
    }

    [Table (Name = "Description")]
    public class DescriptionTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public string description { get; set; }

    }

    [Table (Name="Sommelier")]
    public class SommelierTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public string taster_name { get; set; }

        [Column]
        public string twitter { get; set; }

    }

    [Table (Name="Wine_Sommelier")]
    public class WineSommelierTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public int wine_id { get; set; }

        [Column]
        public int sommelier_id { get; set; }

    }

    [Table (Name="Results")]
    public class ResultsTable
    {
        [Column (IsPrimaryKey = true)]
        public int id { get; set; }

        [Column]
        public string title { get; set; }

        [Column]
        public string variety { get; set; }

        [Column]
        public int price { get; set; }

        [Column]
        public int country_id { get; set; }

        [Column]
        public int description_id { get; set; }

        [Column (IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column]
        public string country{ get; set; }
    }

    public class UserDataContext
    {
        public class UserDataContext1 : DataContext
        {
            public UserDataContext1(string connectionString) : base(connectionString)
            {
            }
            
            [Function(Name = "dbo.GetDiffAge")]
            [return: Parameter(DbType = "Int")]
            public int GetDiffAge(
                [Parameter(Name = "Fir" +
                "stAge", DbType = "Int")] ref int _FirstAge,
                [Parameter(Name = "SecondAge", DbType = "Int")] ref int _SecondAge)
            {
                IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod(), _FirstAge, _SecondAge);
                _FirstAge = (int)result.GetParameterValue(0);
                _SecondAge = (int)result.GetParameterValue(1);

                return (int)result.ReturnValue;
            }
        }
    }

    class ThirdTask
    {
       
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost; database = testdb; user id = sa; password = 0765842953VaNy";
            DataContext db = new DataContext(connectionString);

            // 1.
            // Console.WriteLine("\nОднотабличный запрос на выборку.");
            // var wines = from w in db.GetTable<WineTable>()
            //              where w.price < 15
            //              select w;

            // Console.WriteLine("Вина, цена которых меньше 15:");
            // foreach (var wine in wines) {
            //     Console.WriteLine(wine.title);
            // }


            // 2.
            // Console.WriteLine();
            // Console.WriteLine("\nМноготабличный запрос на выборку.");
            // var descriptions = from wine in db.GetTable<WineTable>()
            //            join description in db.GetTable<DescriptionTable>() on wine.id equals description.id
            //            select new { wineTitle = wine.title, descriptionText = description.description };

            // Console.WriteLine("Описание каждого вина: ");
            // foreach (var description in descriptions)
            //     Console.WriteLine(description);


            // 3.
            // Console.WriteLine();
            // Console.WriteLine("\nТри запроса на добавление, изменение и удаление данных в базе данных.");

            // Добавление
            // Console.WriteLine("Добавление новой записи");
            // Console.Write("Введите страну:");
            // var countryName = Console.ReadLine();
            // var IDs = from country in db.GetTable<CountryTable>()
            //           select country.id;

            // int maxID = IDs.Max() + 1;

            // CountryTable newCountry = new CountryTable()
            // {
            //     id = maxID,
            //     country = countryName
            // };

            // db.GetTable<CountryTable>().InsertOnSubmit(newCountry);
            // Console.WriteLine("Сохранение...");
            // db.SubmitChanges();
            // Console.WriteLine("Добавление выполенено успешно.");
            // Console.ReadKey();

            // Изменение
            // Console.WriteLine("\n\nИзменение записи в таблице ");
            // Console.Write("Введите Страну поле Country который вы хотите поменять: ");
            // var countryName = Console.ReadLine();
            // Console.Write("Введите новое значение страны: ");
            // var newCountryName = Console.ReadLine();

            // var changeDB = db.GetTable<CountryTable>().Where(p => p.country == countryName).FirstOrDefault();
            // changeDB.country = newCountryName;
            // Console.WriteLine("Сохранение...");
            // db.SubmitChanges();
            // Console.WriteLine("Изменение выполенено успешно.");
            // Console.ReadKey();

            // Удаление
            // Console.WriteLine("\n\nУдаление записи в таблице ");
            // Console.Write("Введите Страну которую хотите удалить: ");
            // var countryName = Console.ReadLine();

            // var delDB = db.GetTable<CountryTable>().Where(p => p.country == countryName).FirstOrDefault();
            // db.GetTable<CountryTable>().DeleteOnSubmit(delDB);
            // Console.WriteLine("Сохранение...");
            // db.SubmitChanges();
            // Console.WriteLine("Удаление выполенено успешно.");

            // Console.ReadKey();

            // Получение доступа к данным, выполняя только хранимую процедуру.
            UserDataContext.UserDataContext1 db1 = new UserDataContext.UserDataContext1(connectionString);
            int _firstAge, _secondAge;
            
            Console.WriteLine("Хранимая процедура: ");
            Console.WriteLine("\nВведите первый возраст:");
            _firstAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите первый возраст:");
            _secondAge = Convert.ToInt32(Console.ReadLine());
            throw new NotImplementedException();

            var obj = db1.GetDiffAge(ref _firstAge, ref _secondAge);
            Console.WriteLine($"Первый возраст: {_firstAge}, Второй возраст: {_secondAge}. Их разница составила: " + System.Math.Abs(obj) + " лет.");
        }
    }
}