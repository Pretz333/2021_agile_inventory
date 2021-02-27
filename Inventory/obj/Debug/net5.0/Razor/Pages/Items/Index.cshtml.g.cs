#pragma checksum "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dba3c9c89f88a38ce47d3a509a0d18e26262efc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Inventory.Pages.Items.Pages_Items_Index), @"mvc.1.0.razor-page", @"/Pages/Items/Index.cshtml")]
namespace Inventory.Pages.Items
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dba3c9c89f88a38ce47d3a509a0d18e26262efc2", @"/Pages/Items/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc4c5ed31820425d5cf502ec8126d736b9edb9e9", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Items_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
  
    ViewData["Title"] = "Items";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Items</h1>\r\n\r\n<section id=\"tools\">\r\n    <h2>Tools</h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dba3c9c89f88a38ce47d3a509a0d18e26262efc23473", async() => {
                WriteLiteral("\r\n        <div id=\"toolModule\">\r\n            <div id=\"toolIcon\">\r\n                <img src=\"res/ic_add.png\">\r\n            </div>\r\n            <div id=\"toolText\">\r\n                Create a new item\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <div id=""toolModule"" onClick=""toolClick('Delete')"">
        <div id=""toolIcon"">
            <img src=""res/ic_remove.png"">
        </div>
        <div id=""toolText"">
            Delete an existing item
        </div>
    </div>

    <div id=""toolModule"" onClick=""toolClick('Edit')"">
        <div id=""toolIcon"">
            <img src=""res/ic_edit.png"">
        </div>
        <div id=""toolText"">
            Edit an existing item
        </div>
    </div>
</section>

<section id=""listview"">
    <table>
        <thead>
            <tr>
                <th>
                    ");
#nullable restore
#line 47 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Item[0].CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 50 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Item[0].Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 55 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
             foreach (var item in Model.Item)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 1365, "\"", 1386, 2);
            WriteAttributeValue("", 1370, "row-", 1370, 4, true);
#nullable restore
#line 57 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
WriteAttributeValue("", 1374, item.ItemID, 1374, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1387, "\"", 1420, 3);
            WriteAttributeValue("", 1397, "itemClick(", 1397, 10, true);
#nullable restore
#line 57 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
WriteAttributeValue("", 1407, item.ItemID, 1407, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1419, ")", 1419, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 65 "D:\sch\agile\2021_agile_inventory\Inventory\Pages\Items\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</section>

<script type=""text/javascript"">

    var lastClickedID = 0;

    function itemClick(itemID) {
        if (lastClickedID > 0) {
            document.querySelector(""#row-"" + lastClickedID).classList.remove(""selected"");
        }
        document.querySelector(""#row-"" + itemID).classList.add(""selected"");
        lastClickedID = itemID;
    }

    function toolClick(toolName) {
        if (lastClickedID < 1) {
            alert(""You must select an row from the table"");
        } else {
            window.location = ""/Items/"" + toolName + ""?id="" + lastClickedID;
        }
    }

    document.querySelector(""#Items"").classList.add(""selected"");

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inventory.Pages.Items.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Inventory.Pages.Items.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Inventory.Pages.Items.IndexModel>)PageContext?.ViewData;
        public Inventory.Pages.Items.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591