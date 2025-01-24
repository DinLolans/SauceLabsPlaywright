using Microsoft.Playwright;
using SauceLabsP.Enums;
using SauceLabsP.Context;
using SauceLabsP.Pages;

public class LoginPage
{
    private readonly Ui _ui;

    public LoginPage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.LoginLogo).GetAwaiter().GetResult(), Is.EqualTo(Labels.SwagLabs));
    }

    public async Task<LoginPage> FillCredentials(string username, string password)
    {
        await _ui.FillInputField(Locators.InputFields.UsernameInput, username);
        await _ui.FillInputField(Locators.InputFields.PasswordInput, password);
        return this;
    }

    public async Task<ProductsPage> PressLoginButton()
    {
        await _ui.Click(Locators.Buttons.LoginButton);
        return new ProductsPage(_ui);
    }
}