(function () {
    'use strict';

    angular.module('app')
    .config(config).run(run);

    config.$inject = ['$compileProvider'];

    function config($compileProvider) {
        $compileProvider.debugInfoEnabled(true);
    }

    run.$inject = ['$http', '$state', 'localStorageService', 'configService'];

    function run($http,$state, localStorageService, configService) {
        var user = localStorageService.get('userToken');
        if(user && user.token){
            $http.defaults.headers.common.Authorization = 'Bearer ' + user.token;
            configService.setLogin(true);
            $state.go('product')
        }
        else $state.go('login');
    }

})();