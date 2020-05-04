using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entity.DLL.Entities;

namespace EpamLecturePracticeProducts.DAL
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
               var ganres = new List<Ganre>
               {
                new Ganre { Title = "Ужасы", Description = "Что-то очень страшное" },
                new Ganre { Title = "Роман", Description = "Что-то очень интересное"},
                new Ganre { Title = "Детектив", Description = "Что-то очень загадочное"}
               };

            ganres.ForEach(g => context.Ganres.Add(g));
            context.SaveChanges();

            var books = new List<Book>
            {
            new Book { Title = "Кристина", Author = "Стивен Кинг",
                        Ganre = ganres[0],
                        Description = "Книга про машину убийцу", Price = 200M, Year = 2017
            },
            new Book { Title = "Американская трагедия", Author = "Теодор Драйзер",
                        Ganre = ganres[1],
                        Description = "Окунитесь в Америку 20-х годов", Price = 50M, Year = 1996
            },
            new Book { Title = "Темная башня", Author = "Стивен Кинг",
                        Ganre = ganres[1],
                        Description = "Отправляйтесь в незабываемое приключение с Роландом", Price = 100M, Year = 2015
            },
            new Book { Title = "Чужак", Author = "Макс Фрай",
                        Ganre = ganres[1],
                        Description = "Познакомтесь с миром Эхо", Price = 150M, Year = 2019
            },
            new Book { Title = "10 негритят", Author = "Агата Кристи",
                        Ganre = ganres[2],
                        Description = "10 человек в доме на безлюдном острове", Price = 70M, Year = 1976
            }
            };

            books.ForEach(b => context.Books.Add(b));

            context.SaveChanges();
    }
    }
}