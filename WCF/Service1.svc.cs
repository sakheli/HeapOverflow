﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.DataContract;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool AddPost(PostContract post, int categoryId, int userId)
        {
            return BusinessLogic.BusinessLogic.AddPost(post, categoryId, userId);
        }

        public bool AddReply(int postId, string replyBody, int userId)
        {
            return BusinessLogic.BusinessLogic.AddReply(postId, replyBody, userId);
        }

        public bool RemovePost(int userId, PostContract post)
        {
            return BusinessLogic.BusinessLogic.RemovePost(userId, post);
        }

        public PostContract GetPost(int id)
        {
            return BusinessLogic.BusinessLogic.GetPost(id);
        }

        public List<PostContract> GetPosts(CategoryContract category)
        {
            return BusinessLogic.BusinessLogic.GetPosts(category);
        }

        public List<PostContract> GetPostsByUserId(int id)
        {
            return BusinessLogic.BusinessLogic.GetPostsByUserId(id);
        }

        public UserContract Login(string email, string password)
        {
            return BusinessLogic.BusinessLogic.Login(email, password);
        }

        public bool Register(UserContract user)
        {
            return BusinessLogic.BusinessLogic.Register(user);
        }

        public bool AddMod(int adminId, int userId)
        {
            return BusinessLogic.BusinessLogic.AddMod(adminId, userId);
        }

        public bool RemoveMod(int adminId, int userId)
        {
            return BusinessLogic.BusinessLogic.RemoveMod(adminId, userId);
        }

        public bool AddCategory(int adminId, CategoryContract category)
        {
            return BusinessLogic.BusinessLogic.AddCategory(adminId, category);
        }

        public bool RemoveCategory(int adminId, int categoryId)
        {
            return BusinessLogic.BusinessLogic.RemoveCategory(adminId, categoryId);
        }

        public bool ChangeTitle(int userId, int postId, string title)
        {
            return BusinessLogic.BusinessLogic.ChangeTitle(userId, postId, title);
        }

        public List<UserContract> GetUsers()
        {
            return BusinessLogic.BusinessLogic.GetUsers();
        }

        public List<CategoryContract> GetCategories()
        {
            return BusinessLogic.BusinessLogic.GetCategories();
        }
    }
}
