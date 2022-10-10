using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Vk_Project.Pages
{
    public class EnterPasswordPage : Form
    {
        private ITextBox PasswordTextBox =>
            ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), "Password text box");

        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Submit button");

        public EnterPasswordPage() : base(
            By.XPath(
                "//div[contains(@class,'EnterPasswordNoUserInfo')]"), "Password page header")
        {
        }

        public void EnterPassword(string password)
        {
            PasswordTextBox.ClearAndType(password);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
    }
}