(function (tibox) {
    tibox.order = tibox.order || {};

    tibox.order.getCustomers = function () {
        $.ajax(
            {
                url: '../Customer/Customers',
                type: 'GET',
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                success: function (response) {
                    response.forEach(function (item) {
                        $('#CustomerId')
                        .append("<option value='" + item.Id + "'>" +
                        item.FirstName + " " + item.LastName +
                        "</option>"
                        )
                    }, this);
                },
                error: function (error) {
                    alert(error);
                }
            }
        );
    };

    tibox.order.getProducts = function () {
        $.ajax(
            {
                url: '../Product/Products',
                type: 'GET',
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                success: function (response) {
                    response.forEach(function (item) {
                        $('#product')
                        .append("<option value='" + item.Id + "'>" +
                        item.ProductName+
                        "</option>"
                        )
                    }, this);
                },
                error: function (error) {
                    alert(error);
                }
            }
        );
    };
    
    tibox.order.addOrderItem = function () {
        var $row = $("#contentRow").clone().removeAttr('id');
        $('#product', $row).val($('#product').val());

        $('#addItemButton', $row).addClass('remove')
            .val('Remove')
            .removeClass('btn-success')
            .addClass('btn-danger');

        $('#product, #unitPrice, #quantity', $row).removeAttr('id');

        $('#orderItemList').append($row);

        $('#product').val('0');
        $('#unitPrice, #quantity').val('');
    };

    function init() {
        tibox.order.getCustomers();
        tibox.order.getProducts();
        $('#addItemButton').click(tibox.order.addOrderItem);

        $('#orderItemList').on('click', '.remove', function () {
            $(this).parents('tr').remove();
        });
    }

    init();

})(window.tibox = window.tibox || {});