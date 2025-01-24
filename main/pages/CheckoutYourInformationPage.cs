using Microsoft.Playwright;
using SauceLabsP.Context;
using SauceLabsP.Enums;
using SauceLabsP.Pages;

public class CheckoutYourInformationPage
{
    private readonly Ui _ui;

    public CheckoutYourInformationPage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.Title).GetAwaiter().GetResult(), Is.EqualTo(Labels.CheckoutYourInformation));
    }

    public async Task<CheckoutYourInformationPage> FillShippingInfo(string firstName, string lastName, string postalCode)
    {
        await _ui.FillInputField(Locators.InputFields.FirstNameInput, firstName);
        await _ui.FillInputField(Locators.InputFields.LastNameInput, lastName);
        await _ui.FillInputField(Locators.InputFields.PostalCodeInput, postalCode);
        return this;
    }

    public async Task<CheckoutOverviewPage> PressContinueButton()
    {
        await _ui.Click(Locators.Buttons.ContinueButton);
        return new CheckoutOverviewPage(_ui);
    }
}