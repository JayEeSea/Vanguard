function initFactionDropdownHandler() {
    const universeSelect = document.getElementById("UniverseId");
    const factionSelect = document.getElementById("FactionId");

    if (!universeSelect || !factionSelect) {
        console.warn("🔍 Could not find UniverseId or FactionId in the DOM.");
        return;
    }

    universeSelect.addEventListener("change", () => {
        const universeId = universeSelect.value;

        factionSelect.innerHTML = '<option value="">-- Select Faction --</option>';

        if (!universeId) return;

        fetch(`/Admin/Ranks/getfactions/${universeId}`)
            .then(res => {
                if (!res.ok) throw new Error(`HTTP ${res.status}`);
                return res.json();
            })
            .then(data => {
                const currentFactionId = factionSelect.getAttribute("data-current-id");

                data.forEach(f => {
                    const opt = document.createElement("option");
                    opt.value = f.id;
                    opt.text = f.name;
                    if (f.id.toString() === currentFactionId) {
                        opt.selected = true;
                    }
                    factionSelect.appendChild(opt);
                });
            })
            .catch(err => console.error("❌ Error loading factions:", err));
    });

    console.log("✅ Faction dropdown handler initialised.");
}