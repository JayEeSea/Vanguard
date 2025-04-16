$(function () {
    // Load Edit Modal
    $('[data-bs-toggle="modal"][data-bs-target="#editSpeciesModal"]').on('click', function () {
        const speciesId = $(this).data('id');

        $('#editSpeciesModalPlaceholder').load(`/admin/species/editspecies/${speciesId}`, function () {
            const modalEl = document.getElementById('editSpeciesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Load Create Modal
    $('[data-bs-toggle="modal"][data-bs-target="#createSpeciesModal"]').on('click', function () {
        $('#createSpeciesModalPlaceholder').load('/admin/species/createspecies', function () {
            const modalEl = document.getElementById('createSpeciesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Clean up Edit Modal
    const editModalEl = document.getElementById('editSpeciesModal');
    editModalEl.addEventListener('hidden.bs.modal', function () {
        $('#editSpeciesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // Clean up Create Modal
    const createModalEl = document.getElementById('createSpeciesModal');
    createModalEl.addEventListener('hidden.bs.modal', function () {
        $('#createSpeciesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

// AJAX Submit: Create Species
$(document).on('submit', '#createSpeciesForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Create form submission succeeded.");
            const modalEl = document.getElementById('createSpeciesModal');
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
            $('#createSpeciesModalPlaceholder').html(xhr.responseText);
        }
    });
});

// AJAX Submit: Edit Species
$(document).on('submit', '#editSpeciesForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Edit form submission succeeded.");
            const modalEl = document.getElementById('editSpeciesModal');
            const modal = bootstrap.Modal.getInstance(modalEl);
            if (modal) {
                modal.hide();
                console.log("✅ Edit modal closed.");
            }
            location.reload(); // refresh to show updated data
        },
        error: function (xhr) {
            console.error("❌ Edit form submission failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
            $('#editSpeciesModalPlaceholder').html(xhr.responseText); // re-render modal with validation errors
        }
    });
});

// Load Disable Modal
$('[data-bs-toggle="modal"][data-bs-target="#disableSpeciesModal"]').on('click', function () {
    const speciesId = $(this).data('id');

    $('#disableSpeciesModalPlaceholder').load(`/admin/species/disablespecies/${speciesId}`, function () {
        const modalEl = document.getElementById('disableSpeciesModal');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
    });
});

// Cleanup Disable Modal
const disableSpeciesModalEl = document.getElementById('disableSpeciesModal');
disableSpeciesModalEl.addEventListener('hidden.bs.modal', function () {
    $('#disableSpeciesModalPlaceholder').html('');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
});

// AJAX Submit: Soft Disable Species
$(document).on('submit', '.disable-species-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("🗑️ Species disabled.");
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
$(document).on('submit', '.reenable-species-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Species reenabled.");
            location.reload();
        },
        error: function (xhr) {
            console.error("❌ Reenable failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
        }
    });
});