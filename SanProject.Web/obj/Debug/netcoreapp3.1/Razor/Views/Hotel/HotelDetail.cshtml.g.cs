#pragma checksum "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03f395eea68645c77a0547748ad3a7c33f88eff3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotel_HotelDetail), @"mvc.1.0.view", @"/Views/Hotel/HotelDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03f395eea68645c77a0547748ad3a7c33f88eff3", @"/Views/Hotel/HotelDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df193f86acab019458b279c309e3ed14a1694caf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Hotel_HotelDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SanProject.Shared.HotelModels.HotelDetailDTO>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Booking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div id=\"full_hotel_detaildiv\">\r\n    <div id=\"hotel_detaildiv\">\r\n    <h1>");
#nullable restore
#line 9 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
   Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <img");
            BeginWriteAttribute("src", " src=", 282, "", 303, 1);
#nullable restore
#line 10 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
WriteAttributeValue("", 287, Model.thumbnail, 287, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></img>\r\n    <div class=\"Scores\">\r\n");
#nullable restore
#line 12 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
          if (Model.stars > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>");
#nullable restore
#line 14 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
              Write(Model.stars);

#line default
#line hidden
#nullable disable
            WriteLiteral(" stars</span>\r\n");
#nullable restore
#line 15 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
         if (Model.rating > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>");
#nullable restore
#line 18 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
              Write(Model.rating);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Rating</span>\r\n");
#nullable restore
#line 19 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"locationinfo\">\r\n       <span class=\"hotel_detail_info_title\">Address : </span><span>");
#nullable restore
#line 22 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                               Write(Model.address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div>\r\n        <span class=\"hotel_detail_info_title\">Offer check-in : </span><span>");
#nullable restore
#line 25 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                                        Write(Model.offerCheckIn.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"hotel_description\">\r\n        <span>");
#nullable restore
#line 28 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
         Write(Model.description.text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"hotel_price\">\r\n        <span>");
#nullable restore
#line 31 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
          Write(Model.price.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><span class=\"currency_span\"> ");
#nullable restore
#line 31 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                                  Write(Model.price.currency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"make_reservation_anchor\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03f395eea68645c77a0547748ad3a7c33f88eff37916", async() => {
                WriteLiteral("Make Reservation");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-offid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                               WriteLiteral(Model.offerId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["offid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-offid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["offid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                                                                WriteLiteral(Model.price.currency);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currenc"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currenc", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currenc"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\ZBOOK 15 G5\Desktop\mvcday\SanProject\SanProject.Web\Views\Hotel\HotelDetail.cshtml"
                                                                                                                                        WriteLiteral(Model.travellernum);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["travnum"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-travnum", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["travnum"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SanProject.Shared.HotelModels.HotelDetailDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
