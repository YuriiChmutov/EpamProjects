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
        }

        
                
    }
}
