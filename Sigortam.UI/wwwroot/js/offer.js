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

        }
    });


}