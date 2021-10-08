using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WinkAutomation.Models;

namespace WinkAutomation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string signinURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/sign-in";
        private const string shopURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products";
        private const string aboutURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/about";
        private const string joinURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/enrollment";
        private const string searchURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/search-products";
        private const string cartURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/cart";
        private const string homePageURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/home";
        private const string ComfortPatchURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Comfort-Patch";
        private const string SleepURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Sleep";
        private const string SkinCareURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Skin-Care";
        private const string TeethingURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Teething";
        private const string HealthNutritionURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Health-&-Nutrition";
        private const string MensCareURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Men's-Care";
        private const string WinkMerchURL = "https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/store/products/Wink-Merch";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Automation()
        {
            IWebDriver driver;
            driver = new ChromeDriver();

            //Sign In functionality
            SignIn(driver);

            //Web Logo functionality
            WebLogo(driver);

            // Blog tab functionality
            BlogTab(driver);

            // About tab functionality
            AboutTab(driver);

            // Join tab functionality
            JoinTab(driver);

            //search icon functionality
            SearchIcon(driver);

            //Cart icon functionality
            CartIcon(driver);

            //All Product functionality
            AllProductBox(driver);

            //Comfort Patch dropdown functionality
            ComfortPatch(driver);

            //Sleep dropdown functionality
            Sleep(driver);

            //Skin Care dropdown functionality
            SkinCare(driver);

            //Teething dropdown functionality
            Teething(driver);

            //Health dropdown Functionality
            HealthNutrition(driver);

            //Mens Care Functionality
            MensCare(driver);

            //Wink Merch Functionality
            WinkMerch(driver);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Sign In functionality
        private void SignIn(IWebDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl(signinURL);
                driver.Manage().Window.Maximize();
                driver.Navigate().Refresh();
                IWebElement Sign = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-header/header/nav/div/div[3]/ul[2]/li[3]/a"));
                Sign.Click();
                Thread.Sleep(2000);
                IWebElement UserName = driver.FindElement(By.Name("username"));
                UserName.SendKeys("Himshikha Shah");
                IWebElement PassWord = driver.FindElement(By.Name("pwd-sign"));
                PassWord.SendKeys("Sss1234!");
                Thread.Sleep(3000);
                IWebElement SignInButton = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-sign-in/section/div/div/div/form/div[2]/button"));
                SignInButton.Click();
                Thread.Sleep(3000);
                string current_home_URL = driver.Url;
                if (string.Equals(homePageURL, current_home_URL))
                    ShopTab(driver);
                else
                    Console.WriteLine("User is not able to Log In in the website.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error occurred during signin process. Here is the error message : {ex.Message}");
            }

        }

        //Shop tab click
        private void ShopTab(IWebDriver driver)
        {
            IWebElement shop = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-header/header/nav/div/div[3]/ul[1]/li[1]/a"));
            shop.Click();
            Thread.Sleep(6000);
            string currentURL = driver.Url;
            if (string.Equals(shopURL, currentURL))
                Console.WriteLine("shop_logo click Successful");
            else
                Console.WriteLine("shop_logo is Not Clickable");
        }

        //Blog tab functionality
        private void BlogTab(IWebDriver driver)
        {
            IWebElement blog = driver.FindElement(By.XPath("/html[1]/body[1]/app-root[1]/app-layout[1]/div[1]/app-header[1]/header[1]/nav[1]/div[1]/div[3]/ul[1]/li[2]/a[1]"));
            blog.Click();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/home");
            Thread.Sleep(3000);
            //driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        //About tab functionality
        private void AboutTab(IWebDriver driver)
        {
            IWebElement about = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-header/header/nav/div/div[3]/ul[1]/li[3]/a"));
            about.Click();
            Thread.Sleep(3000);
            string current_about_URL = driver.Url;
            if (string.Equals(aboutURL, current_about_URL))
                Console.WriteLine("about_logo is click Successful");
            else
                Console.WriteLine("about_logo is Not Clickable");
            driver.Navigate().GoToUrl("https://winknaturalsreplicatedsite-frontend.azurewebsites.net/#/home");
            Thread.Sleep(3000);
        }

        //Join tab functionality
        private void JoinTab(IWebDriver driver)
        {
            IWebElement join = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-header/header/nav/div/div[3]/ul[1]/li[4]/a"));
            join.Click();
            Thread.Sleep(3000);
            string current_join_URL = driver.Url;
            if (string.Equals(joinURL, current_join_URL))
                Console.WriteLine("join logo is click Successful");
            else
                Console.WriteLine("join_logo is Not Clickable");
            Thread.Sleep(5000);

        }

        //Search Icon functionality
        private void SearchIcon(IWebDriver driver)
        {
            IWebElement search = driver.FindElement(By.XPath("/html[1]/body[1]/app-root[1]/app-layout[1]/div[1]/app-header[1]/header[1]/nav[1]/div[1]/div[3]/ul[2]/li[1]/a[1]/i[1]"));
            search.Click();
            Thread.Sleep(6000);
            string current_search_URL = driver.Url;
            if (string.Equals(searchURL, current_search_URL))
                Console.WriteLine("search icon is click Successfully");
            else
                Console.WriteLine("search icon is Not Clickable");
        }

        //Web Logo functionality
        private void WebLogo(IWebDriver driver)
        {
            IWebElement web_logo = driver.FindElement(By.XPath("/html[1]/body[1]/app-root[1]/app-layout[1]/div[1]/app-header[1]/header[1]/nav[1]/div[1]/div[3]/div[1]/a[1]/img[1]"));
            web_logo.Click();
            Console.WriteLine("web_logo click Successful");
        }

        //Cart Icon functionality
        private void CartIcon(IWebDriver driver)
        {
            IWebElement cart = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-header/header/nav/div/div[3]/ul[2]/li[2]/a/i"));
            cart.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string current_cart_URL = driver.Url;
            if (string.Equals(cartURL, current_cart_URL))
                Console.WriteLine("cart icon is click Successful");
            else
                Console.WriteLine("cart icon is Not Clickable");
            driver.Navigate().GoToUrl(shopURL);
        }

        // All Product dropdown Click
        private void AllProductBox(IWebDriver driver)
        {
            IWebElement Productbox = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select"));
            Productbox.Click();
            Thread.Sleep(5);
            Console.WriteLine("Dropdown is open");
        }

        //Comfort patch Functionality
        private void ComfortPatch(IWebDriver driver)
        {
            IWebElement Comfort = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[2]"));
            Comfort.Click();
            Thread.Sleep(3);
            string current_Comfort_URL = driver.Url;
            if (string.Equals(ComfortPatchURL, current_Comfort_URL))
                Console.WriteLine("Comfort Patch dropdown is working");
            else
                Console.WriteLine("Comfort Patch dropdown is not working");
        }

        //Sleep Dropdown functionality
        private void Sleep(IWebDriver driver)
        {
            IWebElement Sleep_Element = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[3]"));
            Sleep_Element.Click();
            Thread.Sleep(3);
            string current_Sleep_URL = driver.Url;
            if (string.Equals(SleepURL, current_Sleep_URL))
                Console.WriteLine("Sleep product dropdown is working");
            else
                Console.WriteLine("Sleep product dropdown is not working");
        }

        //Skin Care Dropdown functionality
        private void SkinCare(IWebDriver driver)
        {
            IWebElement Skin_Care = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[4]"));
            Skin_Care.Click();
            Thread.Sleep(3);
            string current_SkinCare_URL = driver.Url;
            if (string.Equals(SkinCareURL, current_SkinCare_URL))
                Console.WriteLine("Skin care dropdown is working");
            else
                Console.WriteLine("Skin care dropdown is not working");
        }

        //Teething dropdown functioanlity
        private void Teething(IWebDriver driver)
        {
            IWebElement Teething_Element = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[5]"));
            Teething_Element.Click();
            Thread.Sleep(3);
            string current_Teething_URL = driver.Url;
            if (string.Equals(TeethingURL, current_Teething_URL))
                Console.WriteLine("Teething dropdown is working");
            else
                Console.WriteLine("Teething dropdown is not working");
        }

        //Health dropdown Functionality
        private void HealthNutrition(IWebDriver driver)
        {
            IWebElement Health_Element = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[6]"));
            Health_Element.Click();
            Thread.Sleep(3);
            string current_HealthNutrition_URL = driver.Url;
            if (string.Equals(HealthNutritionURL, current_HealthNutrition_URL))
                Console.WriteLine("Health and Nutrition dropdown is working");
            else
                Console.WriteLine("Health and Nutrition dropdown is not working");
        }

        //Mens Care dropdown functionality
        private void MensCare(IWebDriver driver)
        {
            IWebElement MensCare_Element = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[7]"));
            MensCare_Element.Click();
            Thread.Sleep(3);
            string current_MensCare_URL = driver.Url;
            if (string.Equals(MensCareURL, current_MensCare_URL))
                Console.WriteLine("Mens Care dropdown is working");
            else
                Console.WriteLine("Mens Care dropdown is not working");
        }

        //Wink Merch dropdown functionality 
        private void WinkMerch(IWebDriver driver)
        {
            IWebElement WinkMerch_Element = driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/div/app-shop/section[1]/div[2]/form/div[1]/select/option[8]"));
            WinkMerch_Element.Click();
            Thread.Sleep(3);
            string current_WinkMerch_URL = driver.Url;
            if (string.Equals(WinkMerchURL, current_WinkMerch_URL))
                Console.WriteLine("Wink Merch dropdown is working");
            else
                Console.WriteLine("Wink Merch dropdown is not working");
        }
    }
}
