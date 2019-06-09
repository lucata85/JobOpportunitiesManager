$(function () {
    $(".panel button").on("click", function () {
        $("#job").val($(this).data("job"));
    });

    $("#modalSuccess").modal();

    //$("#btnRegister").on("click", function ({
    //    $()
    //});
});