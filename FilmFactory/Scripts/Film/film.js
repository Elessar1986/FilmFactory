
$(".detailsModalBtn").click(function () {
    var row = $(this).closest('tr').find('input#item_Id').val();
    //console.log(row);
    $.get(_urlGetFilmById,
        { id: parseInt(row) },
        function (data) {
            //console.log(data);
            $('#modalPlace').html(data);
            $('#detailsModal').modal('show');
        },
        "html");

});

//$(".addModalBtn").click(function () {

//    console.log("ADD");
//    $.get(_urlAddFilm,
//        function (data) {
//            //console.log(data);
//            $('#modalPlace').html(data);
//            $('#addModal').modal('show');
//        },
//        "html");

//});

$(".addFilm").click(function () {

})


