
function CallHandler() {
    alert('I am called');
    $.ajax({
        url: "../Handler/MyHandler.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { 'Id': '10000' },
        responseType: "json",
        success: OnComplete,
        error: OnFail
    });
    return false;
}

function OnComplete(result) {
    alert('I am called successfully');
    $('#CustomerDetails').html(result.AlertTypeID);
    // alert([result.Id, result.Name, result.Age, result.Department]);
}
function OnFail(result) {
    alert('Ajax failed');

}