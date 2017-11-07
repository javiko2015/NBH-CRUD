using BusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Security.Cryptography;
using BusinessLogic.Enumerators;
using System.Data.Entity.Core.Objects;

namespace BusinessLogic
{
    public class AccountLogic
    {
        /// <summary>
        /// Encrypts a string into MD5 algorythm
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns>string encrypted in MD5</returns>
        public string Encrypt(string stringToEncrypt)
        {
            Byte[] stringInBytes = new UnicodeEncoding().GetBytes(stringToEncrypt);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(stringInBytes);

            return BitConverter.ToString(hashedBytes);
        }

        /// <summary>
        /// Register a new applicant into the system
        /// </summary>
        /// <param name="applicant">Applicant general info</param>
        public void RegisterNewApplicant(ApplicantBusinessModel applicant)
        {
            var password = this.Encrypt(applicant.Password);

            using (var ctx = new EmployeeApplicationConnectionString())
            {
                var counter = ctx.Users.Count(u => u.Email.ToUpper().Trim() == applicant.Email.Trim().ToUpper());
                var counter1 = ctx.Users.Count(u => u.UserName.ToUpper().Trim() == applicant.UserName.Trim().ToUpper());
                if (counter == 0)
                {
                    if (counter1==0)
                    {
                        var user = new User
                        {
                            Email = applicant.Email,
                            FirstName = applicant.FirstName,
                            LastName = applicant.LastName,
                            Password = password,
                            UserName = applicant.UserName
                        };

                        ctx.Users.Add(user);
                        ctx.SaveChanges();

                        var savedUser = ctx.Users.FirstOrDefault(u => u.Email.ToUpper().Trim() == applicant.Email.ToUpper().Trim());
                        if (savedUser != null)
                        {
                            var applic = new Applicant
                            {
                                MobileNumber = applicant.MobileNumber,
                                UserId = savedUser.UserId
                            };
                            ctx.Applicants.Add(applic);
                            ctx.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new Exception($"Username({applicant.UserName}) already exists");
                    }
                }
                else
                {
                    throw new Exception($"Email({applicant.Email}) already exists");
                }
            }
        }

        /// <summary>
        /// User login based on its username and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public LoginBusinessModel Login(string userName, string password)
        {
            var result = new LoginBusinessModel();
            var encryptedPass = this.Encrypt(password);

            using (var ctx = new EmployeeApplicationConnectionString())
            {
                var user = ctx.Users.Include("Applicants")
                                    .Include("CompanyManagers")
                                    .FirstOrDefault(u => (u.UserName.Trim().ToUpper() == userName.Trim().ToUpper() && u.Password == encryptedPass)|| (u.Email.Trim().ToUpper() == userName.Trim().ToUpper() && u.Password == encryptedPass));
                if (user != null)
                {
                    result = new LoginBusinessModel
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName
                    };

                    if (user.Applicants != null)
                    {
                        result.UserType = (int)UserTypeEnum.Applicant;
                        if (user.Applicants.Count > 0)
                        {
                            result.MobileNumber = user.Applicants.ElementAt(0).MobileNumber;
                        }
                    }
                    else
                    {
                        result.UserType = (int)UserTypeEnum.CompanyManager;
                        if (user.CompanyManagers != null)
                        {
                            if (user.CompanyManagers.Count > 0)
                            {
                                result.CompanyName = user.CompanyManagers.ElementAt(0).CompanyName;
                            }
                        }
                    }
                }
            }

            return result;
        }


       /* public List<ApplicationBusinessModel> ApplicationsList(long userid)
        {

            List<ApplicationBusinessModel> app = new List<ApplicationBusinessModel>();

            List<Application> acces = new List<Application>();

            using (var ctx = new EmployeeApplicationConnectionString())
            {
                acces = ctx.Applications.Where(x => x.UserId == userid).ToList();




                if (acces != null)
                {
                    foreach(elem )

                    app = new LoginBusinessModel
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName
                    };
                }







            } 

         return app;
        }*/



    }
}
