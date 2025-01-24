using SauceLabsP.Context;
using SauceLabsP.Pages;

namespace SauceLabsP.Pages;

public class StartTest
{
    private readonly Ui _ui;

    public StartTest(Ui ui)
    {
        _ui = ui;
    }

    public async Task<LoginPage> OnLoginPage()
    {
        await _ui.OpenPage("https://www.saucedemo.com/");
        return new LoginPage(_ui);
    }
}