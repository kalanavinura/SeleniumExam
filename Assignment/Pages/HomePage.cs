using Assignment.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class HomePage : DriverHelper
    {
        #region Web Elements

        private By heading_label = By.CssSelector("div[class='app_logo']");

        #endregion

        #region Web Actions

        // This will return text of header element
        public string getHeadingText() => getText(heading_label);

        #endregion
    }
}
