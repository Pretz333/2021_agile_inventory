#pragma checksum "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Export.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f479351621187bc92f81cc66e16214f5bd13f192"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Inventory.Pages.Pages_Export), @"mvc.1.0.razor-page", @"/Pages/Export.cshtml")]
namespace Inventory.Pages
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
#line 1 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\_ViewImports.cshtml"
using Inventory;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f479351621187bc92f81cc66e16214f5bd13f192", @"/Pages/Export.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc4c5ed31820425d5cf502ec8126d736b9edb9e9", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Export : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Export.cshtml"
  
    ViewData["Title"] = "Export";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1>Export</h1>\r\n    <p>Export (and Import?) Data controls will go here</p>\r\n</div>\r\n\r\n<script>\r\n    document.querySelector(\"#Export\").classList.add(\"selected\");\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inventory.Pages.ExportModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Inventory.Pages.ExportModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Inventory.Pages.ExportModel>)PageContext?.ViewData;
        public Inventory.Pages.ExportModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
