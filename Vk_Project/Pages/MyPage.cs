using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Vk_Project.Constants;

namespace Vk_Project.Pages
{
    public class MyPage : Form
    {
        private ITextBox Author =>
            ElementFactory.GetTextBox(
                By.XPath("//a[contains(@class,'author')]"), "Author");

        private ITextBox AuthorText => ElementFactory.GetTextBox(
            By.XPath(
                "//div[contains(@class,'wall')and contains(@class,'text')]//div[contains(@class,'wall')" +
                "and contains(@class,'post')and contains(@class,'text')and contains(@class,'zoom')]"),
            "Author text");

        private ITextBox GetText => ElementFactory.GetTextBox(
            By.XPath("//div[contains(@class,'wall')and contains(@class,'post')and contains(@class,'text')]"),
            "Get post text");

        private ITextBox PhotoData => ElementFactory.GetTextBox(
            By.XPath(
                "//div[contains(@class,'page')and contains(@class,'post')and contains(@class,'sized')and contains(@class,'thumbs')]"),
            "Photo data");

        private ITextBox ReplyAuthor =>
            ElementFactory.GetTextBox(
                By.XPath("//div[contains(@class,'reply')and contains(@class,'author')]//a[@class='author']"),
                "Reply author");

        private IButton LikeButton => ElementFactory.GetButton(
            By.XPath(
                "//span[contains(@class,'PostBottomAction')and contains(@class,'icon')and contains(@class,'like')and contains(@class,'button')and contains(@class,'icon')]"),
            "Like button");

        private ITextBox DeletePost => ElementFactory.GetTextBox(
            By.XPath("//div[contains(@id,'post_del')]"), "Delete post");

        public MyPage() : base(By.Id("page_body"),
            "My page header")
        {
        }

        public string GetAuthorId()
        {
            return Author.GetAttribute(Attribute.HrefAttribute);
        }

        public string GetAuthorText()
        {
            return AuthorText.Text;
        }

        public string GetPostText()
        {
            return GetText.Text;
        }

        public bool IsPhotoPost(long photoId)
        {
            return PhotoData.GetAttribute(Attribute.HrefAttribute).Contains($"{photoId}");
        }

        public string GetReplyAuthorId()
        {
            return ReplyAuthor.GetAttribute(Attribute.HrefAttribute);
        }

        public void ClickLikeButton()
        {
            LikeButton.Click();
        }

        public bool CheckIsPostDeleted()
        {
            return DeletePost.State.IsDisplayed;
        }
    }
}