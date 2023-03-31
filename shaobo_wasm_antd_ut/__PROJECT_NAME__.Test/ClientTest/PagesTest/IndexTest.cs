using Bunit;
using Xunit;
using __PROJECT_NAME__.Client.Pages;
using AntDesign.Tests;

namespace __PROJECT_NAME__.Test.ClientTest.PagesTest;

public class IndexTest : AntDesignTestBase
{
    [Fact]
    public void Render_default()
    {
        var index = Context.RenderComponent<Index>();

        index.Find("h1").MarkupMatches(@"<h1>__PROJECT_NAME__ : Index</h1>");
    }
}
