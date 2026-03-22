const fetchBtn = document.getElementById("fetchBtn");
const message = document.getElementById("message");
const table = document.getElementById("playersTable");
const tbody = table.querySelector("tbody");

const API_URL = "http://localhost:5062/api/players";

fetchBtn.addEventListener("click", async () => {
  message.textContent = "Loading...";
  tbody.innerHTML = "";
  table.style.display = "none";

  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Failed to fetch data");
    }

    const players = await response.json();

    message.textContent = `Fetched ${players.length} players`;

    players.slice(0, 20).forEach((player) => {
      const row = document.createElement("tr");

      row.innerHTML = `
        <td>${player.name ?? ""}</td>
        <td>${player.team ?? ""}</td>
        <td>${player.points ?? 0}</td>
      `;

      tbody.appendChild(row);
    });

    table.style.display = "table";
  } catch (error) {
    message.textContent = `Error: ${error.message}`;
  }
});