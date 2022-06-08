using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace hw_sh_6
{
    abstract class Car : IComparable
    {
        public string Stamp { get; set; } // марка
        public string Model { get; set; } // модель
        public string OriginCountry { get; set; } // страна производитель

        public int YearRelease { get; set; } // год выпуска

        public int FuelConsumption { get; set; } //расход

        public override string ToString()
        {
            return $"\nМарка: {Stamp} Модель: {Model} Страна производитель: {OriginCountry} Год выпуска {YearRelease}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Car)
            {
                return Stamp.CompareTo((obj as Car).Stamp);
            }
            else
                throw new NotImplementedException();
        }

    }
    abstract class Passenger : Car //легковые
    {
        public string Type { get; set; } //тип
        public int PassengerNumbers { get; set; } //количество пассажиров

        public override string ToString()
        {
            return base.ToString() + $"\nТип: {Type} Количество пассажиров: {PassengerNumbers} $";
        }
    }

    abstract class Cargo : Car, IComparable //грузовые
    {
        public int Capacity { get; set; } //грузоподъемность

        public override string ToString()
        {
            return base.ToString() + $"\nГрузоподъемность: {Capacity} $";
        }

        public new int CompareTo(object obj)
        {
            if (obj is Car)
            {
                return Capacity.CompareTo((obj as Cargo).Capacity);
            }
            else
                throw new NotImplementedException();
        }
    }

    interface IFunctions
    {
        bool IsWork { get; }
        string Transfer(); //перевожу
        string ConsumeFuel(); //трачу топливо
    }
    class PassengerPark : Passenger, IFunctions
    {
        bool isWork = true;
        public bool IsWork
        {
            get
            {
                return isWork;
            }
        }
        public string Transfer()
        {
            return "Перевожу пассажиров";
        }

        public string ConsumeFuel()
        {
            return $"Расходую топливо: {FuelConsumption}литров на 100 км";
        }

    }

    class CargoPark : Cargo, IFunctions
    {
        bool isWork = true;
        public bool IsWork
        {
            get
            {
                return isWork;
            }
        }
        public string Transfer()
        {
            return "Перевожу груз";
        }

        public string ConsumeFuel()
        {
            return $"Расходую топливо: {FuelConsumption}литров на 100 км";
        }

    }

    class ParkPP : IEnumerable
    {
        PassengerPark[] passengerPark =
        {
            new PassengerPark
                {
                    Stamp = "BMW",
                    Model = "X5",
                    OriginCountry = "Германия",
                    YearRelease = 2019,
                    FuelConsumption = 9,
                    PassengerNumbers = 4,
                    Type = "Паркетник"
                },
            new PassengerPark
                {
                    Stamp = "Audi",
                    Model = "A5",
                    OriginCountry = "Германия",
                    YearRelease = 2015,
                    FuelConsumption = 10,
                    PassengerNumbers = 4,
                    Type = "Купе"
                },
            new PassengerPark
                {
                    Stamp = "Opel",
                    Model = "Astra",
                    OriginCountry = "Германия",
                    YearRelease = 2017,
                    FuelConsumption = 8,
                    PassengerNumbers = 4,
                    Type = "Хэтчбек"
                }

        };
        public IEnumerator GetEnumerator() // возвращает итератор по коллекции
        {
            return passengerPark.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(passengerPark);
        }

    }

    class ParkCP : IEnumerable
    {
        CargoPark[] cargoPark =
        {
                    new CargoPark
                {
                    Stamp = "Газель",
                    Model = "Соболь",
                    OriginCountry = "Россия",
                    YearRelease = 2020,
                    FuelConsumption = 15,
                    Capacity = 300
                },
                new CargoPark
                {
                    Stamp = "Камаз",
                    Model = "Камаз",
                    OriginCountry = "Россия",
                    YearRelease = 2018,
                    FuelConsumption = 25,
                    Capacity = 3000
                }
        };

        public IEnumerator GetEnumerator()
        {
            return cargoPark.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(cargoPark);
        }

    };

    
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Автопарк. Вы можете посмотреть следующую информацию:\n " +
                    "1. Все транспортные средства; \n 2. Легковые, отсортированные по марке;\n " +
                    "3. Грузовые отсортированные по грузоподъемности;\n 4. Список функций грузового транспорта;\n " +
                    "5. Выйти из программы. \n Какой пункт Вас интересует?");
                string posnum = ReadLine();

                switch (posnum)
                {
                    case "1":
                        {
                            WriteLine("Все транспортные средства:\n");

                            ParkPP pp = new ParkPP();
                            WriteLine("*******Легковые**********");
                            foreach (PassengerPark s in pp)
                            {
                                WriteLine(s);
                            }
                            WriteLine();

                            ParkCP cp = new ParkCP();
                            WriteLine("*******Грузовые**********");
                            foreach (CargoPark t in cp)
                            {
                                WriteLine(t);
                            }
                            WriteLine();
                        }

                        break;

                    case "2":
                        {
                            WriteLine("Отсортированные по марке легковые машины:\n");
                            ParkPP pp = new ParkPP();
                            pp.Sort();
                            foreach (PassengerPark s in pp)
                            {
                                WriteLine(s);
                            }
                            WriteLine();
                        }
                        break;

                    case "3":
                        {
                            WriteLine("Грузовые отсортированные по грузоподъемности:\n");
                            ParkCP cp = new ParkCP();
                            cp.Sort();                       

                            foreach (CargoPark s in cp)
                            {
                                WriteLine(s);
                            }
                            WriteLine();
                        }
                        break;

                    case "4":
                        {
                            WriteLine("Функции грузового транспорта:\n");
                            ParkCP cp = new ParkCP();
                            foreach (IFunctions item in cp)
                            {
                                WriteLine(item);
                                if (item.IsWork)
                                {
                                    WriteLine(item.Transfer());
                                    WriteLine(item.ConsumeFuel());
                                }
                            }
                            WriteLine();
                        }
                        break;

                    case "5":
                        return;

                    default:
                        WriteLine("Вы выбрали несуществующий пункт меню. Выберите снова.");
                        continue;
                }
            }
        }
    }
}

