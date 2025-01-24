using Microsoft.Playwright;
using SauceLabsP.Context;
using SauceLabsP.Enums;
using SauceLabsP.Pages;

public class CheckoutCompletePage
{
    private readonly Ui _ui;

    public CheckoutCompletePage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.Title).GetAwaiter().GetResult(), Is.EqualTo(Labels.CheckoutComplete));
    }

    public async Task<string> GetCompleteHeader() => await _ui.GetText(Locators.Text.CompleteHeader);

}