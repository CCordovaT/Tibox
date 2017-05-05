(function () {
    'use strict';

    angular.module('app')
    .controller('loginController', loginController);

    loginController.$inject = ['authenticationService', '$state']

    function loginController(authenticationService, $state) {
        var vm = this;
        vm.user = {};
        vm.login = login;

        function login() {
            authenticationService.login(vm.user);
            $state.go('home');
        }
    }

})();