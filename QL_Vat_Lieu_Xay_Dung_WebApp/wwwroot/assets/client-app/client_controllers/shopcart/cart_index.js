var ProductAjax = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $("body").on("click", ".btn-delete", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            $.ajax({
                url: "/ShopCart/RemoveFromCart",
                type: "post",
                data: {
                    productId: id
                },
                success: function () {
                    client_app.notify("Xóa Thành Công.", "Thành Công");
                    loadHeaderCart();
                    loadData();
                }
            });
        });
        $("body").on("keyup", ".txtQuantity", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var q = $(this).val();
            if (q > 0) {
                $.ajax({
                    url: "/ShopCart/UpdateCart",
                    type: "post",
                    data: {
                        productId: id,
                        quantity: q
                    },
                    success: function () {
                        client_app.notify("Cập Nhật Thành Công", "Thành Công");
                        loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                client_app.notify("Số Lượng Này Không Tồn Tại", "error");
            }

        });


        $("#btnClearAll").on("click", function (e) {
            e.preventDefault();
            $.ajax({
                url: "/ShopCart/ClearCart",
                type: "post",
                success: function () {
                    client_app.notify("Đã Xóa Sạch Sản Phẩm Trong Giỏ Hàng", "Thành Công");
                    loadHeaderCart();
                    loadData();
                }
            });
        });
    }
    function loadHeaderCart() {
        $("#headerCart").load("/Home/RefreshCart");
    }




    function loadData() {
        $.ajax({
            url: "/ShopCart/GetCart",
            type: "GET",
            dataType: "json",
            success: function (response) {
                var template = $("#template-cart").html();
                var render = "";
                var totalAmount = 0;
                $.each(response, function (i, item) {
                    render += Mustache.render(template,
                        {
                            ProductId: item.Product.Id,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: item.Price.toLocaleString("vi", {style : "currency", currency : "VND"}),
                            Quantity: item.Quantity,
                            Sizes: item.Size.Name,
                            Amount: (item.Price * item.Quantity).toLocaleString("vi", {style : "currency", currency : "VND"}),
                            Url: "/" + item.Product.SeoAlias + "-p." + item.Product.Id + ".html"
                        });
                    totalAmount += item.Price * item.Quantity;
                });
                $("#lblTotalAmount").text(totalAmount.toLocaleString("vi", {style : "currency", currency : "VND"}));
                if (render !== "")
                    $("#table-cart-content").html(render);
                else
                    $("#table-cart-content").html("Không Có Sản Phẩm Trong Giỏ Hàng");
            }
        });
        return false;
    }
}