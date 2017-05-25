(function () {

    'use strict';

    angular.module('app').controller("supplierController", supplierController);

    supplierController.$inject = ['dataService', 'configService', '$state', '$timeout'];

    function supplierController(dataService, configService, $state, $timeout) {

        var apiUrl = configService.getApiUrl();
        var vm = this;

        //Primero propiedades
        vm.supplier = {};
        vm.supplierList = [];
        vm.modalTitle = '';
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;
        vm.showMessageConfirm = false;
        vm.errors = [];
        vm.showErrors = false;

        vm.headerId = "Id";
        vm.headerCompanyName = "Compañia";
        vm.headerContactName = "Contacto";
        vm.headerContactTitle = "Cargo contacto";
        vm.headerCity = "Ciudad";
        vm.headerCountry = "Pais";
        vm.headerPhone = "Teléfono";
        vm.headerFax = "Fax";

        //funciones
        vm.create = create;
        vm.edit = edit;
        vm.Delete = Delete;
        vm.getSupplier = getSupplier;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }

        function list() {
            dataService.getData(apiUrl + '/supplier/list')
            .then(function (result) {
                vm.supplierList = result.data;
            }, function (error) {
                vm.supplierList = [];
                console.log(error);
            });
        }

        function getSupplier(id) {
            vm.supplier = null;

            dataService.getData(apiUrl + '/supplier/' + id)
                .then(function (result) {
                    vm.supplier = result.data;
                },
                function (error) {
                    console.log(error);
                }
           );
        }

        function edit() {
            vm.modalTitle = 'Editar Supplier';
            vm.modalButtonTitle = 'Editar';
            vm.readOnly = true;
            vm.isDelete = true;
            vm.modalFunction = updateSupplier;
            vm.errors = [];
            vm.showErrors = false;
        }

        function Delete() {
            vm.modalTitle = 'Eliminar Supplier';
            vm.modalButtonTitle = 'Eliminar';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = deleteSupplier;
            vm.errors = [];
            vm.showErrors = false;
        }

        function updateSupplier() {
            if (!vm.supplier) return;
            dataService.putData(apiUrl + '/supplier', vm.supplier)
                .then(
                    function (result) {
                        vm.errors = [];
                        vm.showErrors = false;
                        vm.showMessageConfirm = true;
                        vm.supplier = {};
                        list();
                        closeModal();
                        $timeout(function () { vm.showMessageConfirm = false; }, 3000);
                    },
                    function (error) {
                        console.log(error);
                        vm.showErrors = true;
                        vm.errors = parseErrors(error);
                    }
                );
        }

        function deleteSupplier() {
            if (!vm.supplier) return;
            dataService.deleteData(apiUrl + '/supplier/' + vm.supplier.id)
                .then(
                    function (result) {
                        vm.showMessageConfirm = true;
                        vm.supplier = {};
                        list();
                        closeModal();
                        $timeout(function () { vm.showMessageConfirm = false; }, 3000);
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        }

        function create() {
            vm.supplier = {};
            vm.modalTitle = 'Crear nuevo supplier';
            vm.modalButtonTitle = 'Crear';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = createSupplier;
            vm.errors = [];
            vm.showErrors = false;
        }

        function createSupplier() {
            if (!vm.supplier) return;
            dataService.postData(apiUrl + '/supplier', vm.supplier)
                .then(
                    function (result) {
                        vm.errors = [];
                        vm.showErrors = false;
                        vm.showMessageConfirm = true;                        
                        list();
                        closeModal();
                        $timeout(function () { vm.showMessageConfirm = false; }, 3000);
                    },
                    function (error) {
                        console.log(error);
                        vm.showErrors = true;
                        vm.errors = parseErrors(error);
                    }
                );
        }

        function parseErrors(response) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(key + ' => ' + response.data.modelState[key][i]);
                }
            }
            return errors;
        }

        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }

    }

})();