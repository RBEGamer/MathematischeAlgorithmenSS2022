function show_error(_msg) {
    alert(_msg);
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

function set_graph_file_param(_fs) {
    removeUrlParameter("fs");
    insertUrlParam("fs", _fs);
}

var alchemy = new Alchemy();


function init_alchemy() {
    alchemy = new Alchemy();
    alchemy.begin({});
}


function create_alchemy_visualisation(_json_data) {
    
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
 //   debugger;
    if (graph.clusterColours !== null) {
        colors = graph.clusterColours;
    }

    var config = {
        dataSource: graph.data,
        forceLocked: false,
        cluster: true,
        clusterColours: colors,
        linkDistance: function () { return 0.2; },
        nodeTypes: types,

        caption: function (node) {
            return node.caption;
        },
        initialScale: 0.4,

        graphHeight: function () { return 800; },
        graphWidth: function () { return 800; },
        captionToggle: true,
        edgesToggle: true,
        nodesToggle: true,
        toggleRootNotes: false,
    
        zoomControls: true
    };

    
    alchemy.setConf(config);
    alchemy.startGraph(graph.data);


    console.log("create_alchemy_visualisation finished");
}