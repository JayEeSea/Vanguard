$(function () {
    // Load Edit Modal
    $('[data-bs-toggle="modal"][data-bs-target="#editRanksModal"]').on('click', function () {
        const branchId = $(this).data('id');

        $('#editRanksModalPlaceholder').load(`/admin/ranks/editranks/${branchId}`, function () {
            const modalEl = document.getElementById('editRanksModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();

            // Load and trigger the faction dropdown handler
            $.getScript('/js/ranks-modal.js', function () {
                initFactionDropdownHandler();

                // Trigger a Universe change event to load the factions based on current UniverseId
                const universeSelect = document.getElementById("UniverseId");
                if (universeSelect) {
                    universeSelect.dispatchEvent(new Event("change"));
                }
            });
        });
    });

    // Load Create Modal
    $('[data-bs-toggle="modal"][data-bs-target="#createRanksModal"]').on('click', function () {
        $('#createRanksModalPlaceholder').load('/admin/ranks/createranks', function () {
            const modalEl = document.getElementById('createRanksModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();

            // Load and trigger the faction dropdown handler
            $.getScript('/js/ranks-modal.js', function () {
                initFactionDropdownHandler();
            });
        });
    });

    // Clean up Edit Modal
    const editModalEl = document.getElementById('editRanksModal');
    editModalEl.addEventListener('hidden.bs.modal', function () {
        $('#editRanksModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // Clean up Create Modal
    const createModalEl = document.getElementById('createRanksModal');
    createModalEl.addEventListener('hidden.bs.modal', function () {
        $('#createRanksModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

// AJAX Submit: Create Ranks
$(document).on('submit', '#createRanksForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Create form submission succeeded.");
            const modalEl = document.getElementById('createRanksModal');
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
            $('#createRanksModalPlaceholder').html(xhr.responseText);
        }
    });
});

// AJAX Submit: Edit Ranks
$(document).on('submit', '#editRanksForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Edit form submission succeeded.");
            const modalEl = document.getElementById('editRanksModal');
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
            $('#editRanksModalPlaceholder').html(xhr.responseText); // re-render modal with validation errors
        }
    });
});

// Load Disable Modal
$('[data-bs-toggle="modal"][data-bs-target="#disableRanksModal"]').on('click', function () {
    const branchId = $(this).data('id');

    $('#disableRanksModalPlaceholder').load(`/admin/ranks/disableranks/${branchId}`, function () {
        const modalEl = document.getElementById('disableRanksModal');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
    });
});

// Cleanup Disable Modal
const disableRanksModalEl = document.getElementById('disableRanksModal');
disableRanksModalEl.addEventListener('hidden.bs.modal', function () {
    $('#disableRanksModalPlaceholder').html('');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
});

// AJAX Submit: Soft Disable Ranks
$(document).on('submit', '.disable-ranks-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("🗑️ Branch disabled.");
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
$(document).on('submit', '.reenable-ranks-form', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Branch reenabled.");
            location.reload();
        },
        error: function (xhr) {
            console.error("❌ Reenable failed:");
            console.error(xhr.status, xhr.statusText);
            console.error(xhr.responseText);
        }
    });
});