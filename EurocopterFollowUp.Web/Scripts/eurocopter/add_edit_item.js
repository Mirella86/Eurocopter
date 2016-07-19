$(document).ready(function () {
    var pageName = $('#pageName').val();

    if (pageName === 'EditItem') {
        var window = $("#window");
        window.data("kendoWindow").close();
    }
});


function BackToPage() {
    var pageName = $('#pageName').val();
    window.location.href = '/Items/' + pageName;

}

function DeleteItem() {
    var window = $("#window");
    window.data("kendoWindow").center().open();
}

function DeleteItemConfirmed() {
    var itemId = $('#Id').val();

    $.ajax({
        url: "/Items/DeleteItem",
        type: "POST",
        data: {
            itemId: JSON.stringify(itemId)
        },
        success: function () {
            var pageName = $('#pageName').val();
            window.location.href = '/Items/' + pageName;
        },
        error: function () {
            window.location.href = '/Administration/Exception';
        }
    });


}

function ClosePopup() {
    var window = $("#window");
    window.data("kendoWindow").close();
}