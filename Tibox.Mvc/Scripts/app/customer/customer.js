(function (tibox) {

    tibox.customer = tibox.customer || {};
    tibox.customer.rowSize = 25;
    tibox.customer.pages = 1;

    function init() {
        $.get('/Customer/Count/' + tibox.customer.rowSize,
            function (data) {
                tibox.customer.pages = data.totalPages;
                $('.pagination').bootpag({
                    total: tibox.customer.pages,
                    page: 1,
                    maxVisible: 5,                    
                    leaps: false,
                    next: 'next',
                    prev: 'prev'
                }).on('page', function (event, num) {
                    getCustomers(num);
                });
            })
    }

    function getCustomers(num) {
        var url = '/customer/List/' + num + '/' + tibox.customer.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

    init();
    getCustomers(1);

})(window.tibox = window.tibox || { })