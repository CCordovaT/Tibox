(function (tibox) {
    tibox.shared = tibox.shared || {};

    tibox.shared.renderModal = function (url) {
        $.get(url, function (data) {
            $('.modal-body').html(data);
        });
    };

    tibox.shared.closeModal = function () {
        document.querySelector("button[data-dismiss='modal']").click();
        document.querySelector('.modal-body').innerHtml = '';
        console.log('Message called');
    }
    
})(window.tibox = window.tibox || {});