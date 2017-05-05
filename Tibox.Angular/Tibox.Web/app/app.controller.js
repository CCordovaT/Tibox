(function () {
    'use strict';
    angular.module('app')
        .controller('applicationController', applicationController);

    applicationController.$inject = ['$scope', 'configService', 'authenticationService'];

    function applicationController($scope, configService, authenticationService) {
        var vm = this;
        vm.validate = validate;
        vm.logout = logout;

        $scope.init = function (url) {
            configService.setApiUrl(url);
        }

        function validate() {
            return configService.getLogin();
        }

        function logout() {
            authenticationService.logout();
        }
    }

})();