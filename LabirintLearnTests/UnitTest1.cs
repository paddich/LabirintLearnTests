using NUnit.Framework;
using OpenQA.Selenium;

namespace LabirintLearnTests

{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _mainSearchField = By.XPath("//input[@id=\"search-field\"]");
        private readonly By _mainSearchButton = By.XPath("//button[@form=\"searchform\"]");
        private readonly By _mainSearchResult = By.XPath("//h1[@class=\"index-top-title\"]");

        private readonly By _findedBookIntoBrasketButton = By.XPath("//a[@data-idtov=\"842998\"]");
        private readonly By _brasketButton = By.XPath("//span[text()=\"Корзина\"]");

        private readonly By _skipDialog = By.XPath("//span[@class=\"fright btn btn-primary btn-middle\"]");
        private readonly By _brasketClean = By.XPath("//a[text()=\"Очистить корзину\"]");

        private readonly By _brasketRestore = By.XPath("//a[@class=\"b-link-popup g-alttext-deepblue\"]");

        private const string _searchRequest = "Чак Паланик";
        private const string _expextedSearchResult = "Все, что мы нашли в Лабиринте по запросу «" + _searchRequest + "»";

        private readonly By _footerVkLink = By.XPath("//a[@data-event-content=\"ВКонтакте\"]");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void MainSearchTest()
        {
            var searchFieldInput = driver.FindElement(_mainSearchField);
            searchFieldInput.SendKeys(_searchRequest);

            Thread.Sleep(700);

            var searchStart = driver.FindElement(_mainSearchButton);
            searchStart.Click();

            Thread.Sleep(700);

            string actualSearchResult = driver.FindElement(_mainSearchResult).Text;

            Assert.AreEqual(_expextedSearchResult, actualSearchResult);
        }

        [Test]
        public void BrasketTest()
        {
            var searchFieldInput = driver.FindElement(_mainSearchField);
            searchFieldInput.SendKeys(_searchRequest);

            Thread.Sleep(700);

            var searchStart = driver.FindElement(_mainSearchButton);
            searchStart.Click();

            // Конец теста поиска

            Thread.Sleep(700);

            var brasketBookInput = driver.FindElement(_findedBookIntoBrasketButton);
            brasketBookInput.Click();

            Thread.Sleep(700);

            var brasketButton = driver.FindElement(_brasketButton);
            brasketButton.Click();

            // Конец теста добавления в корзину

            Thread.Sleep(700);

            var skipDl = driver.FindElement(_skipDialog);
            skipDl.Click();

            Thread.Sleep(700);

            var brasketClean = driver.FindElement(_brasketClean);
            brasketClean.Click();

            // Конец теста очиски корзины

            Thread.Sleep(700);

            var brasketRestore = driver.FindElement(_brasketRestore);
            brasketRestore.Click();

            // Конец теста восстановления корзины
            Assert.Pass();
        }

        [Test]
        public void FooterTest()
        {   
            var footerVK = driver.FindElement(_footerVkLink);
            footerVK.Click();

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}