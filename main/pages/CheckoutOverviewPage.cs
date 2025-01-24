using Microsoft.Playwright;
using SauceLabsP.Context;
using SauceLabsP.Enums;
using SauceLabsP.Pages;

public class CheckoutOverviewPage
{
    private readonly Ui _ui;

    public CheckoutOverviewPage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.Title).GetAwaiter().GetResult(), Is.EqualTo(Labels.CheckoutOverview));
    }


    public async Task<CheckoutCompletePage> PressFinishButton()
    {
        await _ui.Click(Locators.Buttons.FinishButton);
        return new CheckoutCompletePage(_ui);
    }

    public async Task<List<string>> GetItemNames() => await _ui.GetTexts(Locators.Text.InventoryItemName);
}