using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WCF.DataContract;
using WCF.EF;

namespace WCF.BusinessLogic
{
    public class BusinessLogic
    {
        static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        public static UserContract Login(UserContract user) {
            UserContract returnedUser = null;
            using (Model1 db = new Model1()) {
                try
                {
                    var result = db.Users.Where(i => i.email == user.email && i.password == Hash(user.password)).Select(i =>
                    new UserContract
                    {
                        id = i.id,
                        username = i.username,
                        assignedCategory = i.assignedCategory,
                        email = i.email,
                        roleId = i.roleId
                    }).FirstOrDefault();

                    returnedUser = result;
                }
                catch (Exception ex)
                {
                    throw new Exception("This user doesn't exist");
                }
            }

            return returnedUser;
        }

        public static bool Register(UserContract user)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    if (db.Users.Any(i => i.email.Equals(user.email) || i.username.Equals(user.username)))
                        throw new Exception("User already exists");

                    var password = Hash(user.password);

                    var newUser = new Users() { 
                        username = user.username,
                        password = password,
                        assignedCategory = null,
                        roleId = 0,
                        email = user.email
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("This user already exists");
                }
            }

            return false;
        }

        public static bool AddPost(PostContract post, CategoryContract category, UserContract user)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var newPost = new Posts()
                    {
                        title = post.title,
                        body = post.body,
                        userId = user.id,
                        categoryId = category.id
                    };

                    db.Posts.Add(newPost);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Post can't be created");
                }
            }

            return false;
        }

        public static bool AddReply(PostContract post, ReplyContract reply, UserContract user)
        {
            using (Model1 db = new Model1())
            {
                try
                {

                }
                catch (Exception ex)
                {
                    throw new Exception("Post can't be created");
                }
            }

            return false;
        }
    }
}