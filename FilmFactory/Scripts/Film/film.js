
$(".detailsModalBtn").click(function () {
    var row = $(this).closest('tr').find('input#item_Id').val();
    $.get(_urlGetFilmById,
        { id: parseInt(row) },
        function (data) {
            $('#modalPlace').html(data);
            $('#detailsModal').modal('show');
        },
        "html");

});


$("#Rate").focusout(function () {
    console.log("test");
    var temp = $("#Rate").val().toString().replace(',','.');
    $("#Rate").val(temp);
})


