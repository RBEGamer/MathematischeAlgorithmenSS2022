#pragma checksum "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17daebd6c7f8258644ee3de9da34634a0dcecc00"
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
            __builder.AddMarkupContent(0, "<h1>GRAPHLIB - INTERACTIVE VISUALISATION</h1>\r\n\r\n\r\n\r\n<div class=\"alchemy\" id=\"alchemy\"></div>\r\n\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "tr");
            __builder.AddMarkupContent(4, "\r\n        ");
            __builder.OpenElement(5, "th");
            __builder.OpenElement(6, "a");
            __builder.AddAttribute(7, "class", "btn btn-primary");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                                                 greset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "role", "button");
            __builder.AddContent(10, "RESET");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.OpenElement(12, "th");
            __builder.OpenElement(13, "a");
            __builder.AddAttribute(14, "class", "btn btn-primary");
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                                                 breitensuche

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "role", "button");
            __builder.AddContent(17, "BREITENSUCHE");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.OpenElement(19, "th");
            __builder.OpenElement(20, "a");
            __builder.AddAttribute(21, "class", "btn btn-primary");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                                                 cluster

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "role", "button");
            __builder.AddContent(24, "CLUSTER");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n\r\n");
            __builder.AddMarkupContent(28, "<h1>Load example graphs</h1>\r\n\r\n");
            __builder.AddMarkupContent(29, "<p>Please select a graph to load from the list below</p>\r\n\r\n");
#nullable restore
#line 28 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
 if (graphs == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(30, "    ");
            __builder.AddMarkupContent(31, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 31 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "    ");
            __builder.OpenElement(33, "table");
            __builder.AddAttribute(34, "class", "table");
            __builder.AddMarkupContent(35, "\r\n        ");
            __builder.OpenElement(36, "tbody");
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "tr");
            __builder.AddMarkupContent(39, "\r\n");
#nullable restore
#line 37 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                 foreach (var g in graphs)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(40, "                    ");
            __builder.OpenElement(41, "td");
            __builder.AddMarkupContent(42, "\r\n                        ");
            __builder.OpenElement(43, "a");
            __builder.AddAttribute(44, "class", "btn btn-primary");
            __builder.AddAttribute(45, "onclick", "set_graph_file_param(\'" + (
#nullable restore
#line 40 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                                                                                   g.filename

#line default
#line hidden
#nullable disable
            ) + "\');" + " window.location.reload()");
            __builder.AddAttribute(46, "role", "button");
#nullable restore
#line 40 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
__builder.AddContent(47, g.filename);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n");
#nullable restore
#line 42 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(50, "            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n");
#nullable restore
#line 46 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "C:\Users\prodevmo\Desktop\MathematischeAlgorithmenSS2022\src\graphlibvisu\Pages\Index.razor"
       
    private GraphLoadingItem[] graphs;

    protected override async Task OnInitializedAsync()
    {
        graphs = await FileSystemLoader.GetGraphLoadingItem();


    }


    protected void greset()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.RESET);
        JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
    }

    protected void breitensuche()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.BREITENSUCHE);
        JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
    }

    protected void cluster()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.CLUSTER);
        JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
    }



    protected void load_graph(string _fs)
    {
        FileSystemLoader.LoadGraphToJSONString(_fs);
        string json_graph = FileSystemLoader.CurrentGraphToJSONSTring();
        JS.InvokeVoidAsync("create_alchemy_visualisation", json_graph);
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JS.InvokeVoidAsync("init_alchemy");

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

        load_graph(_fs);


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
