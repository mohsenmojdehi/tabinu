#pragma checksum "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\Advertisement\Paln.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b573e4d7730c73a4ecba3e9adfcec720d7881880"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Advertisement_Paln), @"mvc.1.0.view", @"/Views/Advertisement/Paln.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Advertisement/Paln.cshtml", typeof(AspNetCore.Views_Advertisement_Paln))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\_ViewImports.cshtml"
using AddBuzz;

#line default
#line hidden
#line 2 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\_ViewImports.cshtml"
using AddBuzz.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b573e4d7730c73a4ecba3e9adfcec720d7881880", @"/Views/Advertisement/Paln.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"607e7de115ed77627aa11a8f79713d7d700a2b80", @"/Views/_ViewImports.cshtml")]
    public class Views_Advertisement_Paln : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddBuzz.Models.Advertisement.AdvertisementViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\Advertisement\Paln.cshtml"
  
    ViewData["Title"] = "Paln";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(149, 239, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"card\" style=\"width:400px\">\r\n        <img class=\"card-img-top\" src=\"img_avatar1.png\" alt=\"Card image\" style=\"width:100%\">\r\n        <div class=\"card-body\">\r\n            <h4 class=\"card-title\">");
            EndContext();
            BeginContext(389, 11, false);
#line 12 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\Advertisement\Paln.cshtml"
                              Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(400, 40, true);
            WriteLiteral("</h4>\r\n            <p class=\"card-text\">");
            EndContext();
            BeginContext(441, 17, false);
#line 13 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\Advertisement\Paln.cshtml"
                            Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(458, 127, true);
            WriteLiteral("</p>\r\n            <a href=\"\" class=\"btn btn-primary\">سفارش این تبلیغات</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(586, 68, false);
#line 21 "D:\projects\Tabinu_BitbucketRepository\tabinu\AddBuzz\Views\Advertisement\Paln.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(654, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(662, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b573e4d7730c73a4ecba3e9adfcec720d78818805423", async() => {
                BeginContext(684, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(700, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddBuzz.Models.Advertisement.AdvertisementViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
