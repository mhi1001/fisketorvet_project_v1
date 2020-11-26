using System.Collections.Generic;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class SiteUserCatalog
    {
        private string filePath = @".\Data\SiteUser.json";

        private Dictionary<int, SiteUser> SiteUsers { get; set; }

        public Dictionary<int, SiteUser> GetAllSiteUsers()
        {
            return JsonReader.ReadSiteUserJson(filePath);
        }
        public int SiteAuth(string username, string password)//Method to authenticate users
        {
            SiteUsers = GetAllSiteUsers(); //Populate the Dictionary with all the existing users so we can test credentials
            //Cant figure out how to make it so when its true, it will also return Admin = true when passing to the controller class
            //So im going to make it return a integer and do a switchcase on the Login onpost method.
            foreach (SiteUser user in SiteUsers.Values)
            {
                if (user.UserName.Equals(username) && user.Password.Equals(password))
                {
                    if (user.Admin)
                    {
                        return 0; //If the user exists and is admin from the Json it will return number 0;
                    }
                    return 1;// if the user exists but isn't admin, it will return number 1;
                }

            }

            return 2; //in the end if the user is incorrect or something it will return 2 
        }

        //public bool SiteAuth(SiteUser user)//Method to authenticate users
        //{
        //    SiteUsers = GetAllSiteUsers(); //Populate the Dictionary with all the existing users so we can test credentials

        //    return SiteUsers.ContainsValue(user);
        //}
    }


}
