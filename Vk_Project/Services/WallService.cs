using RestSharp;
using Vk_Project.Constants;
using Vk_Project.Models;
using Vk_Project.Utils;

namespace Vk_Project.Services
{
    public class WallService : BaseService, IWallService
    {
        public Root CreatePostOnWall(string message)
        {
            var request = new RestRequest(
                $"{Endpoints.WallPost}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Message}{message}&" +
                $"{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}", Method.Post);
            var response = RestClient.Execute<Root>(request);

            return response.Data;
        }

        public Root GetUploadUrl()
        {
            var restRequest = new RestRequest(
                $"{Endpoints.UploadUrl}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Token}&" +
                $"{Constant.V}{Configurator.GetConfig()["Version"]}", Method.Get);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }

        public Root LoadPhoto(string url, string fileName, string path)
        {
            var restRequest = new RestRequest($"{url}", Method.Post);
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddFile(fileName, path);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }

        public SavePhotoModel SavePhoto(int server, string photo, string hash)
        {
            var restRequest =
                new RestRequest(
                    $"{Constant.BaseUrl}{Endpoints.SaveWallPhoto}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Server}{server}" +
                    $"&{Constant.Photo}{photo}&{Constant.Hash}{hash}&{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}",
                    Method.Get);

            var response = RestClient.Execute<SavePhotoModel>(restRequest);

            return response.Data;
        }

        public Root EditWallPost(long ownerId, long photoId, int postId, string message)
        {
            var restRequest =
                new RestRequest(
                    $"{Constant.BaseUrl}{Endpoints.EditWallPost}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Message}{message}" +
                    $"&{Constant.Attachments}{Constant.PhotoAttachment}{ownerId}_{photoId}&{Constant.PostId}{postId}&{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}",
                    Method.Post);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }

        public Root CreateWallComment(long ownerId, int updatePostId, string message)
        {
            var restRequest =
                new RestRequest(
                    $"{Constant.BaseUrl}{Endpoints.CreateComment}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Message}{message}" +
                    $"&{Constant.OwnerId}{ownerId}&{Constant.PostId}{updatePostId}&{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}",
                    Method.Post);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }

        public Root CheckLikeOnPost(int postId, long ownerId)
        {
            var restRequest = new RestRequest(
                $"{Constant.BaseUrl}{Endpoints.IsLiked}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.Type}" +
                $"{Constant.PostType}&{Constant.OwnerId}" +
                $"{ownerId}&{Constant.ItemId}{postId}&{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}",
                Method.Get);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }

        public Root DeletePost(int postId, long ownerId)
        {
            var restRequest = new RestRequest(
                $"{Constant.BaseUrl}{Endpoints.DeletePost}{Constant.UserId}{Configurator.GetConfig()["Id"]}&{Constant.OwnerId}{ownerId}" +
                $"&{Constant.PostId}{postId}&{Constant.Token}&{Constant.V}{Configurator.GetConfig()["Version"]}",
                Method.Get);

            var response = RestClient.Execute<Root>(restRequest);

            return response.Data;
        }
    }
}