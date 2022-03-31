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
    var config = {
        dataSource: graph,
        captionToggle: true,
        edgesToggle: true,
        nodesToggle: true,
        toggleRootNotes: false,
        cluster: true,
        zoomControls: true
    };

    var alchemy = new Alchemy(config)


    console.log("create_alchemy_visualisation finished");
}