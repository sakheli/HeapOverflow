﻿using System;
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

        public static UserContract Login(string email, string password) {
            UserContract returnedUser = null;
            using (Model1 db = new Model1()) {
                try
                {
                    var result = db.Users.Where(i => i.email == email && i.password == Hash(password)).Select(i =>
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

        public static bool AddPost(PostContract post, CategoryContract category, int userId)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var newPost = new Posts()
                    {
                        title = post.title,
                        body = post.body,
                        userId = userId,
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
                    var addedUser = db.Users.Where(x => x.id == user.id).FirstOrDefault();
                    var addedPost = db.Posts.Where(x => x.id == post.id).FirstOrDefault();
                    var newReply = new Replies()
                    {
                        body = reply.body,
                        Users = addedUser,
                    };
                    newReply.Posts.Add(addedPost);
                    addedPost.Replies.Add(newReply);
                    db.Replies.Add(newReply);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reply can't be created");
                }
            }

            return false;
        }


        public static List<PostContract> GetPosts(CategoryContract category)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var posts = db.Posts.Where(x => x.Category.id == category.id).ToList();
                    var returnedPosts = new List<PostContract>();

                    foreach (var post in posts)
                    {
                        var postReplies = post.Replies.Select(x => new ReplyContract
                        {
                            id = x.id,
                            body = x.body,
                            Users = new UserContract
                            {
                                id = x.Users.id,
                                username = x.Users.username,
                                email = x.Users.email
                            }
                        });
                        var postContract = new PostContract
                        {
                            id = post.id,
                            title = post.title,
                            body = post.body,
                            Category = new CategoryContract
                            {
                                id = post.Category.id,
                                categoryName = post.Category.categoryName
                            },
                            Replies = postReplies.ToList(),
                            Users = new UserContract
                            {
                                id = post.Users.id,
                                username = post.Users.username,
                                email = post.Users.email
                            }
                        };

                        returnedPosts.Add(postContract);
                    }
                  

                    return returnedPosts;
                }
                catch (Exception ex)
                {
                    throw new Exception("Posts not found.");
                }
            }

            return null;
        }

        public static PostContract GetPost(int id)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var post = db.Posts.Where(x => x.id == id).FirstOrDefault();
                    var postReplies = post.Replies.Select(x => new ReplyContract { 
                        id = x.id,
                        body = x.body,
                        Users = new UserContract {
                            id = x.Users.id,
                            username = x.Users.username,
                            email = x.Users.email
                        }
                    });
                    var postContract = new PostContract
                    {
                        id = post.id,
                        title = post.title,
                        body = post.body,
                        Category = new CategoryContract { 
                            id = post.Category.id,
                            categoryName = post.Category.categoryName
                        },
                        Replies = postReplies.ToList(),
                        Users = new UserContract
                        {
                            id = post.Users.id,
                            username = post.Users.username,
                            email = post.Users.email
                        }
                    };

                    return postContract;
                }
                catch (Exception ex)
                {
                    throw new Exception("Post not found");
                }
            }

            return null;
        }


        public static List<PostContract> GetPostsByUserId(int id)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var posts = db.Posts.Where(x => x.Users.id == id).ToList();
                    var returnedPosts = new List<PostContract>();

                    foreach (var post in posts)
                    {
                        var postReplies = post.Replies.Select(x => new ReplyContract
                        {
                            id = x.id,
                            body = x.body,
                            Users = new UserContract
                            {
                                id = x.Users.id,
                                username = x.Users.username,
                                email = x.Users.email
                            }
                        });
                        var postContract = new PostContract
                        {
                            id = post.id,
                            title = post.title,
                            body = post.body,
                            Category = new CategoryContract
                            {
                                id = post.Category.id,
                                categoryName = post.Category.categoryName
                            },
                            Replies = postReplies.ToList(),
                            Users = new UserContract
                            {
                                id = post.Users.id,
                                username = post.Users.username,
                                email = post.Users.email
                            }
                        };

                        returnedPosts.Add(postContract);
                    }


                    return returnedPosts;
                }
                catch (Exception ex)
                {
                    throw new Exception("Posts not found.");
                }
            }

            return null;
        }

        public static bool DeletePost(int userId, PostContract post)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var user = db.Users.Where(x => x.id == userId).FirstOrDefault();
                    var returnedPost = db.Posts.Where(x => x.id == post.id).FirstOrDefault();

                    if (user.id == returnedPost.Users.id || user.Roles.roleName == "admin" || (user.Roles.roleName == "mod" && returnedPost.Category.id == user.assignedCategory)) {
                        db.Posts.Remove(returnedPost);
                        db.SaveChanges();
                    } else
                    {
                        throw new Exception("You're not authorized to delete this post.");
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("You're not authorized to do this.");
                }
            }

            return false;
        }

        //public static bool AddMod(UserContract admin, int userId)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        try
        //        {
        //            if(admin.Roles.roleName == "admin") { }
        //            var returnedPost = db.Posts.Where(x => x.id == post.id).FirstOrDefault();

        //            if (user.id == returnedPost.Users.id || user.Roles.roleName == "admin" || (user.Roles.roleName == "mod" && returnedPost.Category.id == user.assignedCategory))
        //            {
        //                db.Posts.Remove(returnedPost);
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                throw new Exception("You're not authorized to delete this post.");
        //            }

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Unable to delete post.");
        //        }
        //    }

        //    return false;
        //}
    }
}