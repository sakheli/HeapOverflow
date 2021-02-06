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
        bool AddPost(PostContract post, int categoryId, int userId);

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
        [WebGet(UriTemplate = "/RemovePost/{userId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool RemovePost(int userId, PostContract post);

        [OperationContract]
        [WebGet(UriTemplate = "/AddMod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddMod(int adminId, int userId);

        [OperationContract]
        [WebGet(UriTemplate = "/RemoveMod", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool RemoveMod(int adminId, int userId);

        [OperationContract]
        [WebGet(UriTemplate = "/AddCategory", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddCategory(int adminId, CategoryContract category);

        [OperationContract]
        [WebGet(UriTemplate = "/RemoveCategory", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool RemoveCategory(int adminId, int categoryId);

        [OperationContract]
        [WebGet(UriTemplate = "/ChangeTitle", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool ChangeTitle(int userId, int postId, string title);

        [OperationContract]
        [WebGet(UriTemplate = "/GetUsers", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<UserContract> GetUsers();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCategories", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<CategoryContract> GetCategories();
    }
}
