using DiemService.Authorization;
using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Data.Entity;
using DiemService.DTO;
using System.Security.Claims;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class UserDbManager
    {
        public static UserGift EditUser(EditUserForm form)
        {
            if (form == null)
                throw new Exception("BAD");
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                if(String.IsNullOrEmpty(form.Hash) || found.Hash != form.Hash )
                    throw new Exception("EW");
                if (!String.IsNullOrEmpty(form.Name) && form.Name != found.Name)
                    found.Name = form.Name;
                if (!String.IsNullOrEmpty(form.LastName) && found.LastName != form.LastName)
                    found.LastName = form.LastName;
                if (!String.IsNullOrEmpty(form.Email)  && found.Email != form.Email)
                    found.Email = form.Email;
                if (!String.IsNullOrEmpty(form.Username)  && found.Username != form.Username)
                    found.Username = form.Username;
                if (!String.IsNullOrEmpty(form.NewHash))
                    found.Hash = form.NewHash;
                _context.SaveChanges();

                return new UserGift(TokenManager.GetToken(found), found);
            }
        }
        public static List<object> GetHardcoreUsers()
        {
            List<object> retVal = new List<object>();
            using(var _context = new DiemServiceDB())
            {
                List<User> s = _context.UserDbSet.Where(u => u.Role != Role.Admin).ToList();
                foreach (User basic in s)
                {
                    switch (basic.Role)
                    {
                        case Role.RegisteredUser:
                            retVal.Add(basic);
                            break;
                        case Role.AdminAvio:
                            retVal.Add(new AdminAvioDTO(basic, _context));
                            break;
                        case Role.AdminRentACar:
                            retVal.Add(new AdminRentDTO(basic, _context));
                            break;
                        default:
                            break;
                    }
                }
                return retVal;
            }
        }
       

        public static User GetUser(int userid)
        {
            using (var _context = new DiemServiceDB())
            {
                
                return _context.UserDbSet.Find(userid);
            }
        }

        public static object GetLoggedUser(string username)
        {
            using (var _context = new DiemServiceDB())
            {
                User retVal = _context.UserDbSet.Where(user => user.Username == username).Include(x => x.FriendRequestsSent).Include(x => x.Friends).Include(x => x.PendingFriends).FirstOrDefault();
                switch (retVal.Role)
                {
                        case Role.RegisteredUser:
                            return new RegisteredUserDTO(retVal, _context);
                        case Role.AdminAvio:
                            return new AdminAvioDTO(retVal, _context);
                        case Role.AdminRentACar:
                            return new AdminRentDTO(retVal, _context);
                }
                return retVal;
            }
        }



        public static List<User> GetUsers()
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.Where(u=> u.Role != Role.Admin).ToList();
            }
        }

        public static List<User> GetUsers(string loggedUsername)
        {
            using (var _context = new DiemServiceDB())
            {
                User caller = _context.UserDbSet.Where(u => u.Username == loggedUsername).Include(u=> u.Friends).FirstOrDefault();
                List<User> allUsers = _context.UserDbSet.Where(u => u.Role != Role.Admin).Where(u => u.Username != loggedUsername).ToList();
                return allUsers.Where(u => !caller.Friends.Contains(u)).ToList();
                
            }
        }

        public static void AcceptRequest(string from, string to)
        {
            using (var _context = new DiemServiceDB())
            {
                User fromUser = _context.UserDbSet.Where(s => s.Username == from).Include(x => x.PendingFriends).Include(x=>x.Friends).FirstOrDefault();
                User toUser = _context.UserDbSet.Where(s => s.Username == to).Include(x => x.FriendRequestsSent).Include(x => x.Friends).FirstOrDefault();

                fromUser.PendingFriends.Remove(toUser);
                toUser.FriendRequestsSent.Remove(fromUser);
                fromUser.Friends.Add(toUser);
                toUser.Friends.Add(fromUser);
                _context.SaveChanges();
            }
        }

        public static void DeclineRequest(string from, string to)
        {
            using (var _context = new DiemServiceDB())
            {
                User fromUser = _context.UserDbSet.Where(s => s.Username == from).Include(x => x.PendingFriends).FirstOrDefault();
                User toUser = _context.UserDbSet.Where(s => s.Username == to).Include(x => x.FriendRequestsSent).FirstOrDefault();

                fromUser.PendingFriends.Remove(toUser);
                toUser.FriendRequestsSent.Remove(fromUser);
                _context.SaveChanges();
            }
        }

        public static void UnfriendRequest(string from, string to)
        {
            using (var _context = new DiemServiceDB())
            {
                User fromUser = _context.UserDbSet.Where(s => s.Username == from).Include(x => x.Friends).FirstOrDefault();
                User toUser = _context.UserDbSet.Where(s => s.Username == to).Include(x => x.Friends).FirstOrDefault();

                fromUser.Friends.Remove(toUser);
                toUser.Friends.Remove(fromUser);
                _context.SaveChanges();
            }
        }
        public static UserGift LogIn(string username,string password)
        {
            using(var _context = new DiemServiceDB())
            {
                User logIn = _context.UserDbSet.Where(s => s.Username == username).Include(x => x.FriendRequestsSent).Include(x => x.Friends).Include(x => x.PendingFriends).FirstOrDefault();
                object optionalReturn = logIn;
                if ( logIn != null)
                {
                    
                    switch (logIn.Role)
                    {
                        case Role.RegisteredUser:
                            optionalReturn =  new RegisteredUserDTO(logIn, _context);
                            break;
                        case Role.AdminAvio:
                            optionalReturn =  new AdminAvioDTO(logIn, _context);
                            break;
                        case Role.AdminRentACar:
                            optionalReturn =  new AdminRentDTO(logIn, _context);
                            break;
                         default:
                            break;
                    }
                    if (logIn.Hash == password)
                    {
                        return new UserGift(TokenManager.GetToken(logIn), optionalReturn);
                    }
                }
                throw new Exception("Pogresna loyinka, ili je juzer nepostojeci");
            }
        }

        public static void SendRequest(string from, string to)
        {
            using(var _context = new DiemServiceDB())
            {
                User fromUser = _context.UserDbSet.Where(s => s.Username == from).Include(x=> x.FriendRequestsSent).FirstOrDefault();
                User toUser = _context.UserDbSet.Where(s => s.Username == to).Include(x=> x.PendingFriends).FirstOrDefault();

                toUser.PendingFriends.Add(fromUser);

                fromUser.FriendRequestsSent.Add(toUser);
                _context.SaveChanges();

                List <User> all = _context.UserDbSet.Include(x => x.FriendRequestsSent).Include(x => x.Friends).Include(x => x.PendingFriends).ToList();

            }
        }


    }
}