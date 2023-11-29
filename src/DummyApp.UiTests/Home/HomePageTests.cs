using System.Text.RegularExpressions;
using DummyApp.UiTests.Utils;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace DummyApp.UiTests.Home;

[TestClass]
public class HomePageTests : PageTest
{
    [TestMethod]
    public async Task HomepageHasHomeInTitleAndLoginLinkInSidebar()
    {
        await Page.GotoAsync(TestEnvironment.Url);

        // Expect a title
        await Expect(Page).ToHaveTitleAsync(new Regex("Home"));

        // create a locator
        var login = Page.GetByRole(AriaRole.Link, new() { Name = "Login" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(login).ToHaveAttributeAsync("href", "Account/Login");

        // Click the get login link.
        await login.ClickAsync();

        // Expects the URL to contain Login.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Login"));
    }
}
