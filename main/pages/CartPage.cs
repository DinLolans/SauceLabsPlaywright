using SauceLabsP.Context;
using SauceLabsP.Enums;
using NUnit.Framework;

namespace SauceLabsP.Pages;

public class CartPage
{
    private readonly Ui _ui;

    public CartPage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.Title).GetAwaiter().GetResult(), Is.EqualTo(Labels.YourCart));
    }

    public async Task<CheckoutYourInformationPage> PressCheckoutButton()
    {
        await _ui.Click(Locators.Buttons.CheckoutButton);
        return new CheckoutYourInformationPage(_ui);
    }
}