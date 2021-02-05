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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Login", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        UserContract Login(string email, string password);

        [OperationContract]
        [WebGet(UriTemplate = "/Register", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Register(UserContract user);

        [OperationContract]
        [WebGet(UriTemplate = "/AddPost", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddPost(PostContract post, CategoryContract category, int userId);

        [OperationContract]
        [WebGet(UriTemplate = "/AddReply", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddReply(PostContract post, ReplyContract reply, UserContract user);

        [OperationContract]
        [WebGet(UriTemplate = "/GetPosts", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<PostContract> GetPosts(CategoryContract category);

        [OperationContract]
        [WebGet(UriTemplate = "/GetPost/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        PostContract GetPost(int id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetPostsByUserId/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<PostContract> GetPostsByUserId(int id);

        [OperationContract]
        [WebGet(UriTemplate = "/DeletePost/{userId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool DeletePost(int userId, PostContract post);
    }
}
