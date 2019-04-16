

$(document).ready(function () {

    $('#tblBatch').DataTable({
        pageLength: 25,
        responsive: true,
        processing: true,
        serverSide: false,
        orderMulti: false,
        filter: true,
        rowId: "Id",
        ajax: {
            "url": app.url.api("GetAllBatches", "api/Batch", { controller: "BatchAPI" }),
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
            { "data": "BatchName", "name": "BatchName", "autoWidth": true },         
            { "data": "IsActive", "name": "IsActive", "autoWidth": true }, 
            {
                "data": "Id", "autoWidth": true, "render": function (data, type, row, meta) {
                    return ('<a href="{0} " class="btn btn-info">Edit</a>').formatString(
                        app.url.api('Edit', { controller: "Batch", area:"MasterArea", params: { Id: data } }));
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
