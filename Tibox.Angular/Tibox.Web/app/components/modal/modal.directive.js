(function () {

    'use strict';

    angular.module('app')
        .directive('modalPanel', modalPanel);

    function modalPanel() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                title: '@',
                buttonTitle: '@',
                saveFunction: '=',
                closeFunction: '=',
                readOnly: '=',
                isDelete: '='
            },
            templateUrl: 'app/components/modal/modal-directive.html'
        };
    }

})();