$(document).ready(function () {
    $("#IdTckn").change(function () {
        if ($(this).val().length > 5 && $("#IdTckn").val().length === 11) {
            getUserInfo();
        }
    });

    $("#IdPlaka").change(function () {
        if ($(this).val().length > 5 && $("#IdTckn").val().length === 11) {
            getUserInfo();
        }
    });
});

function getUserInfo() {
    var postModel = {
        StPlaka: $("#IdTckn").val(),
        StTCKN: $("#IdPlaka").val()
    }
    $.ajax({
        type: "POST",
        url: $("#get-user-info").data("request-url"),
        data: { requestModel: postModel },
        success: function (result) {
            if (result.success) {
                $("#IdRuhsatSeriKodu").val(result.data.stRuhsatSeriKodu);
                $("#IdRuhsatSeriNo").val(result.data.stRuhsatSeriKodu);
            } else {
                alert(result.message);
            }
        }
    });
}


function getOffer() {
    var postModel = {
        StPlaka: $("#IdTckn").val(),
        StTCKN: $("#IdPlaka").val(),
        StRuhsatSeriKodu: $("#IdRuhsatSeriKodu").val(),
        StRuhsatSeriNo: $("#IdRuhsatSeriKodu").val()
    }

    $.ajax({
        type: "POST",
        url: $("#get-offer").data("request-url"),
        data: { requestModel: postModel },
        success: function (result) {
            if (result.success) {
                alert(result.message);
            } else {
                alert(result.message);
            }
        }
    });


}