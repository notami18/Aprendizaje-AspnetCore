(function () {

    "use strict";

    angular.module("app-trips", [])
        .controller("tripsController", tripsController);

    function tripsController($http) {    
        var vm = this;

        vm.trips = [];

        vm.newTrip = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips")
            .then(function (response) {
                angular.copy(response.data, vm.trips);
            }, function (error) {
                vm.errorMessage = "fallo al cargar la información: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addTrip = function () {
            /*vm.trips.push({ name: vm.newTrip.name, created: new Date() });
            vm.newTrip = {};*/

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/trips", vm.newTrip)
                .then(function (response) {
                    // success
                    vm.trips.push(response.data);
                    vm.newTrip = {};
                }, function (error) {
                    // Failure
                    vm.errorMessage = "Fallo al guardar un nuevo viaje";
                })
                .finally(function () {
                    vm.isBusy = false;
                });

        };
    }

})();