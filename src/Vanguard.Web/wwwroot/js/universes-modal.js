$(function () {
    // Disabling fields unless UsesBBYABY is ticked.
    function toggleBBYFields() {
        const checked = $('#UsesBBYABY').is(':checked');
        $('#BBYABYAnchorDate').prop('disabled', !checked);
    }

    $('#UsesBBYABY').on('change', toggleBBYFields);
    toggleBBYFields(); // Initial state


    function toggleStardateFields() {
        const checked = $('#EnableStardate').is(':checked');
        $('#UsesOffset, #OffsetYears, #StardateBaseDate, #StardateMultiplier').prop('disabled', !checked);
    }

    $('#EnableStardate').on('change', toggleStardateFields);
    toggleStardateFields(); // Initial state
});