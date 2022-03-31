#pragma checksum "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18a3635e6189ecd4e162eb2c19021ac9904be45c"
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
#line 1 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using graphlibvisu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/_Imports.razor"
using graphlibvisu.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
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
            __builder.AddMarkupContent(0, "<h1>GRAPHLIB - INTERACTIVE VISUALISATION</h1>\n\n\n<div class=\"alchemy\" id=\"alchemy\"></div>\n\n\n\n\n");
            __builder.AddMarkupContent(1, "<h1>Load example graphs</h1>\n\n");
            __builder.AddMarkupContent(2, "<p>Please select a graph to load from the list below</p>\n\n");
#nullable restore
#line 20 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
 if (graphs == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "    ");
            __builder.AddMarkupContent(4, "<p><em>Loading...</em></p>\n");
#nullable restore
#line 23 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, "    ");
            __builder.OpenElement(6, "table");
            __builder.AddAttribute(7, "class", "table");
            __builder.AddMarkupContent(8, "\n        ");
            __builder.AddMarkupContent(9, "<thead>\n            <tr>\n\n                <th>TITLE</th>\n                <th>TYPE</th>\n                <th>OPEN</th>\n            </tr>\n        </thead>\n        ");
            __builder.OpenElement(10, "tbody");
            __builder.AddMarkupContent(11, "\n\n");
#nullable restore
#line 37 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
             foreach (var g in graphs)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "                ");
            __builder.OpenElement(13, "tr");
            __builder.AddMarkupContent(14, "\n                    ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 40 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
                         g.filename

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\n\n                    ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 42 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
                         g.type

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n                    ");
            __builder.OpenElement(21, "td");
            __builder.AddMarkupContent(22, "\n                        ");
            __builder.OpenElement(23, "a");
            __builder.AddAttribute(24, "class", "btn btn-primary");
            __builder.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
                                                             load_graph

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "role", "button");
            __builder.AddContent(27, "OPEN");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\n");
#nullable restore
#line 47 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(31, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\n");
#nullable restore
#line 50 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(34, "\n\n\n\n\n}\n\n\n\n\n\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
       
    private GraphLoadingItem[] graphs;

    protected override async Task OnInitializedAsync()
    {
        graphs = await fs_loader.GetGraphLoadingItem();


    }

    private async Task load_graph()
    {

        string json_graph = "{\"nodes\": [{\"caption\": \"A\",\"type\": \"award\", \"id\": 1},{\"caption\": \"B\",\"type\": \"award\", \"id\": 2}],\"edges\":[{\"source\":1, \"target\":2, \"caption\":\"1 - 2\"}]}";
        await JS.InvokeAsync<string>("create_alchemy_visualisation", json_graph);
    }

    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FileSystemLoader fs_loader { get; set; }
    }
}
#pragma warning restore 1591
