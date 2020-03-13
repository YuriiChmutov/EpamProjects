using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Введите имя")]
        [Display (Name = "Имя пользователя")]
        [StringLength(20, MinimumLength =2, ErrorMessage = "Имя должно состоять из 2 - 20 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите свой возраст")]
        [Range(13, 99, ErrorMessage = "Вам должно быть 13 лет")]
        [Display(Name = "Сколько вам лет?")]
        public int Age { get; set; }


        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
