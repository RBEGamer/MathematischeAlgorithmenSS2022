// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
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
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "/Users/marcelochsendorf/Downloads/MathematischeAlgorithmenSS2022/src/graphlibvisu/Pages/Index.razor"
       
    private GraphLoadingItem[] graphs;

    protected override async Task OnInitializedAsync()
    {
        graphs = await FileSystemLoader.GetGraphLoadingItem();


    }


    protected void greset()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.RESET);
        //JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
        JS.InvokeVoidAsync("reload_page");
        
    }

    protected void tiefensuche()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.TIEFENSUCHE);
        //JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
        JS.InvokeVoidAsync("reload_page");
    } 
    protected void breitensuche()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.BREITENSUCHE);
        //JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
        JS.InvokeVoidAsync("reload_page");
    }

    protected void cluster()
    {
        FileSystemLoader.ApplyEffectOnGraph(FileSystemLoader.ALOGORITHM.CLUSTER);
        //JS.InvokeVoidAsync("create_alchemy_visualisation", FileSystemLoader.CurrentGraphToJSONSTring());
        JS.InvokeVoidAsync("reload_page");
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
        await JS.InvokeVoidAsync("set_graph_select_combobox");


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