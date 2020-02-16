using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;
using System.Data.Entity;

namespace EpamPractice.DAL
{
    public class BlogInitializer: DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var users = new List<User>
            {
                new User{Name = "Колян",TitleOfComment = "Это шедевр!", Comment = "Как здорово, что вообще такие блоги есть! Благодаря им мы смогли спланировать свое первое самостоятельное путешествие. Советы блогеров бесценны, потому как при планировании поездки есть много вопросов, а вот ответы часто не удовлетворяют, а блог-это способ выразить свое мнение и отразить существующую действительность.", Date = DateTime.Now},
                new User{Name = "Мария",TitleOfComment = "Очень познавательно", Comment = "Буду рада, если мой блог о путешествиях тоже понравится 8) — chemezova.ru/travel/ Пишу про Байкал, Европу и Азию", Date = DateTime.Now},
                new User{Name = "Саша",TitleOfComment = "Какие планы?", Comment = "Юрий, а если бы вы начинали свое путешествие и свой блог сегодня, сейчас, в какую страну вы бы отправились и почему?", Date = DateTime.Now},
                new User{Name = "Ксения",TitleOfComment = "Если что", Comment = "А мне нравится авторский блог путешественника Алексея Гуреева landsurveyorsblog.org очень интересно написаны обзоры, статьи, много интересных, качественных фотографий, в общем рекомендую.", Date = DateTime.Now}

            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var articles = new List<Article>
            {
                new Article {NameOfNews = "Озеро Хинтерзее", Special = "Озеро в Германии", Subtitle = "Лучшее что я видел",
                Link = "../../Content/images/lake-picture.jpg", Date = DateTime.Now,
                Content = "Хинтерзее – красивейшее озеро в районе" +
                    " городка Рамзау 18 метров глубиной. Сочетание большого количества свежих горных источников воды," +
                    " питающих озеро, не позволяют воде значительно прогреться даже в летние месяцы, максимальная" +
                    " температура воды 16°. Таким образом, для купания оно лишь условно подходит." +
                    " Прекрасная природа и красивейшие виды."},
                new Article{NameOfNews = "Коалы в Австралии", Special = "Special title treatment", Subtitle = "Support card subtitle",
                Link = "../../Content/images/koala-picture-main.jpg", Date = (DateTime.Now), Content = "Коалы очень милые существа."},
                new Article{ NameOfNews = "Пейзаж на берегах Новой Зеландии", Special = "Special title treatment", Subtitle = "Support card subtitle",
                Link = "../../Content/images/landscape-picture.jpg", Date = DateTime.Parse("12/12/2000"),Content = "Необычайно красивое место"},
                
            };

            articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();

            var votes = new List<Vote>
            {
                new Vote {Value = "1", Amount = 1},
                new Vote {Value = "2", Amount = 2},
                new Vote {Value = "3", Amount = 7}
            };

            votes.ForEach(v => context.Votes.Add(v));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag{Text = "#отдых"},
                new Tag{Text = "#зверюшка"},
                new Tag{Text = "#красиво"},
                new Tag{Text = "#блог"},
                new Tag{Text = "#яТутБыл"},
                new Tag{Text = "#море"},
                new Tag{Text = "#закат"},
                new Tag{Text = "#каникулы"}
            };

            tags.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();
        }

        
        
                
    }
}
