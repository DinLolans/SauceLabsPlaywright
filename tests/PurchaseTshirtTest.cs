using Microsoft.Playwright;
using SauceLabsP.Pages;
using SauceLabsP.Context;
using SauceLabsP.Enums;
using NLog;

public class PurchaseTshirtTest : PageTest
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    private string Username => Environment.GetEnvironmentVariable("SAUCE_USERNAME")
    ?? throw new InvalidOperationException("SAUCE_USERNAME environment variable is not set");
    private string Password => Environment.GetEnvironmentVariable("SAUCE_PASSWORD")
    ?? throw new InvalidOperationException("SAUCE_PASSWORD environment variable is not set");

    private Ui _ui;
    private StartTest _startTest;

    [SetUp]
    public void TestInitialize()
    {
        _ui = new Ui(Page);
        _startTest = new StartTest(_ui);
    }

    [Test]
    public async Task PurchaseTShirtTest()
    {
        Logger.Info("Start test on Login Page, fill credentials and press 'Login' button");
        var loginPage = await _startTest.OnLoginPage();
        await loginPage.FillCredentials(Username, Password);
        var productsPage = await loginPage.PressLoginButton();

        Logger.Info("Add Tshirt to cart and go to cart page");
        await productsPage.AddItemToCart(Items.SauceLabsBoltTShirt);
        var cartPage = await productsPage.ClickOnShoppingCartIcon();

        Logger.Info("Press 'Checkout' button, fill shipping info and press 'Continue' button");
        var checkoutYourInformationPage = await cartPage.PressCheckoutButton();
        await checkoutYourInformationPage.FillShippingInfo(PageHelper.GetRandomString(10), PageHelper.GetRandomString(), PageHelper.GetRandomInt());
        var checkoutOverviewPage = await checkoutYourInformationPage.PressContinueButton();

        Logger.Info("Collect order and press 'Finish' button");
        var itemNames = await checkoutOverviewPage.GetItemNames();
        var checkoutCompletePage = await checkoutOverviewPage.PressFinishButton();

        Logger.Info("Check that order is completed");
        Assert.That(itemNames, Is.EqualTo(new List<string> { Items.SauceLabsBoltTShirt }), "Wrong item is added to cart");
        Assert.That(await checkoutCompletePage.GetCompleteHeader(), Is.EqualTo(Labels.ThankYouForYourOrder), "Wrong complete header");
    }
}
