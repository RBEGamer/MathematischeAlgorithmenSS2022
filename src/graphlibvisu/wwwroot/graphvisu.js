function show_error(_msg) {
    alert(_msg);
}

function create_alchemy_visualisation(_json_data) {
    console.log(_json_data)

    var graph = null;
    try {
        graph = JSON.parse(_json_data);
    } catch {

    }

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
    var config = {
        dataSource: graph.data,
        forceLocked: false,
        linkDistance: function () { return 1; },
        nodeTypes: types,
        caption: function (node) {
            return node.caption;
        },
        initialScale: 0.1,
       // captionToggle: true,
      //  edgesToggle: true,
     //   nodesToggle: true,
     //   toggleRootNotes: false,
     //  cluster: true,
        zoomControls: true
    };

    var alchemy = new Alchemy(config)


    console.log("create_alchemy_visualisation finished");
}