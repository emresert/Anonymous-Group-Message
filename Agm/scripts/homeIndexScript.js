/* Leave Group */

$(document).on("click", ".leaveGroup", function () {
    var confirmDelete = confirm("Gruptan ayrılmak istediğinize emin misiniz?");
    if (confirmDelete) {
        var id = $(this).attr("data-id");
        alert(id);
    }
});

/*
$(function () {
    $("#myTable").on("click", ".leaveGroup", function () {
        var btn = $(this);
        bootbox.confirm("Gruptan ayrılmak istediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Groups/Leave/" + id,
                    success: function () {
                        bootbox.alert("Grup silindi");
                        btn.parent().parent().remove();

                    }, 
                    error: function () {
                        bootbox.alert("");
                    }*
                });
            }

        })
    });
});*/