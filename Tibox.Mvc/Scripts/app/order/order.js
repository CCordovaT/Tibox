(function (tibox) {

    tibox.order = tibox.order || {};
    tibox.order.getCustomers = function () {
        $.ajax({
            url: '../Customer/Customers',
            type: 'GET',
            headers: { "Content-Type": "application/json; charset=utf-8" },
            success: function (response) {
                response.forEach(function(item){
                    $('#Order_CustomerId').append("<option value='"+ item.Id +"'>" + item.FirstName + " " + item.LastName + "</option>")
                }, this);
            },
            error: function (error) {
                alert(error);
            }
        });
    };
    tibox.order.getProducts = function () {
        $.ajax( 
            {
                url: '../Product/Products',
                type: 'GET',
                headers: { "Content-Type": "application/json; charset=utf-8" },
                success: function (response) {
                    response.forEach(function (item) { 
                        $('#product').append("<option value='" + item.Id + "'>" + item.ProductName + "</option>")
                    }, this);
                },
                error: function (error) {
                    alert(error);
               }
            });
    };

    tibox.order.addOrderItem = function () {
        var $row = $("#contentRow").clone().removeAttr('id');
        $('#product', $row).val($('#product').val());

        $('#addItemButton', $row).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
        $('#product, #unitPrices, #quantity', $row).removeAttr('id');
        $('#orderItemList').append($row);
        $('#product').val('0');
        $('#unitPrice, #quantity').val('');
    }

    tibox.order.saveOrder = function () {
        
        var orderItemList = [];

        $('#orderItemList tbody tr').each(function fila(f, c) {

            var orderItem = {
                ProductId: $("select.product", this).val(),
                UnitPrice: parseFloat($(".unitPrice", this).val()),
                Quantity: parseInt($('.quantity', this).val())

            };
            orderItemList.push(orderItem);
        }
            );

        var data = {
            order: {
                OrderDate: $('#OrderDate').val().trim(),
                OrderNumber: $('#OrderNumber').val().trim(),
                CustomerId: $('#CustomerId').val().trim(),
                TotalAmount: $('#TotalAmount').val().trim()
            },
            OrderItems: orderItemList
        }

        $.ajax({
            url: '/Order/Save',
            type: "POST",
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (response) {
                window.location.replace("/Order/Index");
            },
            error: function (error) {
                alert(error);
            }
        })
    }

    function init() {

        tibox.order.getCustomers();
        tibox.order.getProducts();
        $('#addItemButton').click(tibox.order.addOrderItem); //va sin () para enviar la funcion y lo el resultado

        $('#orderItemList').on('click', '.remove', function () { $(this).parents('tr').remove(); })
    }

    init();

})(window.tibox = window.tibox || {});