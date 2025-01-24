namespace SauceLabsP.Enums;

public static class Locators
{
    public static class Buttons
    {
        public const string LoginButton = "#login-button";
        public const string AddToCartButton = "xpath=.//button[contains(@class,'btn_inventory')]";
        public const string CheckoutButton = "#checkout";
        public const string ContinueButton = "#continue";
        public const string FinishButton = "#finish";
    }

    public static class InputFields
    {
        public const string UsernameInput = "#user-name";
        public const string PasswordInput = "#password";
        public const string FirstNameInput = "#first-name";
        public const string LastNameInput = "#last-name";
        public const string PostalCodeInput = "#postal-code";
    }

    public static class Text
    {
        public const string CompleteHeader = ".complete-header";
        public const string Title = ".title";
        public const string LoginLogo = ".login_logo";
        public const string InventoryItemName = "xpath=.//div[@class='inventory_item_name']";
    }

    public static class Icons
    {
        public const string ShoppingCartIcon = ".shopping_cart_link";
    }

    public static class PageElements
    {
        public const string InventoryItem = ".inventory_item";
    }
}