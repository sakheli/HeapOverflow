using System;
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
        public bool AddPost(PostContract post, CategoryContract category, int userId)
        {
            return BusinessLogic.BusinessLogic.AddPost(post, category, userId);
        }

        public bool AddReply(PostContract post, ReplyContract reply, UserContract user)
        {
            return BusinessLogic.BusinessLogic.AddReply(post, reply, user);
        }

        public bool DeletePost(int userId, PostContract post)
        {
            return BusinessLogic.BusinessLogic.DeletePost(userId, post);
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
    }
}
