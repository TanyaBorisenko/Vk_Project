using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Vk_Project.Pages
{
    public class FeedPage : Form
    {
        private IButton MyPageButton =>
            ElementFactory.GetButton(
                By.XPath("//li[contains(@id,'l_pr')]"), "My page button");

        public FeedPage() : base(
            By.XPath("//div[contains(@id,'stories_feed_items_container')]"), "Feed page header")
        {
        }

        public void ClickMyPageButton()
        {
            MyPageButton.Click();
        }
    }
}