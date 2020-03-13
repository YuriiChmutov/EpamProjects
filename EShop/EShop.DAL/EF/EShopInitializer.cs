using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EShop.DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;

namespace EShop.DAL.EF
{
    public class EShopInitializer : DropCreateDatabaseIfModelChanges<EShopContext>
    {
        public CultureInfo culture = new CultureInfo("ru-UA");
        protected override void Seed(EShopContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Телефоны", Description = "Здесь вы найдете себе телефон на любой вкус."},
                new Category { Name = "Телевизоры", Description = "Вы сможете увидеть весь мир в высочайшем качестве с нашими телевизорами."},
                new Category { Name = "Ноутбуки", Description = "Вы всегда можете взять их с собой. Производительность наших ноутбуков приятно удивит вас."},
                new Category { Name = "Умные часы и Фитнесс браслеты", Description = "Контролируйте свое время и здоровье."},
                new Category { Name = "Техника для дома", Description = "Всё, что может облегчить вашу бытовую жизнь."}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {Category = categories[0],  Name = "SAMSUNG Galaxy A51 4/64GB Black (SM-A515FZKUSEK)",
                            Description = "Безграничный экран Galaxy A51 оптимизирует визуальную симметрию. Теперь ты можешь играть, смотреть фильмы, бродить по сети и работать в многозадачном режиме без перерыва на ярком 6.5-дюймовом sAMOLED экране с FHD+ разрешением. Погрузись в контент с головой благодаря тонкой рамке дисплея и максимальной площади полезного пространства.",
                            Price = 8499M, Color = "Черный", Size = 15.8M, Date = Convert.ToDateTime("15/2/2020", culture),
                            ImagePath = "~/Content/Images/Products/Telephones/Samsung/Galaxy_A51_A5_64_Black.jpg"},
                new Product {Category = categories[0], Name = "HUAWEI P smart Z 4/64GB Midnight Black (51093WVH)",
                            Description = "Главная отличительная особенность смартфона HUAWEI P smart Z — это уникальный дизайн задней панели. Ее мерцающая поверхность приятная на ощупь и гладкая, как шелк.",
                            Price = 5999M, Color = "Черный", Size = 16.35M, Date = Convert.ToDateTime("16/2/2020", culture),
                            ImagePath = "~/Content/Images/Products/Telephones/Huawei/P_Smart_Z_4_64_Black_2.jpg"},
                new Product {Category = categories[0], Name = "Samsung Galaxy S20 Ultra Black",
                            Description = "Встречайте Galaxy S20 Ultra. Cнимайте в революционном разрешении 8K и получайте сверхчеткие фотографии высокого качества прямо из видео. Добавьте к этому надежную защиту Samsung Knox, интеллектуальный аккумулятор, супермощный процессор и большой объем памяти для всех ваших файлов. Откройте новую главу в истории мобильных устройств.",
                            Price = 37999M, Color = "Черный", Size = 16.69M, Date = Convert.ToDateTime("2/3/2020", culture),
                            ImagePath = "~/Content/Images/Products/Telephones/Samsung/Galaxy_S20_Ultra_Black.jpg"},
                new Product {Category = categories[0], Name = "Apple iPhone 7 32 GB (Black)",
                            Description = "Apple ежегодно говорит, что на этот раз выпускает «amasing» и «the best iPhone». iPhone 7 не был исключением. Шутить по этому поводу можно сколько угодно, но ведь так и есть: iPhone 7 — по многим пунктам считается одним из лучших смартфонов на рынке.",
                            Price = 9999M, Color = "Черный", Size = 13.83M, Date = Convert.ToDateTime("12/10/2018", culture),
                            ImagePath = "~/Content/Images/Products/Telephones/Apple/apple_iphone_7_32.jpg"},
                new Product {Category = categories[3], Name = "Apple watch series 5",
                            Description = " Смарт-часы Apple Watch Series 5 GPS 40mm Gold Aluminium Case with Pink Sand Sport Band",
                            Price = 12999M, Color = "Золотой", Size = 9M,  Date = Convert.ToDateTime("15/12/2019", culture),
                            ImagePath = "~/Content/Images/Products/Watches/Apple_watch_series_5_light.jpg"},
                new Product {Category = categories[0], Name = "Apple iPhone 11 64GB Green",
                            Description = "Apple iPhone 11 с объемом памяти 64 GB выполнен в элегантном зеленом оттенке. Впечатляющая аппаратная часть смартфона открывает новые возможности для повседневного пользования — гаджет будет хорошим помощником в ведении бизнеса, запечатлит лучшие мгновения в путешествии и сохранит бесценные воспоминания.",
                            Price = 22999M, Color = "Зеленый", Size = 13.2M, Date = Convert.ToDateTime("15/02/2019", culture), 
                            ImagePath = "~/Content/Images/Products/Telephones/Apple/apple_iphone_11.jpg"},
                new Product {Category = categories[1], Name = "Телевизор LG 43LM6300PLA", Description = "Экран Full HD передает изображение с удивительной точностью,  потрясающей разрешением и яркими цветами.",
                            Price = 9699M, Color = "Серый", Size = 57.2M, Date = Convert.ToDateTime("2/2/2020", culture),
                            ImagePath = "~/Content/Images/Products/TV/LG_43_smart.jpg"},
                new Product {Category = categories[1], Name = "Телевизор Kivi 32H700GU", Description = "Телевизоры KIVI могут похвастаться не только идеальным изображением, но и великолепным звуком. Для любой комнаты достаточно общей звуковой мощности 20 Вт. Наслаждайтесь яркой картинкой в тандеме с чистым и уникальным звуком.",
                            Price = 4777M, Color = "Серый", Size = 46.7M, Date = Convert.ToDateTime("7/1/2020", culture),
                            ImagePath = "~/Content/Images/Products/TV/Kivi_32.jpg"},
                new Product {Category = categories[1], Name = "Телевизор LG 55SM8600PLA", Description = "NanoCell TV — это самый совершенный LED-телевизор LG с превосходным качеством изображения, достигаемым благодаря фирменной технологии NanoCell™, улучшающей чистоту цветопередачи в диапазоне RGB.",
                            Price = 30399M, Color = "White", Size = 78.6M, Date = Convert.ToDateTime("7/1/2020", culture),
                            ImagePath = "~/Content/Images/Products/TV/LG_55S.jpg"},
                new Product {Category = categories[2], Name = "Ноутбук HP Pavilion 15-cs2053ur (7WG54EA)",
                            Description = "Мощный процессор Intel обеспечивает высокое быстродействие в многозадачном режиме. Смотрите видео, редактируйте фотографии, общайтесь с семьей и друзьями — ресурсов хватит на все задачи.",
                            Price = 16999M, Color = "Серебрянный", Size = 36.16M, Date = Convert.ToDateTime("24/2/2020", culture),
                            ImagePath = "~/Content/Images/Products/Laptops/Hp_pavilion_15.jpg"},
                new Product {Category = categories[2], Name = "Ноутбук LENOVO IdeaPad L340 Gaming (81LK00DARA)",
                            Description = "В игре очень важно умение делать правильный выбор. Выбирая игровой ноутбук Lenovo IdeaPad L340 (15), вы с самого начала принимаете правильное решение. Новейший процессор Intel Core, видеокарта нового поколения NVIDIA GeForce и потрясающая аудиосистема Dolby Audio позволят вам ощутить реальную мощь и плавность работы ноутбука. Вы всегда будете полностью готовы ко встрече с кем и чем угодно.",
                            Price = 20999M, Color = "Черный", Size = 25.46M, Date = Convert.ToDateTime("12/12/2019", culture),
                            ImagePath = "~/Content/Images/Products/Laptops/Lenovo_IdeaPad_L340.jpeg"},
                new Product {Category = categories[3], Name = "Фитнес-браслет Huawei AW61 Red", Description = "Надежный компаньен и помощник. Высокоточный мониторинг активности. Большой яркий дисплей. Современный дизайн.",
                            Price = 749M, Color = "Красный", Size = 7M, Date = Convert.ToDateTime("30/11/2019", culture),
                            ImagePath = "~/Content/Images/Products/Watches/Huawei_AW61.jpg"},
                new Product {Category = categories[4], Name = "Фен Philips EssentialCare BHC010/10",
                            Description = "Этот фен мощностью 1200 Вт создает воздушный поток оптимальной мощности и при этом бережно обращается с вашими волосами — все что нужно для достижения великолепных результатов день за днем.",
                            Price = 299M, Color = "Черный", Size = 20M, Date = Convert.ToDateTime("17/1/2020", culture),
                            ImagePath = "~/Content/Images/Products/Home/EssentialCare_BH.jpg"},
                new Product {Category = categories[0], Name = "Xiaomi Redmi Note 8T 4/64GB Blue (M1908C3XG)",
                            Description = "Корпус изготовлен из градиентного стекла 2.5D, которое устойчиво к повреждениям и эффектно выглядит. Большой дисплей диагональю 6.3 дюйма и уменьшенная капелька для фронтальной камеры позволили 90% поверхности отдать под рабочее пространство.​ Узкие рамки почти незаметны. Просмотр видео, картинок или игры на смартфоне станут ярче и реалистичнее.",
                            Price = 4999M, Size = 7.54M, Date = Convert.ToDateTime("11/2/2020", culture),
                            ImagePath = "~/Content/Images/Products/Telephones/Xiaomi/Redmi_Note_8_Blue.jpg"},
                new Product {Category = categories[3], Name = "Смарт-часы Huawei Watch GT 2 42mm DAN-B19 Gravel Beige Classic Edition",
                            Description = "Создатели HUAWEI WATCH GT поставили перед собой задачу выявить максимальный потенциал батареи смарт-часов. Благодаря двойному процессору для носимых устройств Kirin A1 (собственная разработка HUAWEI) и интеллектуальной технологии энергосбережения вы сможете пользоваться смарт-часами круглосуточно до 2 недель без подзарядки",
                            Price = 4999M, Size = 10M, Color = "Бежевый", Date = Convert.ToDateTime("5/3/2020"),
                            ImagePath = "~/Content/Images/Products/Watches/Huawei_watch_GT_2.png"},
                new Product {Category = categories[0], Name = "Huawei P Smart 2019 Aurora Blue",
                            Description = "Смартфон HUAWEI P smart 2019 оснащен ярким безрамочным экраном. Теперь вам предоставлен абсолютно безграничный обзор. Впечатляющие 6,21 дюйма и разрешение FHD+ (2340 x 1080) обеспечат высокое качество изображения.",
                            Price = 4999M, Size = 15.6M, Color = "Синий", Date = Convert.ToDateTime("5/3/2020"),
                            ImagePath = "~/Content/Images/Products/Telephones/Huawei/P_Smart_2019_Aurora_Blue.png"},
                new Product {Category = categories[0], Name = "Samsung Galaxy S10+ G975 Red",
                            Description = "Мы отказались от лишних элементов, чтобы ничто не отвлекало вас от происходящего на экране вашего смартфона. Благодаря технологии высокоточной лазерной обработки мы скрыли камеру внутри экрана, при этом сохранив высокое качество фотографии.",
                            Price = 24999M, Size = 15.7M, Color = "Красный", Date = Convert.ToDateTime("10/3/2020"),
                            ImagePath = "~/Content/Images/Products/Telephones/Samsung/Galaxy_s10plus_red.jpg"}
            };
            

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            context.Roles.Add(new Role { Id = 1, Name = "admin" });
            context.Roles.Add(new Role { Id = 2, Name = "user" });
            context.Roles.Add(new Role { Id = 3, Name = "ban" });
            context.Users.Add(new User
            {
                Id = 1,
                Email = "yurii@mail.com",
                Password = "qwerty",
                Age = 19,
                RoleId = 1
            });

            base.Seed(context);
        }
    }
}
