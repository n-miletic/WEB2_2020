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

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class UserDbManager
    {
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

        public static User GetLoggedUser(string username)
        {
            using (var _context = new DiemServiceDB())
            {
                User retVal = _context.UserDbSet.Where(user => user.Username == username).Include(x => x.FriendRequestsSent).Include(x => x.Friends).Include(x => x.PendingFriends).FirstOrDefault();
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
                return _context.UserDbSet.Where(u => u.Role != Role.Admin).Where(u => u.Username != loggedUsername).ToList();
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
                if ( logIn != null)
                {
                    if(logIn.Hash == password)
                    {
                        return new UserGift(TokenManager.GetToken(logIn),logIn);
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

            }
        }


    }
}