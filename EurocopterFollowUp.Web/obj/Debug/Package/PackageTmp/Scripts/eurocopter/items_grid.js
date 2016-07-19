$(document).ready(function () {
    SetGridWidth();
    LoadState();

    var window = $("#window");
     window.data("kendoWindow").close();
});



function SaveState() {
    var grid = $("#grid").data("kendoGrid");

    var dataSource = grid.dataSource;
    var pageName = $('#pageName');

    var state = {
        columns: grid.columns,
        page: dataSource.page(),
        pageSize: dataSource.pageSize(),
        sort: dataSource.sort(),
        filter: dataSource.filter(),
     //   scrollable: grid.scrollable
        //     group: dataSource.group()
    };

    $.ajax({
        url: "/Items/SaveSettings",
        type: "POST",
        data: {
            data: JSON.stringify(state),
            pageName: JSON.stringify(pageName.val())
        }
    });
}

function LoadState() {
    var grid = $("#grid").data("kendoGrid");
    var pageName = $('#pageName');
    var dataSource = grid.dataSource;

    $.ajax({
        //url: "/Home/Load",
        url: "/Items/LoadSettings",
        type: "POST",
        data: {
            pageName: JSON.stringify(pageName.val())
        },
        success: function (state) {

            if (state != "") {
                state = JSON.parse(state);
                var options = grid.options;

                options.columns = state.columns;

                options.dataSource.page = state.page;
                options.dataSource.pageSize = state.pageSize;
                options.dataSource.sort = state.sort;
                options.dataSource.filter = state.filter;
             //   options.scrollable = state.scrollable;
                //    options.dataSource.group = state.group;

                grid.destroy();

                $("#grid")
                    .empty()
                    .kendoGrid(options);

                $('#grid').data("kendoGrid").dataSource.query({
                    page: state.page,
                    pageSize: state.pageSize,
                    sort: state.sort,
                    filter: state.filter
                //    scrollable: state.scrollable
                });
            } else {
                $('#grid').data("kendoGrid").dataSource.query({
                    page: 1,
                    pageSize: 10
                 
                });
            }
        }
    });
}

function SetGridWidth() {
    var grid = $("#grid").data("kendoGrid");
    var totalWidth = 0;
    for (var i = 0; i < grid.columns.length; i++) {
        var width = grid.columns[i].width;
        totalWidth = totalWidth + width;
    }
    grid.element.css('width', totalWidth + 'px');
}

$(".k-grid").on("click", function () {
    var grid = $("#grid").data("kendoGrid");
    var selectedData = grid.dataItem(grid.select());
    var isRegularUser = $('#IsRegularUser').val();
    var pageName = $('#pageName').val();
    if (selectedData) {
        if (!(pageName=='AllItems') || !(isRegularUser == 'True' || isRegularUser == 'true'))
           {
            var selectedId = selectedData.Id;
            var href = '/Items/EditItem?Id=' + selectedId+'&pageName='+pageName;
            window.location = href;
        }
    
    }
});


function ExcelExport() {
    var pageName = $('#pageName');
    window.location = "/Items/ExcelExport?pageName=" + pageName.val();

}

function ExcelImport() {
    var window = $("#window");
    window.data("kendoWindow").center().open();
}