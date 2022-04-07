function show_error(_msg) {
    alert(_msg);
}

function getQueryParams(qs) {
    qs = qs.split('+').join(' ');

    var params = {},
        tokens,
        re = /[?&]?([^=]+)=([^&]*)/g;

    while (tokens = re.exec(qs)) {
        params[decodeURIComponent(tokens[1])] = decodeURIComponent(tokens[2]);
    }

    return params;
}

function insertUrlParam(key, value) {
    if (history.pushState) {
        let searchParams = new URLSearchParams(window.location.search);
        searchParams.set(key, value);
        let newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?' + searchParams.toString();
        window.history.pushState({ path: newurl }, '', newurl);
    }
}


 function removeUrlParameter(paramKey) {
    const url = window.location.href
    console.log("url", url)
    var r = new URL(url)
    r.searchParams.delete(paramKey)
    const newUrl = r.href
    console.log("r.href", newUrl)
    window.history.pushState({ path: newUrl }, '', newUrl)
}

function set_graph_file_param() {
    removeUrlParameter("fs");


    var fs = $("#graphtoload").val();
    insertUrlParam("fs", fs);
}


function set_graph_select_combobox() {

    var query = getQueryParams(document.location.search);
    $("#graphtoload").val(query.fs);


}
var alchemy = new Alchemy();


function init_alchemy() {
    alchemy = new Alchemy();
    alchemy.begin({});
}


function create_alchemy_visualisation(_json_data) {
    $("#alchemy").html();
   // debugger;
    var graph = null;
    try {
        graph = JSON.parse(_json_data);
    } catch {

    }

    console.log(graph);

    if (graph === null) {
        alert("graph loading failed");
        return;
    }
   

    var types = {};

    if (graph.node_types !== null) {
        types = {
            "types": graph.node_types
        }
    }

    var colors = {};
    var cluster_en = false;
 //   debugger;
    if (graph.clusterColours !== null) {
        colors = graph.clusterColours;
        if (colors.length > 1) {
            cluster_en = true;
           
        }
    }
   

    var config = {
        dataSource: graph.data,
        forceLocked: false,
        cluster: cluster_en,
        clusterColours: colors,
        linkDistance: function () { return 0.2; },
        nodeTypes: types,

        caption: function (node) {
            return node.caption;
        },
        initialScale: 0.8,

        graphHeight: function () { return 800; },
        graphWidth: function () { return 1200; },
        captionToggle: false,
        edgesToggle: false,
        nodesToggle: false,
        toggleRootNotes: false,
    
        zoomControls: true
    };

    
    alchemy.setConf(config);
    alchemy.startGraph(graph.data);


    console.log("create_alchemy_visualisation finished");
}