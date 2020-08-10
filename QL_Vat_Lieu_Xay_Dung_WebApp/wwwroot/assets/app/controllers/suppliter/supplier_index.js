var SupplierAjax = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //Init validation
        $("#frmMaintainance").validate({
            errorClass: "red",
            ignore: [],
            lang: "vi",
            rules: {
                txtName: { required: true }
            }
        });
        $("#ddlShowPage").on("change", function () {
            app.configs.pageSize = $(this).val();
            app.configs.pageIndex = 1;
            loadData(true);
        });
        $("#btnSearch").click(function (e) {
            e.preventDefault();
            loadData();

        });
        $("#txtKeyword").keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData();
            }
        });
        $("#btnCreate").on("click", function () {
            resetFormMaintainance();
            $("#modal-add-edit").modal("show");

        });
        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Supplier/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hidId").val(data.Id);
                    $("#txtName").val(data.FullName);
                    $("#txtAddress").val(data.Address);
                    $("#txtPhoneNumber").val(data.PhoneNumber);
                    $("#ckStatus").prop("checked", data.Status === 1);
                    $("#hidDateCreated").val(data.DateCreated);
                    $("#modal-add-edit").modal("show");
                    app.stopLoading();

                },
                error: function () {
                    app.notify("Có lỗi xảy ra", "error");
                    app.stopLoading();
                }
            });
        });
        $("body").on("click", ".btn-delete", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            app.confirm("Are you sure to delete?", function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Supplier/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        app.startLoading();
                    },
                    success: function () {
                        app.notify("Xóa Thành Công", "success");
                        app.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        app.notify("Có lỗi trong quá trình xóa", "error");
                        app.stopLoading();
                    }
                });
            });
        });
        $("#btnSave").on("click", function (e) {
            if ($("#frmMaintainance").valid()) {
                e.preventDefault();
                var id = $("#hidId").val();
                var name = $("#txtName").val();
                var address = $("#txtAddress").val();
                var phoneNumber = $("#txtPhoneNumber").val();
                var dateCreated = $("#hidDateCreated").val();
                var status = $("#ckStatus").prop("checked") === true ? 1 : 0;


                $.ajax({
                    type: "POST",
                    url: "/Admin/Supplier/SaveEntity",
                    data: {
                        Id: id,
                        FullName: name,
                        Address: address,
                        PhoneNumber: phoneNumber,
                        DateCreated: dateCreated,
                        Status: status
                    },
                    dataType: "json",
                    beforeSend: function () {
                        app.startLoading();
                    },
                    success: function () {
                        app.notify("Cập nhật supplier thành công", "success");
                        $("#modal-add-edit").modal("hide");
                        resetFormMaintainance();

                        app.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        app.notify("Có lỗi trong quá trình lưu supplier", "error");
                        app.stopLoading();
                    }
                });
                return false;
            }

            return false;
        });
    }
    function resetFormMaintainance() {
        $("#hidId").val(0);
        $("#txtName").val("");
        $("#txtAddress").val("");
        $("#txtPhoneNumber").val("");
        $("#ckStatus").prop("checked", true);
        var today = new Date();
        var date = today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + today.getDate();
        $("#hidDateCreated").val(date);
    }
    function loadData(isPageChanged) {
        var template = $("#table-template").html();
        var tmp = "";
        $.ajax({
            type: "GET",
            data: {
                keyword: $("#txtKeyword").val(),
                page: app.configs.pageIndex,
                pageSize: app.configs.pageSize
            },
            url: "/Admin/Supplier/GetAllPaging",
            dataType: "json",
            success: function (response) {
                $.each(response.ResultList,
                    function (i, item) {
                        tmp += Mustache.render(template,
                            {
                                Id: item.Id,
                                Name: item.FullName,
                                Address: item.Address,
                                PhoneNumber: item.PhoneNumber,
                                Status: app.getStatus(item.Status)
                            });
                    }
                );
                $("#lblTotalRecords").text(response.RowCount);
                if (tmp !== "") {
                    $("#tbl-content").html(tmp);
                }
                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (response) {
                console.log(response);
                app.notify("Không thể tải dữ liệu", "error");
            }
        });
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