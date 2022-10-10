using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Vk_Project.Pages
{
    public class MainPage : Form
    {
        private ITextBox UserNameTextBox =>
            ElementFactory.GetTextBox(By.XPath("//input[contains(@id,'index')and contains(@id,'email')]"),
                "Email text box");

        private IButton LogInButton => ElementFactory.GetButton(
            By.XPath(
                "//button[contains(@class,'signInButton')]"), "Login button");

        public MainPage() : base(By.XPath("//div[@class='VkIdForm']"), "Login page header")
        {
        }

        public void EnterUserName(string userName)
        {
            UserNameTextBox.ClearAndType(userName);
        }

        public void ClickLogInButton()
        {
            LogInButton.Click();
        }
    }
}