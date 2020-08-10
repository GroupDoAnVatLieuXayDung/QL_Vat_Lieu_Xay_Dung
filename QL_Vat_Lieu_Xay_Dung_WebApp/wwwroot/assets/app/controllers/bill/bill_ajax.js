var bill_ajax = function () {
    var cachedObj = {
        products: [],
        paymentMethods: [],
        billStatuses: []
    };
    this.initialize = function () {
        $.when(loadBillStatus(),
            loadPaymentMethod(),
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
                txtCustomerName: { required: true },
                txtCustomerAddress: { required: true },
                txtCustomerMobile: { required: true },
                txtCustomerMessage: { required: true },
                ddlBillStatus: { required: true }
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
                url: "/Admin/Bill/GetById",
                data: { id: that },
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hidId").val(data.Id);
                    $("#txtCustomerName").val(data.CustomerName);
                    $("#hidDateCreated").val(data.DateCreated);
                    $("#txtCustomerAddress").val(data.CustomerAddress);
                    $("#txtCustomerMobile").val(data.CustomerMobile);
                    $("#txtCustomerMessage").val(data.CustomerMessage);
                    $("#ddlPaymentMethod").val(data.PaymentMethod);
                    $("#hidCustomerId").val(data.CustomerId);
                    $("#ddlBillStatus").val(data.BillStatus);
                    var arr = [];
                    var billDetails = data.BillDetails;
                    if (data.BillDetails != null && data.BillDetails.length > 0) {
                        var render = "";
                        var templateDetails = $("#template-table-bill-details").html();

                        $.each(billDetails, function (i, item) {
                            var products = getProductOptions(item.ProductId);
                            arr.push({ "Id": item.Id, "ProductId": item.ProductId, "SizeId": item.SizeId });
                            render += Mustache.render(templateDetails,
                                {
                                    Id: item.Id,
                                    Products: products,
                                    Quantity: item.Quantity
                                });
                            $("#tbl-bill-details").html(render);
                        });
                        $.each(arr, function (i, item) {
                            var trSize = $('[data-id="' + item.Id + '"]').find(".ddlSizeId");
                            trSize.removeAttr("disabled");
                            loadSizesByProductId(trSize, item.ProductId, item.SizeId);
                        });
                       
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
                var customerName = $("#txtCustomerName").val();
                var customerAddress = $("#txtCustomerAddress").val();
                var customerMobile = $("#txtCustomerMobile").val();
                var customerMessage = $("#txtCustomerMessage").val();
                var paymentMethod = $("#ddlPaymentMethod").val();
                var billStatus = $("#ddlBillStatus").val();
                var dateCreated = $("#hidDateCreated").val();
                var customerId = $("#hidCustomerId").val();

                //bill detail
                var billDetails = [];
                $.each($("#tbl-bill-details tr"), function (i, item) {
                    billDetails.push({
                        Id: $(item).data("id"),
                        ProductId: $(item).find("select.ddlProductId").first().val(),
                        Quantity: $(item).find("input.txtQuantity").first().val(),
                        SizeId: $(item).find("select.ddlSizeId").first().val(),
                        BillId: id
                    });
                });

                $.ajax({
                    type: "POST",
                    url: "/Admin/Bill/SaveEntity",
                    data: {
                        Id: id,
                        BillStatus: billStatus,
                        CustomerAddress: customerAddress,
                        CustomerId: customerId,
                        CustomerMessage: customerMessage,
                        CustomerMobile: customerMobile,
                        CustomerName: customerName,
                        DateCreated: dateCreated,
                        PaymentMethod: paymentMethod,
                        Status: 1,
                        BillDetails: billDetails
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
            var template = $("#template-table-bill-details").html();
            var products = getProductOptions(null);
            var render = Mustache.render(template,
                {
                    Id: 0,
                    Products: products,
                    Quantity: 0,
                    Total: 0
                });
            $("#tbl-bill-details").append(render);
        });

        $("body").on("click", ".btn-delete-detail", function () {
            $(this).parent().parent().remove();
            // $(this) => nó là thẻ <button>
            // $(this).parent() => nó sẽ chạy ra thẻ td
            // $(this).parent().parent() => nó chạy ra thẻ <tr>
        });
        $("body").on("change", ".ddlProductId", function (event) {
            var element = $(this).closest("tr").find(".ddlSizeId");
            element.removeAttr("disabled");
            loadSizesByProductId(element, $(this).val(),null);
        });
    };

    function loadSizesByProductId(element, productId, selectedId) {
        return $.ajax({
            type: "GET",
            url: "/Admin/ProductReceipt/GetReceiptDetailsByProductId",
            data: {
                id: parseInt(productId)
            },
            DaType: "json",
            success: function (response) {
                var sizes = "<option value = ''>=== Select Size ===</option>";
             
                $.each(response, function (i, item) {
                    if (selectedId === item.Size.Id) {
                        sizes += '<option value="' + item.Size.Id + '" selected="select">' + item.Size.Name + "</option>";
                    }
                    else {
                        sizes += '<option value="' + item.Size.Id + '">' + item.Size.Name + "</option>";
                    }
                    $(element).html(sizes);
                });

            },
            error: function () {
                app.notify("Has an error in progress", "error");
            }
        });
    }




    function loadBillStatus() {
        return $.ajax({
            type: "GET",
            url: "/admin/bill/GetBillStatus",
            dataType: "json",
            success: function (response) {
                cachedObj.billStatuses = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $("#ddlBillStatus").html(render);
            }
        });
    }

    function loadPaymentMethod() {
        return $.ajax({
            type: "GET",
            url: "/admin/bill/GetPaymentMethod",
            dataType: "json",
            success: function (response) {
                cachedObj.paymentMethods = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $("#ddlPaymentMethod").html(render);
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

    function getProductOptions(selectedId) {
        var products = "<select required class='form-control ddlProductId'>";
        products += "<option value = ''>=== Select Product ===</option>";
        $.each(cachedObj.products, function (i, product) {
            if (selectedId === product.Id)
                products += '<option value="' + product.Id + '" selected="select">' + product.Name + "</option>";
            else {
                products += '<option value="' + product.Id + '">' + product.Name + "</option>";
            }
        });
        products += "</select>";
        return products;
    }

  



    function resetFormMaintainance() {
        $("#hidId").val(0);
        $("#txtCustomerName").val("");
        var today = new Date();
        var date = today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + today.getDate();
        $("#hidDateCreated").val(date);
        $("#txtCustomerAddress").val("");
        $("#txtCustomerMobile").val("");
        $("#txtCustomerMessage").val("");
        $("#ddlPaymentMethod").val("");
        $("#ddlBillStatus").val("");
        $("#tbl-bill-details").html("");
    }

    function loadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/admin/bill/GetAllPaging",
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
                            CustomerName: item.CustomerName,
                            Id: item.Id,
                            Total: app.formatNumber(item.Total, 0),
                            PaymentMethod: getPaymentMethodName(item.PaymentMethod),
                            DateCreated: app.dateTimeFormatJson(item.DateCreated),
                            BillStatus: getBillStatusName(item.BillStatus)
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
    function getPaymentMethodName(paymentMethod) {
        var method = $.grep(cachedObj.paymentMethods, function (element) {
            return element.Value === paymentMethod;
        });
        if (method.length > 0)
            return method[0].Name;
        else return "";
    }
    function getBillStatusName(status) {
        status = $.grep(cachedObj.billStatuses, function (element) {
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