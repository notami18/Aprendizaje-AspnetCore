(function () {
    "use strict";

    angular.module("app-trips", [])
        .controller("tripEditorController", tripEditorController);

    function tripEditorController($routeParams, $http) {
        var vm = this;

        vm.tripName = $routeParams.tripNAme;
        vm.stops = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips/" + vm.tripName + "/stops")
            .then(function (response) {
                // success
                angular.coppy(response.data, vm.stops);
                _showMap(vm.stops);
            }, function (error) {
                // error
                vm.errorMessage = "Error ala cargar los stops";
            })
            .finall(function () {
                vm.isBusy = false;
            });

    }

    function _showMap(stops) {

        if (stops && stops.length > 0) {

            // Show Map
            travelMap.createMap({
                stops: stops,
                selector: "#map", 
                currentStop: 1,
                initialZoom: 3
            });

        }

    }

})();