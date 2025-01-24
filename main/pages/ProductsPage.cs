using Microsoft.Playwright;
using SauceLabsP.Enums;
using SauceLabsP.Context;
using SauceLabsP.Pages;

public class ProductsPage
{
    private readonly Ui _ui;

    public ProductsPage(Ui ui)
    {
        _ui = ui;
        Assert.That(_ui.GetText(Locators.Text.Title).GetAwaiter().GetResult(), Is.EqualTo(Labels.Products));
    }

    public async Task<ProductsPage> AddItemToCart(string itemName)
    {
        await _ui.PressButtonInElementByText(itemName, Locators.PageElements.InventoryItem, Locators.Buttons.AddToCartButton);
        return this;
    }

    public async Task<CartPage> ClickOnShoppingCartIcon()
    {
        await _ui.Click(Locators.Icons.ShoppingCartIcon);
        return new CartPage(_ui);
    }
}