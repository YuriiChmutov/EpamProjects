using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EShop.DAL.Entities;
using EShop.DAL.Repositories;
using EShop.DAL.EF;

namespace EShop.WEB.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //Нахождение ролей для пользователей по их имени (1 роль для 1 рользователя)
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { }; //нет роли
            using(EShopContext db = new EShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == username); //находим пользователя по имени
                if(user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId); //находим роль
                    if(userRole != null)
                    {
                        roles = new string[] { userRole.Name }; //присваиваем роль 
                    }
                }
            }
            return roles; 

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //Выдана ли пользователю роль
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (EShopContext db = new EShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == username); //находим пользователя по имени
                if (user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId); //находим роль
                    if (userRole != null && userRole.Name == roleName) //роль совпадает с roleName?
                    {
                        outputResult = true;  
                    }
                }
            }
            return outputResult;


        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
    }
}