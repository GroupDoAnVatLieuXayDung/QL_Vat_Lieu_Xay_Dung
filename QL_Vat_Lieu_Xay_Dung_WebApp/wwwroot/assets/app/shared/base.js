var BaseAjax = function () {

    this.initialize = function () {
        loadAnnouncement();
        registerEvents();
    }

    function registerEvents() {
        $("body").on("click", ".checkRead", function (e) {
            e.preventDefault();
            var that = $(this).closest("li");
            $.ajax({
                type: "POST",
                url: "/Admin/Account/MarkAsRead",
                data: {
                    id: that.data("id")
                },
                dataType: "json",
                beforeSend: function () {
                    app.startLoading();
                },
                success: function (response) {
                    that.remove();
                    var updateTotalAnnouncement = parseInt($("#totalAnnouncement").text()) - 1;
                    $("#totalAnnouncement").text(updateTotalAnnouncement);
                    app.notify("Successfully Checked", "success");
                    app.stopLoading();

                },
                error: function (status) {
                    app.notify("Có lỗi xảy ra", "error");
                    app.stopLoading();
                }
            });
        });


    };

    function loadAnnouncement() {
        $.ajax({
            type: "GET",
            url: "/admin/Account/GetAllPaging",
            data: {
                page: app.configs.pageIndex,
                pageSize: app.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                app.startLoading();
            },
            success: function (response) {
                var template = $("#announcement-template").html();
                var render = "";
                console.log(response.ResultList);
                if (response.RowCount > 0) {
                    $("#announcementArea").show();
                    $.each(response.ResultList, function (i, item) {
                        render += Mustache.render(template, {
                            Content: item.Content,
                            Id: item.Id,
                            Title: item.Title,
                            Avatar: item.Image,
                            UserId: item.UserId,
                            DateCreated: moment(item.DateCreated).fromNow()
                        });
                    });
                    render += $("#announcement-tag-template").html();
                    $("#totalAnnouncement").text(response.RowCount);
                    if (render != undefined) {
                        $("#announcementList").html(render);
                    }
                }
                else {
                    $("#announcementArea").hide();
                    $("#announcementList").html("");
                }
                app.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    };


}