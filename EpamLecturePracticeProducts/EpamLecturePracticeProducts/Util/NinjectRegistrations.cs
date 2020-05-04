using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.DLL.Entities;
using Ninject.Modules;
using Entity.DLL.Interfaces;
using EpamLecturePracticeProducts.Repository;

namespace EpamLecturePracticeProducts.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Book>>().To<BookRepository>();
        }
    }
}