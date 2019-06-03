/* Leave Group */
$(function () {
    $("#myTable").on("click", ".leaveGroup", function () {
        var btn = $(this);
        bootbox.confirm("Gruptan ayrılmak istediğinize emin misiniz?", function (result) {
            if (result ==1) {
                var id = btn.data("id");             
                $.ajax({
                    type: "POST",
                    url: "/Groups/Leave/" + id,
                    success: function () {                       
                        btn.parent().parent().remove();
                    },                  
                });
            }
            else if(result==-1){
                bootbox.alert("İşlem sırasında bir hata oluştu.");
            }          
        })
    });
});

//RemoveMsg
$(function () {
    $("#myMsgTable").on("click", ".deleteMsg", function () {
        var btn = $(this);
        bootbox.confirm("Gruptan ayrılmak istediğinize emin misiniz?", function (result) {
            if (result == 1) {
                var id = btn.data("id");
                $.ajax({
                    type: "POST",
                    url: "/TextMessage/Remove/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    },
                });
            }
            else if (result == -1) {
                bootbox.alert("İşlem sırasında bir hata oluştu.");
            }
            else if (result == -2) {
                bootbox.alert("Bu mesajı sadece yönetici silebilir.");
            }
        })
    });
});

