using DataAccesLayer.Contexts;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Comment
    {

        public static List<Comments> FetchComments()
        {
            MyWebCvContext Model = new MyWebCvContext();
            List<Comments> Liste = Model.Comments.ToList();
            return Liste;
        }

        public static void AddComments(DataTransferObject.Request.Comments data)
        {

            MyWebCvContext Model = new MyWebCvContext();
            Comments Nesne = new Comments();
            Nesne.Context = data.Context;
            Nesne.UserId = data.UserId;
            Nesne.Username = data.Username;
            Nesne.CreatedDate = DateTime.Now;
            Model.Comments.Add(Nesne);
            Model.SaveChanges();
        }
    }
}
