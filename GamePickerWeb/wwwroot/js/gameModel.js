$(document).ready(function () {
    loadDataTable();
} );

function loadDataTable() {
    dataTable = $('#tableData').DataTable({
        "ajax": { url:'/admin/gamemodel/getall'},
        "columns": [
            { data: 'title', "width": "35%" },
            { data: 'regularPrice', "width": "5%" },
            { data: 'publisher', "width": "20%" },
            { data: 'category.name', "width": "10%" },
            { 
                data: 'id', 
                "render": function(data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/gamemodel/upsert?id=${data}" class="btn btn-outline-primary btn-sm">
                        <i class="bi bi-pencil"></i> Edit
                    </a>
                    <a class="btn btn-outline-danger btn-sm">
                        <i class="bi bi-trash3"></i> Delete
                    </a>
                    </div>`
                },
                "width": "30%"
            }
        ]
    });
}           
