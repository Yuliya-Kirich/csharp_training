using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace WebAddressbookTests
{
    public class ApplicationManager 
    {

                        
        protected IWebDriver driver;        
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigatorHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected HelperBase helper;
        //private static ApplicationManager instance; //единственный экземпляр ApplicationManager
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>(); //установление соответствия

        //сделаем приватный конструктор, чтобы за его пределами класса ApplicationManager, никто не мог сконструировать другие объекты
        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            //  baseURL = "http://localhost/";
            baseURL = "http://localhost:81/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigatorHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            helper = new HelperBase(this);
        }

        //диструктор
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        // GetInstance анализирует и проверяет, что для текущего потока есть ApplicationManager. И при его отсутствии создавать ноый объект.
        public static ApplicationManager GetInstance()  
        {

            /*
            if (instance == null)
            {
                instance = new ApplicationManager();
            }
            // метод должен вернуть какой-то экземпляр класса ApplicationManager
            return instance;
            */

            if (!app.IsValueCreated)
            {
                //app.Value = new ApplicationManager();
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
              
                // app.Navigator.GoToHomePage();
                //  app.Auth.Login(new AccountData("admin", "secret"));
            }
            // метод должен вернуть какой-то экземпляр класса ApplicationManager
            return app.Value;

        }



        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        /*перенесено в метод ~ApplicationManager()
         * 
         * public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }
*/

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigatorHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }

        public HelperBase Helper
        {
            get
            {
                return helper;
            }
        }
    }
}
