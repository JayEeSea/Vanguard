// Populate Faction dropdown based on selected Universe
(function () {
    const universeDropdown = document.getElementById("UniverseId");

    if (!universeDropdown) return;

    // Prevent double binding
    if (universeDropdown.dataset.listenerAttached === "true") return;

    universeDropdown.addEventListener("change", function () {
        const universeId = this.value;

        if (!universeId) return;

        fetch(`/admin/factions/getuniverses/${universeId}`)
            .then(response => response.json())
            .then(data => {
                data.forEach(universe => {
                    const option = document.createElement("option");
                    option.value = universe.id;
                    option.text = universe.name;
                    universeDropdown.appendChild(option);
                });
            })
            .catch(error => {
                console.error('Error loading universe:', error);
            });
    });

    universeDropdown.dataset.listenerAttached = "true";
})();