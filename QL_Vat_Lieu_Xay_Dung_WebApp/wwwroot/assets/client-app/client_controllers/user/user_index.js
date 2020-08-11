var userAjax = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $("#ckStatus").on("change", function (e) {
            e.preventDefault();
            $(".passwordCheck").toggle();
        });
    }

    function loadData() {
       
        if (!$("#ckStatus").is(":checked")) {
            $(".passwordCheck").toggle();
        }
    }
}