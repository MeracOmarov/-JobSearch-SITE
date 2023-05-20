using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface IaddResume
    {
        void AddResume(Resume resume);
    }
    interface ICreateResume
    {
         Resume CreateResume(string? name, string? sername, string? fonnumber, string? mail, string? education, string? skills, string? jobexperience);

    }
    
    interface IJobAdd
    {
        void  AddJobAdd(JobAdvertisement jobAdvertisement);
    }

    interface ICreateJobAdd
    {
        JobAdvertisement CreateJobAdd(string? city, string? age, string? gender, DateOnly? deedline, string? name, string? fonnumber, string? mail, string? infoaboutjob);
    }


    interface IsendMail
    { 
      void SendMail(string mail, string info);
    }

}
