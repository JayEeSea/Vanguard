$(function () {
    // === Edit Modal ===
    $(function () {
        // === Edit Modal ===
        $('[data-bs-toggle="modal"][data-bs-target="#editUniversesModal"]').on('click', function () {
            const universesId = $(this).data('id');

            $('#editUniversesModalPlaceholder').load(`/admin/universes/edituniverses/${universesId}`, function () {
                const modalEl = document.getElementById('editUniversesModal');
                const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
                modal.show();
            });
        });

    // === Create Modal ===
    $('[data-bs-toggle="modal"][data-bs-target="#createUniversesModal"]').on('click', function () {
        $('#createUniversesModalPlaceholder').load('/admin/universes/createuniverses', function () {
            const modalEl = document.getElementById('createUniversesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // === Disable Modal ===
    $('[data-bs-toggle="modal"][data-bs-target="#disableUniversesModal"]').on('click', function () {
        const universesId = $(this).data('id');

        $('#disableUniversesModalPlaceholder').load(`/admin/universes/disableuniverses/${universesId}`, function () {
            const modalEl = document.getElementById('disableUniversesModal');
            const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
        });
    });

    // === Cleanup on Hide ===
    const editModalEl = document.getElementById('editUniversesModal');
    editModalEl?.addEventListener('hidden.bs.modal', function () {
        $('#editUniversesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    const createModalEl = document.getElementById('createUniversesModal');
    createModalEl?.addEventListener('hidden.bs.modal', function () {
        $('#createUniversesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    const disableModalEl = document.getElementById('disableUniversesModal');
    disableModalEl?.addEventListener('hidden.bs.modal', function () {
        $('#disableUniversesModalPlaceholder').html('');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });

    // === AJAX Submit: Disable ===
    $(document).on('submit', '.disable-universes-form', function (e) {
        e.preventDefault();
        const form = $(this);

        $.ajax({
            url: form.attr('action'),
            method: form.attr('method'),
            data: form.serialize(),
            success: function () {
                console.log("🗑️ Universe disabled.");
                location.reload();
            },
            error: function (xhr) {
                console.error("❌ Disable failed:", xhr.status, xhr.statusText, xhr.responseText);
            }
        });
    });

    // === AJAX Submit: Reenable ===
    $(document).on('submit', '.reenable-universes-form', function (e) {
        e.preventDefault();
        const form = $(this);

        $.ajax({
            url: form.attr('action'),
            method: form.attr('method'),
            data: form.serialize(),
            success: function () {
                console.log("✅ Universe reenabled.");
                location.reload();
            },
            error: function (xhr) {
                console.error("❌ Reenable failed:", xhr.status, xhr.statusText, xhr.responseText);
            }
        });
    });

    // AJAX Submit: Create Universes
    $(document).on('submit', '#createUniversesForm', function (e) {
        e.preventDefault();
        const form = $(this);

        $.ajax({
            url: form.attr('action'),
            method: form.attr('method'),
            data: form.serialize(),
            success: function () {
                console.log("✅ Create form submission succeeded.");
                const modalEl = document.getElementById('createUniversesModal');
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
                $('#createUniversesModalPlaceholder').html(xhr.responseText);
            }
        });
    });

    // AJAX Submit: Edit Universe
        $(document).on('submit', '#editUniversesForm', function (e) {
            e.preventDefault();
            const form = $(this);

            $.ajax({
                url: form.attr('action'),
                method: form.attr('method'),
                data: form.serialize(),
                success: function () {
                    console.log("✅ Edit form submission succeeded.");
                    const modalEl = document.getElementById('editUniversesModal');
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
                    $('#editUniversesModalPlaceholder').html(xhr.responseText); // re-render modal with validation errors
                }
            });
        });
    });
});