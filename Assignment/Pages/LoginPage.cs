using Assignment.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class LoginPage : DriverHelper
    {
        #region Web Elements

        private By userName_txt = By.Id("user-name");
        private By password_txt = By.Id("password");
        private By login_btn= By.Id("login-button");
        private By error_label = By.CssSelector("h3[data-test='error']");

        #endregion

        #region Web Actions

        // This will populate value into user name textbox
        public void fillUserName(string userName) => type(userName_txt, userName);

        // This will populate value into password textbox
        public void fillPassword(string password) => type(password_txt, password);

        // This will perform click action on login button
        public void login() => click(login_btn);

        // This will return error label text
        public string getErrorLabelText() => getText(error_label);

        #endregion
    }
}
