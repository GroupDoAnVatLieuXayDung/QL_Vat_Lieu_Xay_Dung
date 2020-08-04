var receipt_ajax = function () {
    var cachedObj = {
        products: [],
        sizes: [],
        receiptStatuses: []
    }
    this.initialize = function () {
        $.when(loadReceiptStatus(),
                loadSizes(),
                loadProducts())
            .done(function () {
                loadData();
            });

        registerEvents();
    }

    function registerEvents() {
        $("#txtFromDate, #txtToDate").datepicker({
            autoclose: true,
            format: "dd/mm/yyyy"
        });
        //Init validation
        $("#frmMaintainance").validate({
            errorClass: "red",
            ignore: [],
            lang: "vi",
            rules: {
                ddlSupplierName: { required: true },
                ddlReceiptStatus: { required: true },
                txtOriginalPrice: {
                    required: true,
                    integer: true,
                    min : 0

                 },
                txtQuantity: {
                    required: true,
                    integer: true,
                    range: [0, 100]
                }
            }
        });
        $("#txt-search-keyword").keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData();
            }
        });
        $("#btn-search").on("click", function () {
            loadData();
        });

        $("#btn-create").on("click", function () {
            resetFormMaintainance();
            $("#modal-detail").modal("show");
        });
        $("#ddl-show-page").on("change", function () {
            app.configs.pageSize = $(this).val();
            app.configs.pageIndex = 1;
            loadData(true);
        });

        $("body").on("click", ".btn-view", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/ProductReceipt/GetById",
                data: { id: that },
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hidId").val(data.Id);
                    $("#hidUserId").val(data.UserId);
                    $("#hidDateCreated").val(data.DateCreated);
                    $("#ddlReceiptStatus").val(data.ReceiptStatus);
                    loadSupplier(data.SupplierId);

                    var receiptDetails = data.ProductReceiptDetails;
                    if (data.ProductReceiptDetails != null && data.ProductReceiptDetails.length > 0) {
                        var render = "";
                        var templateDetails = $("#template-table-receipt-details").html();

                        $.each(receiptDetails, function (i, item) {
                            var products = getProductOptions(item.ProductId);
                            var sizes = getSizeOptions(item.SizeId);

                            render += Mustache.render(templateDetails,
                                {
                                    Id: item.Id,
                                    Products: products,
                                    Sizes: sizes,
                                    OriginalPrice: item.OriginalPrice,
                                    Quantity: item.Quantity
                                });
                        });
                        $("#tbl-receipt-details").html(render);
                    }
                    $("#modal-detail").modal("show");
                    app.stopLoading();

                },
                error: function () {
                    app.notify("Has an error in progress", "error");
                    app.stopLoading();
                }
            });
        });

        $("#btnSave").on("click", function (e) {
            if ($("#frmMaintainance").valid()) {
                e.preventDefault();
                var id = $("#hidId").val();
                var userId = $("#hidUserId").val();
                var supplierId = $("#ddlSupplierName").val();
                var receiptStatus = $("#ddlReceiptStatus").val();
                var dateCreated = $("#hidDateCreated").val();


                //bill detail
                var receiptDetails = [];
                $.each($("#tbl-receipt-details tr"), function (i, item) {
                    receiptDetails.push({
                        Id: $(item).data("id"),
                        ProductId: $(item).find("select.ddlProductId").first().val(),
                        Quantity: $(item).find("input.txtQuantity").first().val(),
                        SizeId: $(item).find("select.ddlSizeId").first().val(),
                        OriginalPrice: $(item).find("input.txtOriginalPrice").first().val(),
                        ProductReceiptId: id
                    });
                });

                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductReceipt/SaveEntity",
                    data: {
                        Id: id,
                        SupplierId: supplierId,
                        UserId: userId,
                        DateCreated: dateCreated,
                        ReceiptStatus: receiptStatus,
                        ProductReceiptDetails: receiptDetails
                    },
                    dataType: "json",
                    beforeSend: function () {
                        app.startLoading();
                    },
                    success: function () {
                        app.notify("Save order successful", "success");
                        $("#modal-detail").modal("hide");
                        resetFormMaintainance();

                        app.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        app.notify("Has an error in progress", "error");
                        app.stopLoading();
                    }
                });
                return false;
            }

            return false;
        });

        $("#btnAddDetail").on("click", function () {
            var template = $("#template-table-receipt-details").html();
            var products = getProductOptions(null);
            var sizes = getSizeOptions(null);
            var render = Mustache.render(template,
                {
                    Id: 0,
                    Products: products,
                    Sizes: sizes,
                    Quantity: 0,
                    OriginalPrice: 0,
                    Total: 0
                });
            $("#tbl-receipt-details").append(render);
        });

        $("body").on("click", ".btn-delete-detail", function () {
            $(this).parent().parent().remove();
        });
    };

    function loadReceiptStatus() {
        return $.ajax({
            type: "GET",
            url: "/admin/ProductReceipt/GetReceiptStatus",
            dataType: "json",
            success: function (response) {
                cachedObj.receiptStatuses = response;
                var render = "<option value = ''>=== Select Receipt Status ===</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $("#ddlReceiptStatus").html(render);
            }
        });
    }
    function loadProducts() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Product/GetAll",
            dataType: "json",
            success: function (response) {
                cachedObj.products = response;
            },
            error: function () {
                app.notify("Has an error in progress", "error");
            }
        });
    }
    function loadSizes() {
        return $.ajax({
            type: "GET",
            url: "/Admin/ProductReceipt/GetSizes",
            dataType: "json",
            success: function (response) {
                cachedObj.sizes = response;
            },
            error: function () {
                app.notify("Has an error in progress", "error");
            }
        });
    }
    function loadSupplier(selectedId) {
        $.ajax({
            type: "GET",
            url: "/Admin/Supplier/GetAll",
            dataType: "json",
            success: function (response) {
                var tmp = "<option value = ''>=== Select Supplier ===</option>";
                $.each(response,
                    function (i, item) {
                        tmp += "<option value='" + item.Id + "'>" + item.FullName + "</option>";
                    });

                $("#ddlSupplierName").html(tmp);
                if (selectedId != undefined) {
                    $("#ddlSupplierName").val(selectedId);
                }
            },
            error: function (response) {
                console.log(response);
                app.notify("Không thể tải danh mục nhà cung cấp", "error");
            }
        });
    }
    function getProductOptions(selectedId) {
        var products = "<select required class='form-control ddlProductId'>";
        products += "<option value = ''>=== Select Product ===</option>";
        $.each(cachedObj.products, function (i, product) {
            if (selectedId === product.Id)
                products += '<option value="' + product.Id + '" selected="select">' + product.Name + "</option>";
            else
                products += '<option value="' + product.Id + '">' + product.Name + "</option>";
        });
        products += "</select>";
        return products;
    }
    function getSizeOptions(selectedId) {
        var sizes = "<select required class='form-control ddlSizeId'>";
        sizes += "<option value = ''>=== Select Size ===</option>";
        $.each(cachedObj.sizes, function (i, size) {
            if (selectedId === size.Id)
                sizes += '<option value="' + size.Id + '" selected="select">' + size.Name + "</option>";
            else
                sizes += '<option value="' + size.Id + '">' + size.Name + "</option>";
        });
        sizes += "</select>";
        return sizes;
    }
    function resetFormMaintainance() {
        $("#hidId").val(0);
        var today = new Date();
        var date = today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + today.getDate();
        $("#hidDateCreated").val(date);
        $("#hidUserId").val("");
        loadSupplier(null);
        loadReceiptStatus();
        $("#tbl-receipt-details").html("");
    }

    function loadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/admin/ProductReceipt/GetAllPaging",
            data: {
                startDate: $("#txtFromDate").val(),
                endDate: $("#txtToDate").val(),
                keyword: $("#txtSearchKeyword").val(),
                page: app.configs.pageIndex,
                pageSize: app.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                app.startLoading();
            },
            success: function (response) {
                var template = $("#table-template").html();
                var render = "";
                if (response.RowCount > 0) {
                    $.each(response.ResultList, function (i, item) {
                        render += Mustache.render(template, {
                            Name: item.Supplier.FullName,
                            Id: item.Id,
                            Total: app.formatNumber(item.Total, 0),
                            DateCreated: app.dateTimeFormatJson(item.DateCreated),
                            ReceiptStatus: getReceiptStatusName(item.ReceiptStatus)
                        });
                    });
                    $("#lbl-total-records").text(response.RowCount);
                    if (render != undefined) {
                        $("#tbl-content").html(render);

                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);


                }
                else {
                    $("#lbl-total-records").text("0");
                    $("#tbl-content").html("");
                }
                app.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    };
    function getReceiptStatusName(status) {
        status = $.grep(cachedObj.receiptStatuses, function (element) {
            return element.Value === status;
        });
        if (status.length > 0)
            return status[0].Name;
        else return "";
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalSize = Math.ceil(recordCount / app.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($("#paginationUL a").length === 0 || changePageSize === true) {
            $("#paginationUL").empty();
            $("#paginationUL").removeData("twbs-pagination");
            $("#paginationUL").unbind("page");
        }
        //Bind Pagination Event
        $("#paginationUL").twbsPagination({
            totalPages: totalSize,
            visiblePages: 7,
            first: "Đầu",
            prev: "Trước",
            next: "Tiếp",
            last: "Cuối",
            onPageClick: function (event, p) {
                app.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}