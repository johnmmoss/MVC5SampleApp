$(document).ready(function () {

    $('#RoleName').focus();
    $('[data-toggle="tooltip"]').tooltip();
    $('.role-del').click(function () {

        var roleId = $(this).attr('id');
        var roleName = $('#' + roleId + '-name').text();

        showModal(roleId, roleName);
    });
});

function showModal(id, roleName) {

    $('#modal-name').text(' ' + roleName);
    $('#myModal').modal('show');
    $('#roleId').val(id);
}