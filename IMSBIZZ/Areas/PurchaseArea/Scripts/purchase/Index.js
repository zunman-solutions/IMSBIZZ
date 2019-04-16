$(document).ready(function () {
    ko.applyBindings(modelView);  

    $('#UrlDetails').DataTable({
        pageLength: 25,
        responsive: true,
        processing: true,
        serverSide: false,
        orderMulti: false,
        filter: true,
        rowId: "Id",
        ajax: {
            "url": app.url.action("GetUrlDetails", { controller: "Home" }),
            "type": "Get",
            "datatype": "json"
        },
        "initComplete": function (settings, json) {
            $.unblockUI();
        },
        columnDefs: [{
            orderable: false,
            searchable: false,
            targets: 0,
        }],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        },
        columns: [
            { "data": "SequenceNo", "name": "SequenceNo", "autoWidth": true},
            { "data": "LongUrl", "name": "LongUrl", "autoWidth": true },
            { "data": "ShortUrl", "name": "ShortUrl", "autoWidth": true },
            { "data": "ExpiredOn", "name": "ExpiredOn", "autoWidth": true },
            { "data": "IsActive", "name": "IsActive", "autoWidth": true }, 
            { "data": "Description", "name": "Description", "autoWidth": true },           
            {
                "data": "Id", "autoWidth": true, "render": function (data, type, row, meta) {
                    return ('<a href="{0} " class="btn btn-info">تغير</a>').formatString(
                        app.url.action('Edit', { controller: "Home", params: { Id: data } }));
                }
            },
            {
                "data": "Id", "autoWidth": true, "render": function (data, type, row, meta) {
                    return ('<input type="button" value="Delete" class="btn btn-danger" name=' + data + ' id=' + data + ' onclick=Delete(' + data + ')>');
                }
            }    
                      
        ],
        dom: '<"html5buttons"B>lTfgitp',
        buttons: [
            { extend: 'copy' },
            { extend: 'csv' },
            { extend: 'excel', title: 'Excel' },
            { extend: 'pdf', title: 'Pdf' },
            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }
            }
        ]
    });
});  
var modelView = {  
    programs: ko.observableArray([]),  
    viewPrograms: function () {  
        $.blockUI({ message: '<h1>ارجوك انتظر...</h1>' });
        var thisObj = this;  
        try {  
            $.ajax({  
                url: app.url.action("ProgramList", { controller: "Program" }),  
                type: 'GET',  
                dataType: 'json',  
                contentType: 'application/json',  
                success: function (data) {  
                    thisObj.programs(data); 
                },  
                error: function (err) {  
                    $.unblockUI();
                    swal(err.status + " : " + err.statusText);  
                }  
            }).always(function () {
                $.unblockUI();
            });  
        } catch (e) {  
            $.unblockUI();
            window.location.href = app.url.action("Index", { controller: "Program" });  
        }  
    }
}; 