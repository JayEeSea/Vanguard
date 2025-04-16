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

    // Auto-populate factions if a universe is already selected
    const initialUniverseId = universeDropdown.value;
    const initialFactionId = factionDropdown.getAttribute("data-selected-id");

    if (initialUniverseId && initialFactionId) {
        fetch(`/admin/species/getfactions/${initialUniverseId}`)
            .then(response => response.json())
            .then(data => {
                data.forEach(faction => {
                    const option = document.createElement("option");
                    option.value = faction.id;
                    option.text = faction.name;
                    if (faction.id == initialFactionId) {
                        option.selected = true;
                    }
                    factionDropdown.appendChild(option);
                });
            })
            .catch(error => {
                console.error('Error loading initial faction list:', error);
            });
    }
})();