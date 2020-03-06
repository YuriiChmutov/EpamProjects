using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Entities
{
    /// <summary>
    /// Класс, дающий возможность проверить и выполнить заказ.
    /// </summary>
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните адрессную строку")]
        public string Line1 { get; set; }
        [Required(ErrorMessage = "Введите ваш мобильный номер")]
        
        public string Telephone { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Введите название города")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите название области")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
