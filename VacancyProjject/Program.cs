using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using static VacancyProject.Program;

namespace VacancyProject
{
    internal class Program
    {
        // Employer 





        public class JobApplication
        {
            public int JobId { get; }
            public string CV { get; }
            public string ApplicantEmail { get; }

            public JobApplication(int jobId, string cv, string applicantEmail)
            {
                JobId = jobId;
                CV = cv;
                ApplicantEmail = applicantEmail;
            }
        }

        public class Employer
        {

            public List<JobApplication> JobApplications { get; set; }

            public static int JobID { get; set; }
            public string Name { get; set; }
            public string  Passwword { get; set; }

            public string Email { get; set; }
            public string CompanyName { get; set; }
            public string PhoneNumber { get; set; }
            public List<JobPosting> JobPostings { get; set; }

            public Employer()
            {
                
                Name    = string.Empty;
                Passwword = string.Empty;
                Email = string.Empty;
                CompanyName = string.Empty;
                PhoneNumber = string.Empty;
                JobApplications = new List<JobApplication>();
            

        }
            public bool hasvalue = false;

            public void ShowJobApplications()
            {
                Console.WriteLine("Job Applications:");
                foreach (var application in JobApplications)
                {
                    Console.WriteLine($"Job ID: {application.JobId}, Applicant Email: {application.ApplicantEmail}");
                }
            }
            public void ApplyForJob(int jobId, string cv, string applicantEmail)
            {
                hasvalue= true;
                JobApplication application = new JobApplication(jobId, cv, applicantEmail);
                JobApplications.Add(application);
                Console.WriteLine($"Secilen  ID {jobId} Geden eemail  {applicantEmail}");
            }


            public Employer(string name, string companyName, string email, string phoneNumber, string password)
            {
                Name = name;
                CompanyName = companyName;
                Email = email;
                this.Passwword = password;
                PhoneNumber = phoneNumber;

                JobPostings = new List<JobPosting>();
                JobApplications = new List<JobApplication>();
            }

            public void AddJobPosting(JobPosting jobPosting)
            {
                JobPostings.Add(jobPosting);
            }

            public void ShowEmployer()
            {
                Console.WriteLine($"Name ->  {Name}");
                Console.WriteLine($"company name ->  {CompanyName}");
                Console.WriteLine($"Email ->  {Email}");
                Console.WriteLine($"password ->  {Passwword}");
                Console.WriteLine($"Phone Number {PhoneNumber}");


            }


            public Employer AddEmployer()
            {
                Console.WriteLine("Enter Employer Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Company Name: ");
                string companyName = Console.ReadLine();

                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();

                Employer newEmployer = new Employer(name, companyName, email, phoneNumber, password);
                return newEmployer;
            }



            public bool IsValidLogin(string userEmail, string userPassword)
            {
                return Email == userEmail && Passwword == userPassword;
            }
            public void ShowJobPostings()
            {
                    JobID = 1;
                foreach (var jobPosting in JobPostings)
                {
                    Console.WriteLine($"Job Id : {JobID++} ");
                    Console.WriteLine($"Job Title: {jobPosting.Title}");
                    Console.WriteLine($"Description: {jobPosting.Description}");
                    Console.WriteLine($"Salary: {jobPosting.Salary}");
                    Console.WriteLine($"Location: {jobPosting.Location}");
                    Console.WriteLine(new string('-', 30)); 
                }
            }
        
        }

        public class JobPosting
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Salary { get; set; }
            public string Location { get; set; }
            public  int IdJob = 1;

            public JobPosting()
            {

            }
            public JobPosting(string title, string description, decimal salary, string location)
            {
                Title = title;
                Description = description;
                Salary = salary;
                Location = location;
            }


        }


        public class Admin
        {
            public string? email { get; set; }
            private string? _password;
            public string? Password
            {
                get { return _password; }
                set
                {
                    if (IsPasswordValid(value))
                    {
                        _password = value;
                    }
                    else
                    {
                        throw new ArgumentException("Şifre geçerli bir deseni karşılamıyor.");
                    }
                }
            }

