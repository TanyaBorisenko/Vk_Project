using System.IO;
using System.Linq;
using NUnit.Framework;
using Vk_Project.Pages;
using Vk_Project.Services;
using Vk_Project.Utils;

namespace Vk_Project.Test
{
    public class TestCaseTests : BaseTest
    {
        private readonly IWallService _wallService;
        private readonly MainPage _mainPage;
        private readonly EnterPasswordPage _enterPasswordPage;
        private readonly FeedPage _feedPage;
        private readonly MyPage _myPage;
        private readonly string _userName = Configurator.GetTestDataSettings()["UserName"];
        private readonly string _password = Configurator.GetTestDataSettings()["Password"];
        private readonly string _userId = "https://vk.com/id627657327";
        private readonly string _text = TestDataGenerated.GenerateSomeText();
        private static readonly string _photoName = "1234.jpg";
        private readonly int _expectedLikesCount = 1;
        private readonly string _photoPath = Path.GetFullPath(_photoName);

        public TestCaseTests()
        {
            _wallService = new WallService();
            _mainPage = new MainPage();
            _enterPasswordPage = new EnterPasswordPage();
            _feedPage = new FeedPage();
            _myPage = new MyPage();
        }

        [Test]
        public void TestCase()
        {
            //Open page and login
            _mainPage.EnterUserName(_userName);
            _mainPage.ClickLogInButton();
            _enterPasswordPage.EnterPassword(_password);
            _enterPasswordPage.ClickSubmitButton();

            //Open 'My page'
            _feedPage.ClickMyPageButton();

            //Create new post and get postId
            var postOnWall = _wallService.CreatePostOnWall(_text);
            var postId = postOnWall.Response.PostId;

            // Compare author and text
            var id = _myPage.GetAuthorId();
            var text = _myPage.GetAuthorText();
            Assert.AreEqual(id, _userId, "Id should be the same");
            Assert.AreEqual(text, _text, "Text should be the same");

            //Get upload url 
            var uploadUrl = _wallService.GetUploadUrl();
            var url = uploadUrl.Response.UploadUrl;

            //Upload photo 
            var uploadPhoto = _wallService.LoadPhoto(url, _photoName, _photoPath);

            var server = uploadPhoto.Server;
            var hash = uploadPhoto.Hash;
            var photo = uploadPhoto.Photo;

            //Save photo
            var savePhoto = _wallService.SavePhoto(server, photo, hash);

            var ownerId = savePhoto.Response.Select(s => s.OwnerId).First();
            var photoId = savePhoto.Response.Select(s => s.Id).First();

            //Edit wall post
            var updatePost = _wallService.EditWallPost(ownerId, photoId, postId, _text);
            var updatePostId = updatePost.Response.PostId;

            //Check post text
            var postText = _myPage.GetPostText();
            Assert.AreEqual(postText, _text, "Text should be the same");

            //Check is photo post
            Assert.IsTrue(_myPage.IsPhotoPost(photoId), "Photo id should be the same");

            //Create comment on post
            _wallService.CreateWallComment(ownerId, postId, _text);

            //Check reply author id
            var authorId = _myPage.GetReplyAuthorId();
            Assert.AreEqual(authorId, _userId, "Id should be the same");

            //Click 'like'
            _myPage.ClickLikeButton();

            //Check like on post
            var getLikeList = _wallService.CheckLikeOnPost(updatePostId, ownerId);
            var countLike = getLikeList.Response.Liked;

            //Check like id
            Assert.AreEqual(countLike, _expectedLikesCount, "Count should be the same");

            //Delete post
            _wallService.DeletePost(updatePostId, ownerId);

            //Check is post deleted
            Assert.IsTrue(_myPage.CheckIsPostDeleted(), "Post should be deleted");
        }
    }
}