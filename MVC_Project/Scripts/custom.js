$(function () {
    $("#tblDepartmanlar").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    } );
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı Silme İstediğinize Emin Misiniz?",function (result) {
                if (result) {
                    var id = btn.data("id");
                    $.ajax({
                        type: "GET",
                        url: "/Departman/Sil/" + id,
                        success: function () {
                            btn.parent().parent().remove();
                        }
                    });
                }
            })
    })
});

function CheckDateTypeIsValid(dataElement) {
    var value = $(dataElement).val();
    if (value == '') {
        $(dataElement).valid("false")
    }
    else {
        $(dataElement).valid("true");
    }
}