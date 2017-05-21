(function () {

    'use strict';

    angular.module('app').controller("customerController", customerController);

    customerController.$inject = ['dataService', 'configService', '$state'];

    function customerController(dataService, configService, $state) {

        var apiUrl = configService.getApiUrl();
        var vm = this;

        //Primero propiedades
        vm.customer = {};
        vm.customerList = [];
        vm.modalTitle = '';
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;

        vm.headerId = "Id";
        vm.headerFirstName = "Ape. Paterno";
        vm.headerLastName = "Ape. Materno";
        vm.headerCity = "Ciudad";
        vm.headerCountry = "País";
        vm.headerPhone = "Teléfono";

        //funciones
        vm.create = create;
        vm.edit = edit;
        vm.Delete = Delete;
        vm.getCustomer = getCustomer;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }

        function list() {
            dataService.getData(apiUrl + '/customer/list')
            .then(function (result) {
                vm.customerList = result.data;
            }, function (error) {
                vm.customerList = [];
                console.log(error);
            });
        }

        function getCustomer(id) {
            vm.customer = null;

            dataService.getData(apiUrl + '/customer/' + id)
                .then(function (result) {
                    vm.customer = result.data;
                },
                function (error) {
                    console.log(error);
                }
           );
        }

        function edit() {
            vm.modalTitle = 'Editar Customer';
            vm.modalButtonTitle = 'Editar';
            vm.readOnly = true;
            vm.isDelete = true;
            vm.modalFunction = updateCustomer;
        }

        function Delete() {
            vm.modalTitle = 'Eliminar Customer';
            vm.modalButtonTitle = 'Eliminar';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = deleteCustomer;
        }

        function updateCustomer() {
            if (!vm.customer) return;
            dataService.putData(apiUrl + '/customer', vm.customer)
                .then(
                    function (result) {
                        vm.customer = {};
                        list();
                        closeModal();
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        }

        function deleteCustomer() {
            if (!vm.customer) return;
            dataService.deleteData(apiUrl + '/customer/' + vm.customer.id)
                .then(
                    function (result) {
                        vm.customer = {};
                        list();
                        closeModal();
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        }

        function create() {
            vm.customer = {};
            vm.modalTitle = 'Crear nuevo customer';
            vm.modalButtonTitle = 'Crear';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = createCustomer;
        }

        function createCustomer() {
            if (!vm.customer) return;
            dataService.postData(apiUrl + '/customer', vm.customer)
                .then(
                    function (result) {
                        list();
                        closeModal();
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        }

        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }

    }

})();