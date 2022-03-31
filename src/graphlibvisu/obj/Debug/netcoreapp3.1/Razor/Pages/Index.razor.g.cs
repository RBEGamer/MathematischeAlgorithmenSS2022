#pragma checksum "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e833528448c192f148df2fd6259e9be6dddf2edf"
// <auto-generated/>
#pragma warning disable 1591
namespace graphlibvisu.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using graphlibvisu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\_Imports.razor"
using graphlibvisu.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
using graphlibvisu.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>GRAPHLIB - INTERACTIVE VISUALISATION</h1>\r\n\r\n\r\n\r\n<div class=\"alchemy\" id=\"alchemy\"></div>\r\n\r\n\r\n\r\n\r\n");
            __builder.AddMarkupContent(1, "<h1>Load example graphs</h1>\r\n\r\n");
            __builder.AddMarkupContent(2, "<p>Please select a graph to load from the list below</p>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
 if (graphs == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "    ");
            __builder.AddMarkupContent(4, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 25 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, "    ");
            __builder.OpenElement(6, "table");
            __builder.AddAttribute(7, "class", "table");
            __builder.AddMarkupContent(8, "\r\n        ");
            __builder.AddMarkupContent(9, "<thead>\r\n            <tr>\r\n\r\n                <th>TITLE</th>\r\n                <th>TYPE</th>\r\n                <th>OPEN</th>\r\n            </tr>\r\n        </thead>\r\n        ");
            __builder.OpenElement(10, "tbody");
            __builder.AddMarkupContent(11, "\r\n\r\n");
#nullable restore
#line 39 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
             foreach (var g in graphs)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "                ");
            __builder.OpenElement(13, "tr");
            __builder.AddMarkupContent(14, "\r\n                    ");
            __builder.OpenElement(15, "td");
#nullable restore
#line 42 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
__builder.AddContent(16, g.filename);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n                    ");
            __builder.OpenElement(18, "td");
#nullable restore
#line 44 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
__builder.AddContent(19, g.type);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                    ");
            __builder.OpenElement(21, "td");
            __builder.AddMarkupContent(22, "\r\n                        ");
            __builder.OpenElement(23, "a");
            __builder.AddAttribute(24, "class", "btn btn-primary");
            __builder.AddAttribute(25, "href", "/?fs=" + (
#nullable restore
#line 46 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                                                               g.filename

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "role", "button");
            __builder.AddContent(27, "OPEN");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 49 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(31, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n");
#nullable restore
#line 52 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
       
    private GraphLoadingItem[] graphs;

    protected override async Task OnInitializedAsync()
    {
        graphs = await FileSystemLoader.GetGraphLoadingItem();

      
    }
    
     //private async Task load_graph()
     protected override async Task OnAfterRenderAsync(bool firstRender)
    {

         string? _fs = null;
         var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
         if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("fs", out var _initialCount))
        {
            _fs = _initialCount;
        }


       
        if (_fs == null)
        {
            _fs = "Graph1.txt";
        }
        GraphLoadingItem[] fss = await FileSystemLoader.GetGraphLoadingItem();
        bool is_in = false;
        foreach (GraphLoadingItem it in fss)
        {
            if (it.filename == _fs)
            {
                is_in = true;
                break;
            }
        }

        if (!is_in)
        {
            await JS.InvokeVoidAsync("show_error", "invalid load file:" + _fs);
            return;
        }


        //FINALLY LOAD FILE

        string json_graph = FileSystemLoader.LoadGraphToJSONString(_fs);
        await JS.InvokeVoidAsync("create_alchemy_visualisation", json_graph);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FileSystemLoader fs_loader { get; set; }
    }
}
#pragma warning restore 1591
