using DataAccesLayer.Contexts;
using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Home
    {
        public static Datas Datas()
        {
            MyWebCvContext Model = new MyWebCvContext();
            Datas Nesne = Model.Datas.FirstOrDefault();
            return Nesne;
        }


        public static List<Projects> projects()
        {
            MyWebCvContext Model = new MyWebCvContext();
            List<Projects> Liste = Model.Projects.ToList();
            return Liste;
        }


        public static List<Skills> skills()
        {
            MyWebCvContext Model = new MyWebCvContext();
            List<Skills> Liste = Model.Skills.ToList();
            return Liste;
        }

    }
}
