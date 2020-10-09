using SUS.MVC.Framework.ViewEngine;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SUS.MvcFramework.Tests
{
    public partial class SusViewEngineTests
    {
        [Theory]
        //happy path
        //interesting cases
        //complicated tests
        //code coverage 100%

        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                Price = 12345.67M,
                Name = "Doggo Arghentino",
                DateOfBirth = new DateTime(1997, 3, 17),
            };
            IViewEngine viewEngine = new SusViewEngine();
            var view = File.ReadAllText($"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel);
            var expectedResult = File.ReadAllText($"ViewTests/{fileName}.Result.html");
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestTemplateViewModel()
        {
            IViewEngine viewEngine = new SusViewEngine();
            var actualResult = viewEngine.GetHtml(@"@foreach(var num in Model)
{
<span>@num</span>
}", new List<int> { 1, 2, 3 });
            var expectedResult = @"<span>1</span>
<span>2</span>
<span>3</span>
";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