            private bool IsPasswordValid(string? password)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                // Şifrenin belirli bir deseni karşılamasını sağlayan Regex
                string pattern = @"^(?=.*[A-Z])(?=.*\d).*$";
                return Regex.IsMatch(password, pattern);
            }

            public Admin()
            {

            }

            public Admin(string? email)
            {
                this.email = email;
            }
        }


        public class CvInformation
        {
            public string? Email { get; set; }
            public string? Skills { get; set; }
            public string? Experience  { get; set; }

            public string? PhoneNumber { get; set; }

            public CvInformation()
            {
                Email = "Doldurulmayib";
                Skills = "Doldurulmayib ";
                Experience = "Doldurulmayib";
                PhoneNumber = "Doldurulmayib ";

            }
            public CvInformation(string? email, string? skills, string? experience, string? phoneNumber)
            {
                Email = email;
                Skills = skills;
                Experience = experience;
                PhoneNumber = phoneNumber;
            }

            public void FillCvInformation()
            {
                Console.WriteLine("Enter your email: ");
                Email = Console.ReadLine();

                Console.WriteLine("Enter your skills: ");
                Skills = Console.ReadLine();

                Console.WriteLine("Enter your Experience");
                Experience = Console.ReadLine();
                Console.WriteLine("Enter your Phone Number ");
                PhoneNumber = Console.ReadLine();
                ShowCv();
            }


            public void ShowCv()
            {
                Console.WriteLine($"Email : {this.Email} ");
                Console.WriteLine($"Skills : {this.Skills} ");
                Console.WriteLine($"Experience : {this.Experience} ");
                Console.WriteLine($"Phone Number  : {this.PhoneNumber} ");

            }
        }




        public class Worker
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Skills { get; set; }
            public string? Language { get; set; }
            public string? city { get; set; }
            public CvInformation CvInfo { get; set; }
            
            public string? phoneNumber { get; set; }
            public string? Email { get; set; }
            private string? _password;
            public string? Password
            {
                get { return _password; }
                set { _password = value; }
            }


            public void ShowCvInformation()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Surname: " + Surname);
                Console.WriteLine("Skills: " + Skills);
                Console.WriteLine("Language: " + Language);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone number: " + phoneNumber);
                Console.WriteLine("City: " + city);
                // CV bilgilerini ekrana yazdırabilirsiniz
            }

            public Worker()
            {
                Name = null;
                Surname = null;
                Skills = null;
                Language = null;
                Email = null;
                Password = null;
                city = null;
                phoneNumber = null;
            }
            public void FillWorkerInformation()
            {
                Console.WriteLine("Name: ");
                Name = Console.ReadLine();

                Console.WriteLine(" Surname: ");
                Surname = Console.ReadLine();

                CvInfo = new CvInformation();
                CvInfo.FillCvInformation();
            }


            public  void WorkerAdd(List<Worker> workers)
            {
                Console.WriteLine("Name : ");
                string EmpName = Console.ReadLine();

                Console.WriteLine("Surname :");
                string EmpSurname = Console.ReadLine();

                Console.WriteLine("Skills ");
                string EmpSkills = Console.ReadLine();

                Console.WriteLine("Language: ");
                string EmpLanguage = Console.ReadLine();

                Console.WriteLine("Email :  ");
                string EmpEmail = Console.ReadLine();

                Console.WriteLine("Password : ");
                string EmpPassword = Console.ReadLine();

                Console.WriteLine("City: ");
                string WCity = Console.ReadLine();

                Console.WriteLine("Phone number : ");
                string WPhoneNumber = Console.ReadLine();

                Worker newWorker = new Worker(EmpName, EmpSurname, EmpSkills, EmpLanguage, EmpEmail, EmpPassword, WPhoneNumber, WCity);
                workers.Add(newWorker);

                Console.WriteLine("Worker added successfully!");
            }


            public Worker(string? name, string? surname, string? skills, string? language, string? email, string? password, string? phoneNumber, string? city)
            {
                Name = name;
                Surname = surname;
                Skills = skills;
                Language = language;
                Email = email;
                Password = password;
                this.phoneNumber = phoneNumber;
                this.city = city;

                File.WriteAllText("Worker.txt", "Name: " + name + "\nSurname: " + surname + "\nSkills: " + skills + "\nLanguage: " + language + "\nEmail : " + email + "\nPassword: " + password);
            }

           public  void ShowWorker () 
            {
                Console.WriteLine("Worker"); // +++
                Console.WriteLine("Name : "+ Name);
                Console.WriteLine("Surname : " + Surname);
                Console.WriteLine("Skills :" + Skills);
                Console.WriteLine("language : " + Language);
                Console.WriteLine("Email : " + Email);
                Console.WriteLine("Phone number : " + phoneNumber);
                Console.WriteLine("City : " + city      );

            }
        }

        static void SendEmail(string toEmail, string subject, string body)
        {
            string toAddress = "recipient@example.com";

            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru")
            {
                Port = 587,
                Credentials = new NetworkCredential("your_email@mail.ru", "YourMail.ruPassword"),
                EnableSsl = false,
            };

            try
            {
                MailMessage mailMessage = new MailMessage("your_email@mail.ru", toAddress, subject, body);
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                var errorTime = DateTime.Now;
                File.WriteAllText("Error.txt", ex.Message + " Ayin tarixi " + errorTime);
            }
        }

        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Worker worker = new Worker();
            admin.Password = "Salam1234";
            admin.email = "turqaymammadovt@gmail.com";

            worker.Password = "Salam12345";
            worker.Email = "turqayy.111@mail.ru";
            worker.Surname = "Mammadov";
            worker.Name = "Turqay";
            worker.Skills = "C++";
            worker.Language = "English";

            Employer employer = new Employer("Turqay", "dasqalaati", "turqay@mail.ru", "154875", "12345");

            JobPosting job1 = new JobPosting("C++", "Devoloper ", 1000, "Israil");
            JobPosting job2 = new JobPosting("C", "Devoloper ", 2000, "America");
            JobPosting job3 = new JobPosting("Java", "Devoloper ", 1500, "Baku");
            JobPosting job4 = new JobPosting("C# ", "Devoloper ", 2500, "New York ");
            JobPosting job5 = new JobPosting("C#/C++ ", "Devoloper ", 3500, "Naxcivan  ");


            employer.AddJobPosting(job1);
            employer.AddJobPosting(job2);
            employer.AddJobPosting(job3);
            employer.AddJobPosting(job4);
            employer.AddJobPosting(job5);

            Console.WriteLine(" _    __                                                                                         \r\n| |  / /___ __________ _____  _______  __\r\n| | / / __ `/ ___/ __ `/ __ \\/ ___/ / / /\r\n| |/ / /_/ / /__/ /_/ / / / / /__/ /_/ / \r\n|___/\\__,_/\\___/\\__,_/_/ /_/\\___/\\__, /  \r\n                                /____/   ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("[1] Admin\n[2] Employer\n[3] Register\n [4] Worker ");
                        Console.WriteLine("Select : ");
                        string input = Console.ReadLine();
                        int vacancySelect = int.Parse(input);
                        while (true)
                        {


                            if (vacancySelect == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Admin Email : ");
                                string AdEmail = Console.ReadLine();

                                Console.WriteLine("Admin Password:  ");
                                string Adpassword = Console.ReadLine();

                                if (AdEmail == admin.email && Adpassword == admin.Password)
                                {
                                    Console.WriteLine("Welcome Admin ");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    Console.WriteLine("[1]All Employer \n [2]All Worker \n [3]All vakansiya  ");
                                    int secimAdmin = int.Parse(Console.ReadLine());
                                    if (secimAdmin == 1)
                                    {
                                        employer.ShowEmployer();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;

                                    }
                                    else if (secimAdmin == 2)
                                    {
                                        worker.ShowCvInformation();
                                        Console.WriteLine("Worker password" + worker.Password);
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    }
                                    else if (secimAdmin == 3)
                                    {
                                        employer.ShowJobPostings();
                                        break;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Duzgun informasiya daxil edilmemisdir !");
                                        Thread.Sleep(2000);
                                        Console.ResetColor();
                                        Console.Clear();
                                        break;
                                    }
                                }

                            }

                            else if (vacancySelect == 2)
                            {
                                Console.WriteLine("Email : ");
                                string Emailw = Console.ReadLine();

                                Console.WriteLine("Password:  ");
                                string passwordw = Console.ReadLine();

                                //Employer employer = new Employer("Turqay","dasqalaati" , "turqay@mail.ru" , "154875" , "12345");


                                if (employer.Email == Emailw && employer.Passwword == passwordw)
                                {
                                    Console.WriteLine("Login successful!");
                                    // Diğer işlemler burada devam edebilir
                                    Console.WriteLine("Employer Welcome ! ");
                                    Thread.Sleep(2000);
                                    Console.Clear();

                                    //+++++++++++++++++++++Employer secimi ++++++++++++++++++ 


                                    while (true)
                                    {
                                        Console.WriteLine("[1]Company add\n[2] Vakansiyalara bax \n [3] Muraciet edenler \n [4] Vakansiyalarim\n[5]Back ");
                                        int sec = int.Parse(Console.ReadLine());


                                        if (sec == 1)
                                        {

                                            Console.WriteLine("Vakansiya elave edilir,,,,\n");
                                            Console.WriteLine("Adi : ");
                                            string JobName = Console.ReadLine();
                                            Console.WriteLine("isin aydinlanmasi : ");
                                            string JobDescr = Console.ReadLine();
                                            Console.WriteLine("Maas : ");
                                            int JobSalary = int.Parse(Console.ReadLine());
                                            Console.WriteLine("City : ");
                                            string JobCity = Console.ReadLine();
                                            if (JobName != null && JobSalary != null)
                                            {
                                                JobPosting job6 = new JobPosting(JobName, JobDescr, JobSalary, JobCity);

                                                employer.AddJobPosting(job6);
                                                JobPosting JOB;

                                                Console.WriteLine($"Job Postings by {employer.CompanyName}:");
                                                employer.ShowJobPostings();


                                            }
                                            else
                                            {
                                                Console.WriteLine("Name invalid or  Password invalid ");
                                            }
                                            Console.WriteLine("");
                                        }

                                        else if (sec == 2)
                                        {
                                            Console.WriteLine("Vakansiyalar yuklenir  .. ");

                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            employer.ShowJobPostings();
                                            continue;


                                        }

                                        else if (sec == 3)
                                        {
                                            if (employer.ApplyForJob != null)
                                            {
                                                employer.ShowJobApplications();
                                            }
                                            else
                                            {
                                                Thread.Sleep(2000);
                                                Console.WriteLine("mURACIET Eden yoxdu ");
                                                break;
                                            }

                                        }
                                        else if (sec == 4)
                                        {
                                            Console.WriteLine("Muracietler yuklenir ... ");
                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            employer.ShowJobPostings();
                                            continue;

                                        }
                                        else if (sec == 5)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Invalid email or password. Please try again.");
                                }
                            }


                            else if (vacancySelect == 3)

                            {

                                Console.WriteLine("Register ");
                                Console.WriteLine("[1]Worker ");
                                Console.WriteLine("[2]Employer ");
                                Console.WriteLine("[3] Back");

                                int secim = int.Parse(Console.ReadLine());


                                while (true)
                                {

                                    if (secim == 1)
                                    {
                                        List<Worker> workers = new List<Worker>();
                                        worker.WorkerAdd(workers);

                                        Console.Clear();
                                        Console.WriteLine("Datalar qeyd olundu ! ");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    }
                                    else if (secim == 2)
                                    {
                                        employer.AddEmployer();
                                        Console.WriteLine("Datalar qeyd olunurr ./// ");
                                        Thread.Sleep(2000);
                                        Console.Clear();

                                        break;

                                    }
                                    else if (secim == 3)
                                    {
                                        Console.WriteLine("Datalar geriye yuklenir ... ");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;


                                    }
                                }


                            }

                            else if (vacancySelect == 4)
                            {
                                Console.WriteLine("Worker Emailinizi qeyd edin : ");
                                string UsernameW = Console.ReadLine();

                                Console.WriteLine("Password : ");
                                string PasswordW = Console.ReadLine();
                                try
                                {

                                    if (UsernameW == worker.Email && PasswordW == worker.Password)
                                    {

                                        Console.WriteLine($"{worker.Name} Worker Xow gelmisiniz ... ");

                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        Console.WriteLine("[1]Vakansiyalara bax\n [2] CV hazirla \n [3] Cv \n [4]Back ");

                                        Console.WriteLine("Secim edin : "); int WSecim = int.Parse(Console.ReadLine());
                                        while (true)
                                        {


                                            if ((int)WSecim == 1)
                                            {
                                                JobPosting job = new JobPosting();

                                                Console.WriteLine("<- Vakansiyalar -> ");
                                                //Thread.Sleep(2000);
                                                //Console.Clear();
                                                employer.ShowJobPostings();
                                                Console.WriteLine("Secdiyiniz vakansiyalarin Id si qeyd edin : ");
                                                int selectedJobId = int.Parse(Console.ReadLine());
                                                ///*Employer*/ emp = new Employer();
                                                ///
                                                //JobPosting selectedJob = employer.JKobPostings.Find(job => job.IdJob == selectedJobId);
                                                if (selectedJobId == job.IdJob || selectedJobId == job1.IdJob || selectedJobId == job2.IdJob ||
                                                   selectedJobId == job3.IdJob ||
                                                  selectedJobId == job4.IdJob ||
                                                 selectedJobId == job5.IdJob)

                                                {
                                                    Console.WriteLine("Muraciet edilir ... ");
                                                    //Thread.Sleep(2000);
                                                    Console.Clear();
                                                    Console.WriteLine("Muraciet hazirdir ... ");
                                                    //Console.Clear();
                                                    employer.ApplyForJob(selectedJobId, "turqayy.111@mail.ru", "turqayy.111@mail.ru");

                                                    break;


                                                }
                                                else
                                                {
                                                    Console.WriteLine("id yanlisdir ");
                                                    break;
                                                }

                                            }

                                            else if (WSecim == 2)
                                            {
                                                Console.WriteLine("Cv hazirlanir .. ");
                                                worker.FillWorkerInformation();
                                                break;

                                            }

                                            else if (WSecim == 3)
                                            {
                                                Console.WriteLine("  _____    \r\n / ___/  __\r\n/ /__| |/ /\r\n\\___/|___/ \r\n          ");

                                                CvInformation cv = new CvInformation();
                                                if (worker.CvInfo.Email != null || worker.CvInfo.Experience != null)
                                                {

                                                    Console.WriteLine($"Email - > {worker.CvInfo.Email} ");
                                                    Console.WriteLine($"Experinece - > {worker.CvInfo.Experience} ");
                                                    Console.WriteLine($"Phone Number ->{worker.CvInfo.PhoneNumber}");
                                                    Console.WriteLine($"Skills-> {worker.CvInfo.Skills}");

                                                    Thread.Sleep(2000);

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Qeyd edilen Cv niz tapilmadi !");
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                }
                                                Console.Clear();
                                                break;
                                            }

                                            else if (WSecim == 4)
                                            {
                                                Console.WriteLine("Backeddd");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Duzgun olunmadi !");
                                                break;
                                            }
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Eror - > " + ex);
                                    File.WriteAllText("WorkerEror.txt", ex.Message);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.Message);
                File.WriteAllText("ErorAll.txt", ex.Message);
            
            }
      }
    }
}
