
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






