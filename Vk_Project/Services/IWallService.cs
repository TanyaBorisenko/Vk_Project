using Vk_Project.Models;

namespace Vk_Project.Services
{
    public interface IWallService
    {
        public Root CreatePostOnWall(string message);
        public Root GetUploadUrl();
        public Root LoadPhoto(string url, string fileName, string path);
        public SavePhotoModel SavePhoto(int server, string photo, string hash);
        public Root EditWallPost(long ownerId, long photoId, int postId, string message);
        public Root CreateWallComment(long ownerId, int updatePostId, string message);
        public Root CheckLikeOnPost(int postId, long ownerId);
        public Root DeletePost(int postId, long ownerId);
    }
}