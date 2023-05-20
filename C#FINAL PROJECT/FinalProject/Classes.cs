using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using FinalProject;
using System.Text.Json;

namespace FinalProject
{
    // RESUME CLASS ----(resumeni Boss.az in iscileride filder edir)
    partial class Resume
    {
        private string? name;
        private string? sername;
        private string? fonnumber;
        private string? mail;
        private string? education;
        private string? skills;
        private string? jobexperience;
        private string? ID;
        public partial void Show__Resume();

        
    }
    //------------------------------------------------------------------


    // JOBADVERTISEMENT CLASS-----------------------------------------
    partial class JobAdvertisement
    {
        private string? city;
        private string? age;
        private string? gender;
        private DateOnly? deedline;
        private string? name;
        private string? fonnumber;
        private string? mail;
        private string? ınfoaboutjob;
        private string? ID;
        public partial void Show__JOB_ADD();



    }
    //----------------------------------------------------------------


    // BASE CLASS ---(which contains all unfiltered resumes and JobAdvertisements)
    partial class Base : IaddResume, IJobAdd
    {
        public static List<Resume> resumes = new List<Resume> { };        // unfiltered resumes
        public static List<JobAdvertisement> jobs = new List<JobAdvertisement> { }; // unfiltered JobAdvertisements
        public partial void AddResume(Resume resume);
        public partial  void AddJobAdd(JobAdvertisement jobAdvertisement);
    }
    //---------------------------------------------------------------


    // STAFFOFBOSS.AZ CLASS ---- (who filter all resumes and jobadvertisements)
    // StaffofBoss.az class inherits from Base class to filter
    partial class StaffofBossaz : Base,IsendMail
    {
        public  partial void sortResume();
        public partial void sortJobAdvertisement();

        public void SendMail(string mail, string info)
        {
            
            
            MailMessage message = new MailMessage();
            message.From = new MailAddress("meracomarov@gmail.com");
            message.To.Add(new MailAddress(mail));
            message.Subject = "From Stuff of Boss.az";
            message.Body = $"<html><body> {info} </body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("meracomarov@gmail.com", "ijfyshtkwzrilalc"),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
        
    }
    //-------------------------------------------------------------


    // FILTERED__RESUMES CLASS ---- (which contain all resumes *filtered)
    class FilteredResumes
    {
        public static List<Resume> filteredCVs= new List<Resume> {};
    }
    //---------------------------------------------------------------------------


    // FILTERED__JOBADVERTISEMENTS CLASS ----- (which contain all jobadvertisements *filtered)
    class FilteredJobAdvertisements
    {
        public static List<JobAdvertisement> FilteredJobAdd = new List<JobAdvertisement> { };
    }


    // WORKER CLASS --- IS AXTARAN
    partial class WORKER:FilteredJobAdvertisements,ICreateResume,IsendMail
    {
        public partial Resume CreateResume(string? name, string? sername, string? fonnumber, string? mail, string? education, string? skills, string? jobexperience);
        public partial void LookJobadvertisements();
        public void SendMail(string mail, string info)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("meracomarov@gmail.com");
            message.To.Add(new MailAddress(mail));
            message.Subject = "From Stuff of Boss.az";
            message.Body = $"<html><body> {info} </body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("meracomarov@gmail.com", "ijfyshtkwzrilalc"),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
        public partial void CreateCVforCompany();
       
    }
    //------------------------------------------------------------------------


    // COMPANY CLASS --- ISE GOTUREN
    partial class COMPANY:FilteredResumes, ICreateJobAdd,IsendMail
    {
        public partial JobAdvertisement CreateJobAdd(string? city, string? age, string? gender, DateOnly? deedline, string? name, string? fonnumber, string? mail, string? infoaboutjob);
        public  partial void LookProperCVs();
        public partial void CreateAddForWorkers();

        public void SendMail(string mail,string info)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("meracomarov@gmail.com");
            message.To.Add(new MailAddress(mail));
            message.Subject = "From Stuff of Boss.az";
            message.Body = $"<html><body> {info} </body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("meracomarov@gmail.com", "ijfyshtkwzrilalc"),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
    }
    //----------------------------------------------------------------------


    // MENU CLASS 

