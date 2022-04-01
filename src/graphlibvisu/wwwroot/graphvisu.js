function show_error(_msg) {
    alert(_msg);
}


var alchemy = new Alchemy();
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

    
    alchemy.begin(config)


    console.log("create_alchemy_visualisation finished");
}