var ProductDetailAjax = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $("body").on("change", "#ddlSizeId", function (e) {
            e.preventDefault();
            var id = $("#ddlSizeId").data("id");
            var sizeId = parseInt($("#ddlSizeId").val());
            $.ajax({
                url: "/Product/CheckAvailability",
                type: "post",
                data: {
                    productId: id,
                    size: sizeId
                },
                success: function (response) {
                    $("#available").val(response.Data);
                    if (response.Data) {
                        if ($("#available_p").hasClass("out-of-stock")) {
                            $("#available_p").removeClass("out-of-stock").addClass("in-stock");
                            $("#btnAddToCart").css("visibility", "visible");
                        }
                    } else {
                        if ($("#available_p").hasClass("in-stock")) {
                            $("#available_p").removeClass("in-stock").addClass("out-of-stock");
                            $("#btnAddToCart").css("visibility", "hidden");
                        }

                    }
                }
            });
        });


        function loadHeaderCart() {
            $("#headerCart").load("/Home/RefreshCart");
        }

        $("#btnAddToCart").on("click", function (e) {
            e.preventDefault();
            var id = parseInt($(this).data("id"));
            var sizeId = parseInt($("#ddlSizeId").val());
            $.ajax({
                url: "/ShopCart/AddToCart",
                type: "post",
                dataType: "json",
                data: {
                    productId: id,
                    quantity: parseInt($("#txtQuantity").val()),
                    size: sizeId
                },
                success: function () {
                    loadHeaderCart();
                    client_app.notify("Thêm Thành Công", "Thành Công");
                }
            });
        });
    }
}