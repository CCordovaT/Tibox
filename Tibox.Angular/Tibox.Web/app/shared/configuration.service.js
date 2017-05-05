﻿(function () {
    'use strict';
    angular.module('app')
        .factory('configService', configService);

    function configService() {
        var service = {};
        var apiUrl = undefined;
        var isLogged = false;

        service.setLogin = setLogin;
        service.getLogin = getLogin;
        service.getApiUrl = getApiUrl;
        service.setApiUrl = setApiUrl;

        return service;

        function setLogin(status) {
            isLogged = status;
        }

        function getLogin() {
            return isLogged;
        }

        function setApiUrl(url) {
            apiUrl = url;
        }

        function getApiUrl() {
            return apiUrl;
        }
    }

})();