$(function () {
    // Load Edit Modal
    $('[data-bs-toggle="modal"][data-bs-target="#editBranchesModal"]').on('click', function () {
        const branchId = $(this).data('id');

        $('#editBranchesModalPlaceholder').load(`/admin/branches/editbranches/${branchId}`, function () {
            const modalEl = document.getElementById('editBranchesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();

            // Load and trigger the faction dropdown handler
            $.getScript('/js/branches-modal.js', function () {
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
    $('[data-bs-toggle="modal"][data-bs-target="#createBranchesModal"]').on('click', function () {
        $('#createBranchesModalPlaceholder').load('/admin/branches/createbranches', function () {
            const modalEl = document.getElementById('createBranchesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();

            // Load and trigger the faction dropdown handler
            $.getScript('/js/branches-modal.js', function () {
                initFactionDropdownHandler();
            });
        });
    });

    // Clean up Edit Modal
    const editModalEl = document.getElementById('editBranchesModal');
    editModalEl.addEventListener('hidden.bs.modal', function () {
        $('#editBranchesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // Clean up Create Modal
    const createModalEl = document.getElementById('createBranchesModal');
    createModalEl.addEventListener('hidden.bs.modal', function () {
        $('#createBranchesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

// AJAX Submit: Create Branches
$(document).on('submit', '#createBranchesForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Create form submission succeeded.");
            const modalEl = document.getElementById('createBranchesModal');
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
            $('#createBranchesModalPlaceholder').html(xhr.responseText);
        }
    });
});

// AJAX Submit: Edit Branches
$(document).on('submit', '#editBranchesForm', function (e) {
    e.preventDefault();
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        method: form.attr('method'),
        data: form.serialize(),
        success: function () {
            console.log("✅ Edit form submission succeeded.");
            const modalEl = document.getElementById('editBranchesModal');
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
            $('#editBranchesModalPlaceholder').html(xhr.responseText); // re-render modal with validation errors
        }
    });
});

// Load Disable Modal
$('[data-bs-toggle="modal"][data-bs-target="#disableBranchesModal"]').on('click', function () {
    const branchId = $(this).data('id');

    $('#disableBranchesModalPlaceholder').load(`/admin/branches/disablebranches/${branchId}`, function () {
        const modalEl = document.getElementById('disableBranchesModal');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
    });
});

// Cleanup Disable Modal
const disableBranchesModalEl = document.getElementById('disableBranchesModal');
disableBranchesModalEl.addEventListener('hidden.bs.modal', function () {
    $('#disableBranchesModalPlaceholder').html('');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
});

// AJAX Submit: Soft Disable Branches
$(document).on('submit', '.disable-branches-form', function (e) {
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
$(document).on('submit', '.reenable-branches-form', function (e) {
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