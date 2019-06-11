/* Remove user*/
$(function () {
    $("#myRemoveTable").on("click", ".removeGroup", function () {
        var btn = $(this);
        bootbox.confirm("Bu kişiyi gruptan çıkarmak istediğinize emin misiniz?", function (result) {
            if (result == 1) {
                var id = btn.data("id");
                $.ajax({
                    type: "POST",
                    url: "/Groups/RemoveUser/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    },
                });
            }
            else if (result == -1) {
                bootbox.alert("İşlem sırasında bir hata oluştu.");
            }
        })
    });
});