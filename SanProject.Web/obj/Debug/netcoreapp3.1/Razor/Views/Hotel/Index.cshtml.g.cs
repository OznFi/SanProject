#pragma checksum "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de29c8523f4ccd468e8ceffc092587fcb936d80b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotel_Index), @"mvc.1.0.view", @"/Views/Hotel/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\_ViewImports.cshtml"
using SanProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\_ViewImports.cshtml"
using SanProject.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
using SanProject.Shared.HotelModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de29c8523f4ccd468e8ceffc092587fcb936d80b", @"/Views/Hotel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df193f86acab019458b279c309e3ed14a1694caf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Hotel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<HotelDetailDTO>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AlternateHotelDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("<h1>Hotels</h1>\r\n\r\n\r\n\r\n<div id=\"hotels_container\">\r\n");
#nullable restore
#line 13 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"hotel_list_element\">\r\n");
#nullable restore
#line 16 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
         if (@item.thumbnail!=null)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"imgdiv\">\r\n                    <img");
            BeginWriteAttribute("src", " src=", 455, "", 475, 1);
#nullable restore
#line 20 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
WriteAttributeValue("", 460, item.thumbnail, 460, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></img>\r\n                </div>\r\n");
#nullable restore
#line 22 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n        <h2>");
#nullable restore
#line 25 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
       Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <h3>");
#nullable restore
#line 26 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
           Write(item.HotelId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <div class=\"Scores\">\r\n");
#nullable restore
#line 28 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
              if (item.stars > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("             <span>");
#nullable restore
#line 30 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
               Write(item.stars);

#line default
#line hidden
#nullable disable
            WriteLiteral(" stars</span>\r\n");
#nullable restore
#line 31 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
             if (item.rating > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 34 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
                  Write(item.rating);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Rating</span>\r\n");
#nullable restore
#line 35 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("          </div>\r\n          <div class=\"locationinfo\">\r\n            <span class=\"hotel_detail_info_title\">Address : </span><span>");
#nullable restore
#line 38 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
                                                                    Write(item.address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n          </div>\r\n       </div>\r\n          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de29c8523f4ccd468e8ceffc092587fcb936d80b7458", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-hotelId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
                                                      WriteLiteral(item.HotelId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["hotelId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-hotelId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["hotelId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
                                                                                        WriteLiteral(item.travellernum);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numtrav"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numtrav", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numtrav"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute(",", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
                                                                                                                                   WriteLiteral(item.offerCheckIn.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["checkinstr"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-checkinstr", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["checkinstr"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n       </div>\r\n");
#nullable restore
#line 43 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<HotelDetailDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
