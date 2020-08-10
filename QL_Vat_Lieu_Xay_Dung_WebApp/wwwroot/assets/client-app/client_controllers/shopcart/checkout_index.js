var checkoutAjax = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $("#btn1").on("click", function (e) {
            e.preventDefault();
            $("#btn1").closest(".box-border").toggle();
            $("#btn2").closest(".box-border").toggle("slow");
        });
        $("#btn2").on("click", function (e) {
            e.preventDefault();
            $("#btn2").closest(".box-border").toggle();
            $("#btn3").closest(".box-border").toggle("slow");
        });
        $("#btn3").on("click", function (e) {
            e.preventDefault();
            $("#btn3").closest(".box-border").toggle();
            $("#box1").closest(".box-border").toggle("slow");
        });
    }

    function loadData() {
        console.log($("#txtCheckUser").val());
        if ($("#txtCheckUser").val() == 1) {
            $("#btn1").closest(".box-border").toggle("slow");
            $("#btn3").closest(".box-border").toggle("slow");
            $("#box1").toggle("slow");
        }
        else
        {
            $("#btn2").closest(".box-border").toggle("slow");
            $("#btn3").closest(".box-border").toggle("slow");
            $("#box1").toggle("slow");
        }
    }
}