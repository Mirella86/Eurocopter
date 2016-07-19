$(".k-grid").on("click", function () {
    var grid = $("#grid").data("kendoGrid");
    var selectedData = grid.dataItem(grid.select());
    var selectedId = selectedData.UserId;
    var href = '/Administration/EditUser?UserId=' + selectedId;
    window.location = href;

});