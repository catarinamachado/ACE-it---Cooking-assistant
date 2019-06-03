$( document ).ready(function() {
    var map;
    setTimeout(function () {
        map = new Microsoft.Maps.Map('#map', {});
        GetMap();
    }, 1000);

    function GetMap() {
        //Load the Bing Spatial Data Services module.
        Microsoft.Maps.loadModule('Microsoft.Maps.SpatialDataService', function () {
            //Add an event handler for when the map moves.
            Microsoft.Maps.Events.addHandler(map, 'viewchangeend', getNearByLocations);

            getNearByLocations();
        });
    }

    function getNearByLocations() {
        var sdsDataSourceUrl = 'https://spatial.virtualearth.net/REST/v1/data/c2ae584bbccc4916a0acf75d1e6947b4/NavteqEU/NavteqPOIs';
        map.entities.clear();

        //Create a query to get nearby data.
        var queryOptions = {
            queryUrl: sdsDataSourceUrl,
            spatialFilter: {
                spatialFilterType: 'nearby',
                location: map.getCenter(),
                radius: 25
            },
            //Filter to retrieve Gas Stations.
            filter: new Microsoft.Maps.SpatialDataService.Filter('EntityTypeID', 'Eq', 5400, 'Or', 'EntityTypeID', 'Eq', 6512, 'Or', 'EntityTypeID', 'Eq', 9535)
        };

        //Process the query.
        Microsoft.Maps.SpatialDataService.QueryAPIManager.search(queryOptions, map, function (data) {
            data.forEach(function (entry) {
                var loc = new Microsoft.Maps.Location(entry.metadata.Latitude, entry.metadata.Longitude);
                var pin = new Microsoft.Maps.Pushpin(loc, {title: entry.metadata.DisplayName});
                map.entities.push(pin);
            });
        });

        setUserPosition();
    }

    function setUserPosition() {
        navigator.geolocation.getCurrentPosition(function (position) {
            var loc = new Microsoft.Maps.Location(
                position.coords.latitude,
                position.coords.longitude);

            //Add a pushpin at the user's location.
            var pin = new Microsoft.Maps.Pushpin(loc, {color: 'blue', title: 'You'});
            map.entities.push(pin);

            //Center the map on the user's location.
            map.setView({center: loc, zoom: 15});
        });
    }
});
