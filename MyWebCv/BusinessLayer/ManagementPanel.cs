using DataAccesLayer.Contexts;
using DataAccesLayer.Entities;
using DataTransferObject.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Entities;

namespace BusinessLayer
{
    public class ManagementPanel
    {

        public static DataAccesLayer.Entities.Datas DatasReturn()
        {
            MyWebCvContext Model = new MyWebCvContext();
            DataAccesLayer.Entities.Datas Nesne = Model.Datas.FirstOrDefault();
            return Nesne;

        }


        public static void DatasUpdate(DataTransferObject.Request.Datas data)
        {
            MyWebCvContext Model = new MyWebCvContext();
            DataAccesLayer.Entities.Datas Nesne = Model.Datas.FirstOrDefault();

            Nesne.Title = data.Title;
            Nesne.About = data.About;
            Nesne.Mobile = data.Mobile;
            Nesne.Email = data.Email;
            Nesne.Address = data.Address;
            Nesne.Education = data.Education;
            Model.SaveChanges();

        }

        public static void AddProject(DataTransferObject.Request.Projects data)
        {
            MyWebCvContext Model = new MyWebCvContext();
            DataAccesLayer.Entities.Projects Nesne = new DataAccesLayer.Entities.Projects();
            Nesne.Project = data.project;
            Model.Projects.Add(Nesne);
            Model.SaveChanges();
        }


        public static void AddSkill(DataTransferObject.Request.Skills data)
        {
            MyWebCvContext Model = new MyWebCvContext();
            DataAccesLayer.Entities.Skills Nesne = new DataAccesLayer.Entities.Skills();
            Nesne.Skill = data.Skill;
            Model.Skills.Add(Nesne);
            Model.SaveChanges();
        }

    }
}
