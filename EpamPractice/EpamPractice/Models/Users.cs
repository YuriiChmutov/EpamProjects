using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace EpamPractice.Models
{
    public class Users : IEnumerable<User>
    {
        public List<User> UsersList { get; set; }

        public IEnumerator<User> GetEnumerator()
        {
            return UsersList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}