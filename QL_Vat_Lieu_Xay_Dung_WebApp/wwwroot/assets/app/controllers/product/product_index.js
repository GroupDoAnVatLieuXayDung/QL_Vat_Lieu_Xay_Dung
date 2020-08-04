var product_ajax = function() {
    var imagesManagement = new ImagesManagementAjax();
    this.initialize = function() {
        loadCategory();
        loadData();
        registerEvents();
        registerCkEditor();
        imagesManagement.initialize();
    }

    function registerCkEditor() {
        CKEDITOR.replace("txtContent", {});
        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off("focusin.bs.modal") // guard against infinite focus loop
                .on("focusin.bs.modal", $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                            // CKEditor compatibility fix start.
                            && !$(e.target).closest(".cke_dialog, .cke").length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger("focus");
                    }
                }, this));
        };
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    function registerEvents() {
        //Init validation
        $("#frmMaintainance").validate({
            errorClass: "red",
            ignore: [],
            lang: "vi",
            rules: {
                txtName: { required: true },
                ddlCategoryId: { required: true },
                txtPrice: {
                    number: true,
                    min: 5000
                }
            }
        });
        $("#ddlShowPage").on("change", function() {
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

            //initTreeDropDownCategory();
            $("#modal-add-edit").modal("show");

        });
        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Product/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hidId").val(data.Id);
                    $("#txtName").val(data.Name);
                    initTreeDropDownCategory(data.CategoryId);
                    loadBrand(data.BrandId);
                    $("#txtDesc").val(data.Description);
                    $("#txtUnit").val(data.Unit);
                    $("#txtPrice").val(data.Price);
                    $("#txtOriginalPrice").val(data.OriginalPrice);
                    $("#txtPromotionPrice").val(data.PromotionPrice);
                    $("#txtImage").val(data.Image);
                    $("#hidDateCreated").val(data.DateCreated);
                    $("#txtTagM").val(data.Tags);
                    $("#txtMetaKeyWord").val(data.SeoKeywords);
                    $("#txtMetaDescription").val(data.SeoDescription);
                    $("#txtSeoPageTitle").val(data.SeoPageTitle);
                    $("#txtSeoAlias").val(data.SeoAlias);
                    disableFieldEdit(false);
                    CKEDITOR.instances["txtContent"].setData(data.Content);
                    $("#ckStatus").prop("checked", data.Status === 1);
                    $("#ckHot").prop("checked", data.HotFlag);
                    $("#ckShowHome").prop("checked", data.HomeFlag);
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
                    url: "/Admin/Product/Delete",
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
                var categoryId = $("#ddlCategoryId").combotree("getValue");
                var description = $("#txtDesc").val();
                var unit = $("#txtUnit").val();
                var price = $("#txtPrice").val();
                var originalPrice = $("#txtOriginalPrice").val();
                var promotionPrice = $("#txtPromotionPrice").val();
                var dateCreated = $("#hidDateCreated").val();
                var image = $("#txtImage").val();
                var tags = $("#txtTag").val();
                var seoKeyword = $("#txtMetaKeyWord").val();
                var seoMetaDescription = $("#txtMetaDescription").val();
                var seoPageTitle = $("#txtSeoPageTitle").val();
                var seoAlias = $("#txtSeoAlias").val();
                var brandId = $("#ddlBrandId").val();
                var content = CKEDITOR.instances["txtContent"].getData();


                var status = $("#ckStatus").prop("checked") === true ? 1 : 0;
                var hot = $("#ckHot").prop("checked");
                var showHome = $("#ckShowHome").prop("checked");

                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        CategoryId: categoryId,
                        Image: image,
                        Price: price,
                        OriginalPrice: originalPrice,
                        PromotionPrice: promotionPrice,
                        Description: description,
                        Content: content,
                        HomeFlag: showHome,
                        BrandId: brandId,
                        HotFlag: hot,
                        Tags: tags,
                        Unit: unit,
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
                        app.notify("Cập nhật sản phẩm thành công", "success");
                        $("#modal-add-edit").modal("hide");
                        resetFormMaintainance();

                        app.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        app.notify("Có lỗi trong quá trình lưu sản phẩm", "error");
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////





    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            type: "GET",
            dataType: "json",
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var arr = app.unflattern(data);
                $("#ddlCategoryId").combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $("#ddlCategoryId").combotree("setValue", selectedId);
                }
            }
        });
    }





    function resetFormMaintainance() {
        $("#hidId").val(0);
        $("#txtName").val("");
        disableFieldEdit(true);
        initTreeDropDownCategory("");
        var today = new Date();
        var date = today.getFullYear()+"-"+(today.getMonth()+1)+"-"+today.getDate();
        $("#hidDateCreated").val(date);
        $("#txtDesc").val("");
        $("#txtUnit").val("");
        loadBrand(null);
        $("#txtPrice").val("0");
        $("#txtPromotionPrice").val("");

        $("#txtImage").val("");

        $("#txtTag").val("");
        $("#txtMetaKeyWord").val("");
        $("#txtMetaDescription").val("");
        $("#txtSeoPageTitle").val("");
        $("#txtSeoAlias").val("");

        CKEDITOR.instances["txtContent"].setData("");
        $("#ckStatus").prop("checked", true);
        $("#ckHot").prop("checked", false);
        $("#ckShowHome").prop("checked", false);

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    function loadCategory() {
        $.ajax({
            type: "GET",
            url: "/Admin/ProductCategory/GetAll",
            dataType: "json",
            success: function (response) {
                var tmp = "<option value = ''>=== Select Category ===</option>";
                $.each(response,
                    function(i, item) {
                        tmp += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                    });
                $("#ddlCategorySearch").html(tmp);
            },
            error: function(response) {
                console.log(response);
                app.notify("Không thể tải danh mục", "error");
            }
        });
    }


    function loadBrand(selectedId) {
        $.ajax({
            type: "GET",
            url: "/Admin/Brand/GetAll",
            dataType: "json",
            success: function (response) {
                var tmp = "<option value = ''>=== Select Brand ===</option>";
                $.each(response,
                    function (i, item) {
                        tmp += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                    });

                $("#ddlBrandId").html(tmp);
                if (selectedId != undefined) {
                    $("#ddlBrandId").val(selectedId);
                }
            },
            error: function (response) {
                console.log(response);
                app.notify("Không thể tải danh mục thương hiệu", "error");
            }
        });
    }
    function disableFieldEdit(disabled) {
        $("#txtPromotionPrice").prop("disabled", disabled);
        $("#txtPrice").prop("disabled", disabled);
    }
    function loadData(isPageChanged) {
        var template = $("#table-template").html();
        var tmp = "";
        $.ajax({
            type: "GET",
            data:{
                categoryId: $("#ddlCategorySearch").val(),
                keyword:$("#txtKeyword").val(),
                page: app.configs.pageIndex,
                pageSize:app.configs.pageSize
            },
            url: "/Admin/Product/GetAllPaging",
            dataType: "json",
            success: function (response) {
                $.each(response.ResultList,
                    function(i, item) {
                        console.log("lay data"+item);
                        tmp += Mustache.render(template,
                            {
                                Id: item.Id,
                                Name: item.Name,
                                Image: item.Image == null ? '<img src="img.jpg" width=25' : '<img src="' + item.Image + '" width=25 />',
                                CategoryName: item.ProductCategory.Name,
                                Price: app.formatNumber(item.Price, 0),
                                CreatedDate: app.dateFormatJson(item.DateCreated),
                                Status: app.getStatus(item.Status)
                            });
                    }
                );
                $("#lblTotalRecords").text(response.RowCount);
                if (tmp !== "") {
                    $("#tbl-content").html(tmp);
                }
                wrapPaging(response.RowCount,function(){
                    loadData();
                },isPageChanged);
            },
            error: function(response) {
                console.log(response);
                app.notify("Không thể tải dữ liệu", "error");
            }
        });
    }
   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



   ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / app.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($("#paginationUL a").length === 0 || changePageSize === true) {
            $("#paginationUL").empty();
            $("#paginationUL").removeData("twbs-pagination");
            $("#paginationUL").unbind("page");
        }
        //Bind Pagination Event
        $("#paginationUL").twbsPagination({
            totalPages: totalsize,
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
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}