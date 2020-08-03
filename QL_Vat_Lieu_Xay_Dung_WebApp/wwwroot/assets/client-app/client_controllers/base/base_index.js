var BaseAjax = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $("body").on("click", ".remove-cart", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            $.ajax({
                url: "/ShopCart/RemoveFromCart",
                type: "post",
                data: {
                    productId: id
                },
                success: function () {
                    client_app.notify("Xóa Thành Công", "Thành Công");
                    loadHeaderCart();
                }
            });
        });
    }

    function loadHeaderCart() {
        $("#headerCart").load("/Home/RefreshCart");
    }

}