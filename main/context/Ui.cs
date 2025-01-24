using System.Threading.Tasks;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using System;
using System.ComponentModel;

namespace SauceLabsP.Context;

public class Ui
{
    private readonly IPage _page;

    public Ui(IPage page)
    {
        _page = page;
    }

    public IPage Page => _page;

    public async Task OpenPage(string url) => await _page.GotoAsync(url);
    

    public ILocator GetLocator(string locator) => _page.Locator(locator);

    public async Task FillInputField(string locator, string text) => await GetLocator(locator).FillAsync(text);

    public async Task Click(string locator) => await GetLocator(locator).ClickAsync();

    public async Task<string> GetText(string locator) => await GetLocator(locator).TextContentAsync() ?? string.Empty;


    public async Task<List<string>> GetTexts(string locator) =>
        (await GetLocator(locator).AllTextContentsAsync()).ToList();

    public async Task PressButtonInElementByText(string text, string elementLocator, string buttonLocator)
    {
        await _page.Locator(elementLocator)
            .Filter(new() { HasText = text })
            .Locator(buttonLocator)
            .ClickAsync();
    }
}