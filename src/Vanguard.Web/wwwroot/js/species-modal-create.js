// Populate Faction dropdown based on selected Universe
(function () {
    const universeDropdown = document.getElementById("UniverseId");
    const factionDropdown = document.getElementById("FactionId");

    if (!universeDropdown || !factionDropdown) return;

    // Prevent double binding
    if (universeDropdown.dataset.listenerAttached === "true") return;

    universeDropdown.addEventListener("change", function () {
        const universeId = this.value;
        factionDropdown.innerHTML = '<option value="">-- Select Faction --</option>';

        if (!universeId) return;

        fetch(`/admin/species/getfactions/${universeId}`)
            .then(response => response.json())
            .then(data => {
                data.forEach(faction => {
                    const option = document.createElement("option");
                    option.value = faction.id;
                    option.text = faction.name;
                    factionDropdown.appendChild(option);
                });
            })
            .catch(error => {
                console.error('Error loading factions:', error);
            });
    });

    universeDropdown.dataset.listenerAttached = "true";
})();