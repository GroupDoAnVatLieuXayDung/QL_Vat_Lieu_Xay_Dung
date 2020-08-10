var BrandAjax = function () {
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
                txtName: { required: true },
                txtImage: { required: true },
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
                url: "/Admin/Brand/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hidId").val(data.Id);
                    $("#txtName").val(data.Name);
                    $("#txtImage").val(data.Image);
                    $("#txtDisplayOrder").val(data.DisplayOrder);
                    $("#ckStatus").prop("checked", data.Status === 1);
                    $("#hidDateCreated").val(data.DateCreated);
                    $("#txtMetaKeyWord").val(data.SeoKeywords);
                    $("#txtMetaDescription").val(data.SeoDescription);
                    $("#txtSeoPageTitle").val(data.SeoPageTitle);
                    $("#txtSeoAlias").val(data.SeoAlias);
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
                    url: "/Admin/Brand/Delete",
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
                var image = $("#txtImage").val();
                var displayOrder = $("#txtDisplayOrder").val();
                var dateCreated = $("#hidDateCreated").val();
                var seoKeyword = $("#txtMetaKeyWord").val();
                var seoMetaDescription = $("#txtMetaDescription").val();
                var seoPageTitle = $("#txtSeoPageTitle").val();
                var seoAlias = $("#txtSeoAlias").val();
                var status = $("#ckStatus").prop("checked") === true ? 1 : 0;


                $.ajax({
                    type: "POST",
                    url: "/Admin/Brand/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        Image: image,
                        DisplayOrder: displayOrder,
                        DateCreated: dateCreated,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    beforeSend: function () {
                        app.startLoading();
                    },
                    success: function () {
                        app.notify("Cập nhật brand thành công", "success");
                        $("#modal-add-edit").modal("hide");
                        resetFormMaintainance();

                        app.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        app.notify("Có lỗi trong quá trình lưu brand", "error");
                        app.stopLoading();
                    }
                });
                return false;
            }

            return false;
        });
        $("#btnSelectImg").on("click", function () {
            $("#fileInputImage").click();
        });
        $("#fileInputImage").on("change", function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/UploadImageFile/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $("#txtImage").val(path);
                    app.notify("Tải ảnh lên thành công", "success");

                },
                error: function () {
                    app.notify("Có lỗi trong quá trình tải ảnh!", "error");
                }
            });
        });
    }
    function resetFormMaintainance() {
        $("#hidId").val(0);
        $("#txtName").val("");
        $("#txtImage").val("");
        $("#txtDisplayOrder").val(0);
        $("#ckStatus").prop("checked", true);
        var today = new Date();
        var date = today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + today.getDate();
        $("#hidDateCreated").val(date);
        $("#txtMetaKeyWord").val("");
        $("#txtMetaDescription").val("");
        $("#txtSeoPageTitle").val("");
        $("#txtSeoAlias").val("");
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
            url: "/Admin/Brand/GetAllPaging",
            dataType: "json",
            success: function (response) {
                $.each(response.ResultList,
                    function (i, item) {
                        tmp += Mustache.render(template,
                            {
                                Id: item.Id,
                                Name: item.Name,
                                Image: item.Image === null ? '<img src="img.jpg" width=25' : '<img src="' + item.Image + '" width=25 />',
                                DisplayOrder: item.DisplayOrder,
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