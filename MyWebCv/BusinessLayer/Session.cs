using DataAccesLayer.Contexts;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Session
    {
        public static void AddUser(DataTransferObject.Response.Users data)
        {
            MyWebCvContext Model = new MyWebCvContext();
            Users Nesne = new Users();
            Nesne.FirstName = data.FirstName;
            Nesne.LastName = data.LastName;
            Nesne.Email = data.Email;
            Nesne.Username = data.Username;
            Nesne.Password = data.Password;
            Model.Users.Add(Nesne);
            Model.SaveChanges();
        }
    }
}
