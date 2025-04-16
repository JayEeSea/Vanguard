$(function () {
    // Load Edit Modal
    $('[data-bs-toggle="modal"][data-bs-target="#editModal"]').on('click', function () {
        const genderId = $(this).data('id');

        $('#editGenderModalPlaceholder').load(`/admin/genders/editgender/${genderId}`, function () {
            const modalEl = document.getElementById('editModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Load Create Modal
    $('[data-bs-toggle="modal"][data-bs-target="#createModal"]').on('click', function () {
        $('#createGenderModalPlaceholder').load('/admin/genders/creategender', function () {
            const modalEl = document.getElementById('createModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Clean up Edit Modal
    const editModalEl = document.getElementById('editModal');
    editModalEl.addEventListener('hidden.bs.modal', function () {
        $('#editGenderModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // Clean up Create Modal
    const createModalEl = document.getElementById('createModal');
    createModalEl.addEventListener('hidden.bs.modal', function () {
        $('#createGenderModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

// AJAX Submit: Edit Gender
$(document).on('submit', '#editGenderForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Edit form submission succeeded.");
            const modalEl = document.getElementById('editModal');
            const modal = bootstrap.Modal.getInstance(modalEl);
            if (modal) {
                modal.hide();
                console.log("✅ Edit modal closed.");
            }
            location.reload(); // reload to show updated values
        },
        error: function (xhr) {
            console.error("❌ Edit form submission failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
            $('#editGenderModalPlaceholder').html(xhr.responseText);
        }
    });
});

// AJAX Submit: Create Gender
$(document).on('submit', '#createGenderForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Create form submission succeeded.");
            const modalEl = document.getElementById('createModal');
            const modal = bootstrap.Modal.getInstance(modalEl);
            if (modal) {
                modal.hide();
                console.log("✅ Create modal closed.");
            }
            location.reload(); // reload to show the new entry
        },
        error: function (xhr) {
            console.error("❌ Create form submission failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
            $('#createGenderModalPlaceholder').html(xhr.responseText);
        }
    });
});

// Load Disable Modal
$('[data-bs-toggle="modal"][data-bs-target="#disableModal"]').on('click', function () {
    const genderId = $(this).data('id');

    $('#disableGenderModalPlaceholder').load(`/admin/genders/disablegender/${genderId}`, function () {
        const modalEl = document.getElementById('disableModal');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
    });
});

// Cleanup Disable Modal
const disableModalEl = document.getElementById('disableModal');
disableModalEl.addEventListener('hidden.bs.modal', function () {
    $('#disableGenderModalPlaceholder').html('');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
});

// AJAX Submit: Soft Disable Gender
$(document).on('submit', '.disable-gender-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("🗑️ Gender disabled.");
            location.reload(); // refresh to hide the disabled row
        },
        error: function (xhr) {
            console.error("❌ Disable failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
        }
    });
});

// AJAX Handler for Reenable
$(document).on('submit', '.reenable-gender-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Gender reenabled.");
            location.reload();
        },
        error: function (xhr) {
            console.error("❌ Reenable failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
        }
    });

    return false;
});