    class MyMenu
    {
        public static void UPARROW()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wellome to Boss.az");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                      SEARCH");
            Console.ForegroundColor = ConsoleColor.White;                                       
            Console.WriteLine("                                                                  Stuff of Boss.az");
            Console.ForegroundColor = ConsoleColor.White;
        }    
        public static void DOWNARROW()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wellome to Boss.az");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                      SEARCH");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                  Stuff of Boss.az");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SECONDuparrow()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                            ---- WORKER ----");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                            ---- COMPANY ----");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SECONDdownarrow()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                            ---- WORKER ----");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                            ---- COMPANY ----");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void THird_UPARROW()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wellome to Boss.az");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                          LOOK JOB_ADVERTISEMENTS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                             INCLUDE YOUR RESUME");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CompanyPart()
        {
            while (true)
            {
                
                COMPANY cOMPANY = new();
                Console.WriteLine("---- Look resumes // click UpArrow");
                Console.WriteLine();
                Console.WriteLine("---- Create JobAdvertisement // click DownArrow");
                Console.WriteLine();
                Console.WriteLine("---- Exite // BAckspace");
                Console.WriteLine();

                var command = Console.ReadKey();
                if (command.Key == ConsoleKey.UpArrow)
                {
                   // Console.Clear();
                    cOMPANY.LookProperCVs();
                }
                else if (command.Key == ConsoleKey.DownArrow)
                {
                    cOMPANY.CreateAddForWorkers();
                }
                else if (command.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    Console.WriteLine("                                                    ---- WORKER ----");
                    Console.WriteLine("                                                    ---- COMPANY ----");
                    break;
                }
            }
        }   // menynun COMPANY hissesi
        public static void WorkerPart()
        {
            while (true)
            {
                Console.Clear();
                WORKER wORKER = new WORKER();
                Console.WriteLine("---- Look Job_Advertisements // click  UpArrow");
                Console.WriteLine();
                Console.WriteLine("---- Create Resume for Companies // click DownArrow");
                Console.WriteLine();
                Console.WriteLine("---- exit // click backspace");
                Console.WriteLine();
                var command = Console.ReadKey();
                if (command.Key == ConsoleKey.UpArrow)
                {
                    wORKER.LookJobadvertisements();
                }
                else if(command.Key == ConsoleKey.DownArrow)
                {
                    wORKER.CreateCVforCompany();
                }
                else if(command.Key==ConsoleKey.Backspace)
                {
                    Console.Clear();
                    Console.WriteLine("                                                    ---- WORKER ----");
                    Console.WriteLine("                                                    ---- COMPANY ----");
                    break;
                }
            }
            
        }  // menyunun WORKER hissesi
        public static void SearchPart()
        {
            bool sweech2 = false;
           
            while (true)
            {
              
                var choise2 = Console.ReadKey();
                if (choise2.Key == ConsoleKey.UpArrow)
                {
                    sweech2 = true;
                    SECONDuparrow();
                }
                else if (choise2.Key == ConsoleKey.DownArrow)
                {
                    sweech2 = false;
                    SECONDdownarrow();
                }
                else if (choise2.Key == ConsoleKey.Enter)
                {
                    if (sweech2 == false)     // Company part
                    {
                        CompanyPart();
                    }
                    else if (sweech2 == true)  // Worker part
                    {
                        WorkerPart();
                    }
                }
                else if (choise2.Key == ConsoleKey.Backspace)
                {

                    Console.Clear();
                    Console.WriteLine("Wellome to Boss.az");
                    Console.WriteLine("                                                              SEARCH ");
                    Console.WriteLine("                                                          Stuff of Boss.az");
                    break;
                }

            }
        }   // menyunun SEARCH hissesi WORKER ve Company bura daxildir.
        public static void StuffofBossaz()   // menyunun STUFF OF BOSS.aZ hissesi.
        {
            //Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----  Parolu daxil edin");
                Console.ForegroundColor = ConsoleColor.White;
                
                string include_parol= include_parol = Console.ReadLine(); ;
                while (include_parol!="Admin")
                {
                      Console.Clear();
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("----  Parolu yeniden daxil edin !!!!");
                      Console.ForegroundColor = ConsoleColor.White;
                include_parol = Console.ReadLine();
                }
                string parol = "Admin";
                Regex regex = new Regex(parol);
                if (regex.IsMatch(include_parol))
                {
                    while (true)
                    {
                        Console.Clear();
                        StaffofBossaz staffofBossaz = new StaffofBossaz();
                        Console.WriteLine("---- click uparrow for SORTING RESUMES");
                        Console.WriteLine();
                        Console.WriteLine("---- click downarrow for SORTING JOB ADVERTISEMENTS");
                        Console.WriteLine();
                        Console.WriteLine("---- click backspace for exiting");
                        Console.WriteLine();
                        var command = Console.ReadKey();
                        if (command.Key == ConsoleKey.DownArrow)
                        {
                            staffofBossaz.sortJobAdvertisement();
                        }
                        else if (command.Key == ConsoleKey.UpArrow)
                        {
                            staffofBossaz.sortResume();
                        }
                        else if (command.Key == ConsoleKey.Backspace)
                        {

                          Console.Clear();
                          Console.WriteLine("Wellome to Boss.az");
                          Console.WriteLine("                                                        SEARCH ");
                          Console.WriteLine("                                                    Stuff of Boss.az");
                        break;
                        }
                    }

                }            
        }
        public static void Menu()
        {
            Console.WriteLine("Wellome to Boss.az");
            Console.WriteLine("                                                                      SEARCH ");
            Console.WriteLine("                                                                  Stuff of Boss.az");
            bool sweech = false;
            while (true)
            {
                
                var choise = Console.ReadKey();
                if (choise.Key == ConsoleKey.UpArrow)
                {
                    sweech = true;
                    UPARROW();
                    
                    
                }
                else if (choise.Key == ConsoleKey.DownArrow)
                {
                    sweech = false;
                    DOWNARROW();
                }
                else if (choise.Key == ConsoleKey.Enter)
                {
                    
                  
                    if (sweech == true)     // serch part
                    {
                        Console.Clear();
                        Console.WriteLine("                                                            ---- WORKER ----");
                        Console.WriteLine("                                                            ---- COMPANY ----");
                        SearchPart();
                    }
                    else if (sweech == false)  // stuff of boss az part
                    {
                        Console.Clear();
                        StuffofBossaz();
                    }
                }
                Console.WriteLine("Click UpArrow for Search");
                Console.WriteLine("Click DownArrow for stuff of Boss.az");
                Console.WriteLine("Click Backspace for exit");
            }



            
            
        }
    }
















    // -------------------------------------------------   Partial part    ------------------------------------------

    partial class Resume  // Resume
    {
        public Resume(string? name, string? sername, string? fonnumber, string? mail, string? education, string? skills, string? jobexperience)
        {
            Name = name;
            Sername = sername;
            Fonnumber = fonnumber;
            Mail = mail;
            Education = education;
            Skills = skills;
            Jobexperience = jobexperience;
            this.ID = Guid.NewGuid().ToString();
        }

        public string? Name
        {
            get => name;
            set
            {
                if (value == null || value.ContainsDigit())
                {
                    throw new ArgumentNullException("Incorrect format");
                } 
                else
                {
                    name = value;   
                }
            }
        }
        public string? Sername
        {
            get => sername;
            set
            {
                if (value == null || value.ContainsDigit())
                {
                    throw new ArgumentNullException("Incorrect format");
                }
                else
                {
                    sername = value;
                }
                
            }
        }
        public string? Fonnumber
        {
            get => fonnumber;
            set
            {
                if (value == null || value.ContainsString()) throw new ArgumentNullException("Incorrect format");
                this.fonnumber = value;
            }
        }
        public string? Mail
        {
            get => mail;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.mail=value;
            }
        }
        public string? Education
        {
            get => education;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.education = value;
            }
        }
        public string? Skills
        {
            get => skills;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.skills = value;
            }
        }
        public string? Jobexperience
        {
            get => jobexperience;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.jobexperience = value; 
            }
        }

        public  partial void Show__Resume()
        {
            Console.WriteLine(this.ID);
            Console.WriteLine(this.name);
            Console.WriteLine(this.sername);
            Console.WriteLine(this.fonnumber);
            Console.WriteLine(this.mail);
            Console.WriteLine(this.education);
            Console.WriteLine(this.skills);
            Console.WriteLine(this.jobexperience);
           
        }
    }
    //--------------------------------------------------------------------------------------
    partial class JobAdvertisement  // JobAdvertisement
    {
        public JobAdvertisement(string? city, string? age_, string? gender, DateOnly? deedline, string? name, string? fonnumber, string? mail, string? ınfoaboutjob)
        {
            City = city;
            Age = age_;
            Gender = gender;
            Deedline = deedline;
            Name = name;
            Fonnumber = fonnumber;
            Mail = mail;
            Infoaboutjob = ınfoaboutjob;
            this.ID=Guid.NewGuid().ToString();
        }

        public string? City
        {
            get => city;
            set
            {
                if (value == null || value.ContainsDigit()) throw new ArgumentNullException("Incorrect Format");
                this.city = value;
            }
        }
        public string? Age
        {
            get => age;
            set
            {
                if (value == null || value.ContainsString()) throw new ArgumentNullException("Incorrect Format");
                this.age = value;
            }
        }
        public string? Gender
        {
            get => gender;
            set
            {
                if (value == "male" || value=="famale")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentNullException("incorrect format");
                }
                  
            }
        }
        public DateOnly? Deedline
        {
            get => deedline;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.deedline = value;
            }
        }
        public string? Name
        {
            get => name;
            set
            {
                if (value == null || value.ContainsDigit()) throw new ArgumentNullException("Xanani doldurun");
                this.name = value;
            }
        }
        public string? Fonnumber
        {
            get => fonnumber;
            set
            {
                if (value == null || value.ContainsString()) throw new ArgumentNullException("Xanani doldurun");
                this.fonnumber = value; 
            }
        }
        public string? Mail
        {
            get => mail;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                mail = value;
            }
        }
        public string? Infoaboutjob
        {
            get => ınfoaboutjob;
            set
            {
                if (value == null) throw new ArgumentNullException("Xanani doldurun");
                this.ınfoaboutjob = value;
            }
        }

        public partial void Show__JOB_ADD()
        {
            Console.WriteLine(this.ID);
            Console.WriteLine(this.Age);
            Console.WriteLine(this.Gender);
            Console.WriteLine(this.City);
            Console.WriteLine(this.Deedline);
            Console.WriteLine(this.Fonnumber);
            Console.WriteLine(this.Gender);
            Console.WriteLine(this.Infoaboutjob);
            Console.WriteLine(this.Mail);
            Console.WriteLine(this.Name);
        }
    }
    //----------------------------------------------------------------------------
    partial class Base : IaddResume, IJobAdd //Base
    {
        public partial void AddResume(Resume resume)
        {
            resumes.Add(resume);
        }

        public partial void AddJobAdd(JobAdvertisement jobAdvertisement)
        {
            jobs.Add(jobAdvertisement);
        }

    } // Base
    //-------------------------------------------------------------------------
    partial class StaffofBossaz : Base,IsendMail // StaffofBossaz
    {
        public  partial void sortResume()  // this funtion helps to look at resumes and if you want you can add them to Filtered_resumes class
        {
            int step=-1;
            while (true)
            {
               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------   DownArrow //listin sonuna");
                Console.WriteLine();
                Console.WriteLine("---------------------------   UpArrow  // listin evveline");
                Console.WriteLine();
                Console.WriteLine("---------------------------   Enter   // CV ni filtered_resumes class a gondermek");
                Console.WriteLine();
                Console.WriteLine("---------------------------   C // duzelislerle bagli feedback  etmek CV gonderene");
                Console.WriteLine();
                Console.WriteLine("---------------------------   Backspace // exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                var choise = Console.ReadKey();
                if (choise.Key == ConsoleKey.DownArrow)   //listin sonuna 
                {
                    Console.Clear();
                    if (resumes.Count!=0)
                    {
                        if(step< resumes.Count-1)step++;
                        resumes[step].Show__Resume();
                        
                       
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                      
                }
                else if (choise.Key == ConsoleKey.UpArrow) // listin evveline 
                {
                    Console.Clear();
                    if ( step>-1 && resumes.Count != 0)
                    {
                        if(step>0)step--;
                        resumes[step].Show__Resume();
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                       
                }
                else if (choise.Key == ConsoleKey.Enter) // CV ni filtered_resumes class a gondermek 
                {
                    Console.Clear();
                    if (resumes.Count!=0)
                    {
                        FilteredResumes.filteredCVs.Add(resumes[step]);
                        resumes.RemoveAt(step);
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }    

                }
                else if (choise.Key == ConsoleKey.C)   // duzelislerle bagli feedback  etmek CV gonderene
                {
                    if (resumes.Count != 0)
                    {
                        Console.WriteLine("include your feedback");
                        string info = Console.ReadLine();
                        SendMail(resumes[step].Mail, info);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                   
                }
                else if (choise.Key == ConsoleKey.Backspace) break;  // cixis

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----  Proses sona catdi");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public partial void sortJobAdvertisement()
        {
            int step = -1;
            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("--------------------------------  DownArrow //listin sonuna");
                Console.WriteLine();
                Console.WriteLine("--------------------------------  UpArrow  // listin evveline");
                Console.WriteLine();
                Console.WriteLine("--------------------------------  Enter   // JOBADD i filtered_JOBADD class a gondermek");
                Console.WriteLine();
                Console.WriteLine("--------------------------------  C // duzelislerle bagli feedback  etmek CV gonderene");
                Console.WriteLine();
                Console.WriteLine("--------------------------------  Backspace // exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                var choise = Console.ReadKey();
                if (choise.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    if (jobs.Count!=0)
                    {
                        if(step<jobs.Count-1) step++;
                        jobs[step].Show__JOB_ADD();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertimesent YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                }
                else if (choise.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    if (step > -1 && jobs.Count!=0)
                    {
                        if(step>0)step--;
                        jobs[step].Show__JOB_ADD();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertisement YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                      
                }
                else if (choise.Key == ConsoleKey.Enter)
                {
                    if (jobs.Count!=0)
                    {
                        FilteredJobAdvertisements.FilteredJobAdd.Add(jobs[step]);
                        jobs.RemoveAt(step);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertisement YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.C)
                {
                    if (jobs.Count!=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("---- Include your feedback");
                        Console.ForegroundColor = ConsoleColor.White; string info = Console.ReadLine();
                        SendMail(jobs[step].Mail, info);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertisement YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (choise.Key == ConsoleKey.Backspace) break;

            }

        }
    }///// adition class for extention string method for checking if string contains number
    //------------------------------------------------------------------------------------------------
    public static class StringExtensions
    {
        public static bool ContainsDigit(this string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsString(this string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c) == false)
                {
                    return true;
                }
            }
            return false;
        }
    } ///// adition class for extention int method for checking if int contains char or string
    //------------------------------------------------------------------------------------
    partial class WORKER:FilteredJobAdvertisements,ICreateResume,IsendMail // worker
    {
        public partial Resume CreateResume(string? name, string? sername, string? fonnumber, string? mail, string? education, string? skills, string? jobexperience)
        {
            return new Resume(name, sername, fonnumber, mail, education, skills, jobexperience);
        }

        public partial void LookJobadvertisements()
        {
            Console.Clear();
            int step = -1;
            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("-------------------------- DownArrow //listin sonuna");
                Console.WriteLine();    
                Console.WriteLine("-------------------------- UpArrow  // listin evveline");
                Console.WriteLine();    
                Console.WriteLine("-------------------------- Enter   // CV ni company e  gondermek");
                Console.WriteLine();  
                Console.WriteLine("-------------------------- Backspace // exit");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                var choise = Console.ReadKey();
                if (choise.Key == ConsoleKey.DownArrow)
                {
                   
                    Console.Clear();
                    if (FilteredJobAdd.Count != 0)
                    {
                        if(step<FilteredJobAdd.Count-1)step++;
                        FilteredJobAdd[step].Show__JOB_ADD();
                        
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Avertisement YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    if (step > -1 && FilteredJobAdd.Count != 0)
                    {
                        if(step>0)step--;
                        FilteredJobAdd[step].Show__JOB_ADD();
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertisement YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.Enter)   // applying for a job (evvel CV yaradir sonra avtomatik ise goturenin mail ne mail gedir)
                {
                    if (FilteredJobAdd.Count != 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("----  INclude your Resume info ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("INCLUDE NAME:");
                        string NAME = Console.ReadLine();
                        Console.WriteLine("INCLUDE SERNAME:");
                        string SERNAME = Console.ReadLine();
                        Console.WriteLine("INCLUDE FONNUMBER:");
                        string FONNUMBER = Console.ReadLine();
                        Console.WriteLine("INCLUDE MAIL:");
                        string MAIL = Console.ReadLine();
                        Console.WriteLine("INCLUDE EDUCATION:");
                        string EDUCATION = Console.ReadLine();
                        Console.WriteLine("INCLUDE SKILLS:");
                        string SKILLS = Console.ReadLine();
                        Console.WriteLine("INCLUDE JOBEXPERIENCE:");
                        string JOBEXPERIENCE = Console.ReadLine();
                        var resume = CreateResume(NAME, SERNAME, FONNUMBER, MAIL, EDUCATION, SKILLS, JOBEXPERIENCE);
                        var option = new JsonSerializerOptions { WriteIndented = true };
                        var info= JsonSerializer.Serialize(resume,option);
                        SendMail(FilteredJobAdd[step].Mail,info.ToString());
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  Advertiment YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.Backspace) break;  // cixis

            }
        }

        public partial void CreateCVforCompany()
        {
            Console.Clear();
            Console.WriteLine("INCLUDE NAME:");
            string NAME = Console.ReadLine();
            Console.WriteLine("INCLUDE SERNAME:");
            string SERNAME = Console.ReadLine();
            Console.WriteLine("INCLUDE FONNUMBER:");
            string FONNUMBER = Console.ReadLine();
            Console.WriteLine("INCLUDE MAIL:");
            string MAIL = Console.ReadLine();
            Console.WriteLine("INCLUDE EDUCATION:");
            string EDUCATION = Console.ReadLine();
            Console.WriteLine("INCLUDE SKILLS:");
            string SKILLS = Console.ReadLine();
            Console.WriteLine("INCLUDE JOBEXPERIENCE:");
            string JOBEXPERIENCE = Console.ReadLine();
            Base.resumes.Add(CreateResume(NAME, SERNAME, FONNUMBER, MAIL, EDUCATION, SKILLS, JOBEXPERIENCE));
        }


    }
    //------------------------------------------------------------------------
    partial class COMPANY: FilteredResumes, ICreateJobAdd, IsendMail // company
    {
        public partial JobAdvertisement CreateJobAdd(string? city, string? age, string? gender, DateOnly? deedline, string? name, string? fonnumber, string? mail, string? infoaboutjob)
        {
            return new JobAdvertisement(city, age, gender, deedline, name, fonnumber, mail, infoaboutjob);
        }
        public  partial void LookProperCVs()
        {
            Console.Clear();
            int step = -1;
            while (true)
            {
             
                Console.ForegroundColor=ConsoleColor.Green;  
                Console.WriteLine("----------------------- DownArrow //listin sonuna");
                Console.WriteLine();
                Console.WriteLine("----------------------- UpArrow  // listin evveline");
                Console.WriteLine();
                Console.WriteLine("----------------------- Enter   //  Kandidatin mailine mesaj gondermek");
                Console.WriteLine();
                Console.WriteLine("----------------------- Backspace // exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                var choise = Console.ReadKey();
                if (choise.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    if (filteredCVs.Count != 0)
                    {
                        if (step < filteredCVs.Count - 1) step++;
                        filteredCVs[step].Show__Resume();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    if (step > -1 && filteredCVs.Count != 0)
                    {
                        if (step > 0) step--;
                        filteredCVs[step].Show__Resume();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else if (choise.Key == ConsoleKey.Enter)   //Kandidatin mailine mesaj gondermek
                {
                    if (filteredCVs.Count != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("---- Include info");
                        Console.ForegroundColor = ConsoleColor.White; string info = Console.ReadLine();
                        SendMail(filteredCVs[step].Mail, info);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----  Bazada  RESUME YOXDUR !!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (choise.Key == ConsoleKey.Backspace) // cixis
                {
                    Console.Clear();
                    break;
                }
                 

            }
        }

        public partial void CreateAddForWorkers()
        {
            Console.Clear();
            Console.WriteLine("INCLUDE CITY:");
            string CITY = Console.ReadLine();
            Console.WriteLine("INCLUDE AGE:");
            string AGE = Console.ReadLine();
            Console.WriteLine("INCLUDE GENDER:");
            string GENDER = Console.ReadLine();
            Console.WriteLine("INCLUDE DEEDLINE:");
            Console.WriteLine("INCLUDE year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("INCLUDE month:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("INCLUDE day:");
            int day = int.Parse(Console.ReadLine());
            DateOnly dateOnly = new DateOnly(year, month, day);
            Console.WriteLine("INCLUDE NAME:");
            string NAME = Console.ReadLine();
            Console.WriteLine("INCLUDE FONNUMBER:");
            string FONNUMBER = Console.ReadLine();
            Console.WriteLine("INCLUDE MAIL:");
            string MAIL = Console.ReadLine();
            Console.WriteLine("INCLUDE INFO_ABOUT_JOB:");
            string INFOABOUTJOB = Console.ReadLine();
            Base.jobs.Add(CreateJobAdd(CITY, AGE, GENDER, dateOnly, NAME,FONNUMBER, MAIL, INFOABOUTJOB));
        }
    }
}










