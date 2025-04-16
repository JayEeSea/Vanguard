$(function () {
    // Load Edit Modal
    $('[data-bs-toggle="modal"][data-bs-target="#editFactionsModal"]').on('click', function () {
        const factionId = $(this).data('id');

        $('#editFactionsModalPlaceholder').load(`/admin/factions/editfactions/${factionId}`, function () {
            const modalEl = document.getElementById('editFactionsModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Load Create Modal
    $('[data-bs-toggle="modal"][data-bs-target="#createFactionsModal"]').on('click', function () {
        $('#createFactionsModalPlaceholder').load('/admin/factions/createfactions', function () {
            const modalEl = document.getElementById('createFactionsModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // Clean up Edit Modal
    const editModalEl = document.getElementById('editFactionsModal');
    editModalEl.addEventListener('hidden.bs.modal', function () {
        $('#editFactionsModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // Clean up Create Modal
    const createModalEl = document.getElementById('createFactionsModal');
    createModalEl.addEventListener('hidden.bs.modal', function () {
        $('#createFactionsModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

// AJAX Submit: Create Factions
$(document).on('submit', '#createFactionsForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Create form submission succeeded.");
            const modalEl = document.getElementById('createFactionsModal');
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
            $('#createFactionsModalPlaceholder').html(xhr.responseText);
        }
    });
});

// AJAX Submit: Edit Factions
$(document).on('submit', '#editFactionsForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Edit form submission succeeded.");
            const modalEl = document.getElementById('editFactionsModal');
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
            $('#editFactionsModalPlaceholder').html(xhr.responseText); // re-render modal with validation errors
        }
    });
});

// Load Disable Modal
$('[data-bs-toggle="modal"][data-bs-target="#disableFactionsModal"]').on('click', function () {
    const factionId = $(this).data('id');

    $('#disableFactionsModalPlaceholder').load(`/admin/factions/disablefactions/${factionId}`, function () {
        const modalEl = document.getElementById('disableFactionsModal');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
    });
});

// Cleanup Disable Modal
const disableFactionsModalEl = document.getElementById('disableFactionsModal');
disableFactionsModalEl.addEventListener('hidden.bs.modal', function () {
    $('#disableFactionsModalPlaceholder').html('');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
});

// AJAX Submit: Soft Disable Factions
$(document).on('submit', '.disable-factions-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("🗑️ Faction disabled.");
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
$(document).on('submit', '.reenable-factions-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Faction reenabled.");
            location.reload();
        },
        error: function (xhr) {
            console.error("❌ Reenable failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
        }
    });
});