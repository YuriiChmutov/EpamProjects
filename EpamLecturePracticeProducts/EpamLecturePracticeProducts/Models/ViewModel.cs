using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DLL.Entities;

namespace EpamLecturePracticeProducts.Models
{
    public class ViewModel
    {
        private readonly List<Ganre> _ganres;
        public int SelectedGanreId { get; set; }
        public IEnumerable<SelectListItem> GanresList
        {
            get
            {
                return new SelectList(_ganres, "Id", "Title");
            }
        }
    }
}