const fetchBtn = document.getElementById("fetchBtn");
const message = document.getElementById("message");
const table = document.getElementById("playersTable");
const tbody = table.querySelector("tbody");

const fetchDataBtn = document.getElementById("fetchDataBtn")
const fetchJaneBtn = document.getElementById("fetchJaneBtn")
const fetchIdBtn = document.getElementById("fetchIdBtn")

const usertable = document.getElementById("UserTable");
const user_tbody = usertable.querySelector("tbody");

const janetable = document.getElementById("JaneTable");
const jane_tbody = janetable.querySelector("tbody");

const idtable = document.getElementById("IdTable");
const id_tbody = idtable.querySelector("tbody");


const API_URL = "http://localhost:5062/api/players";
const API_URL_2 = "http://localhost:5062/api/users";

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


fetchDataBtn.addEventListener("click", async () => {
  user_tbody.innerHTML = "";
  usertable.style.display = "none";

  try {
    const response = await fetch(API_URL_2);

    if (!response.ok) {
      throw new Error("Failed to fetch data");
    }

    const users = await response.json();

    message.textContent = `Fetched ${users.length} users`;

    users.forEach((user) => {
      const row = document.createElement("tr");

      row.innerHTML = `
        <td>${user.id ?? ""}</td>
        <td>${user.name ?? ""}</td>
        <td>${user.firstname ?? ""}</td>
        <td>${user.lastname ?? ""}</td>
      `;

      user_tbody.appendChild(row);
    });

    usertable.style.display = "table";
  } catch (error) {
    
  }
});

fetchJaneBtn.addEventListener("click", async () => {
  jane_tbody.innerHTML = "";
  janetable.style.display = "none";

  try {
    const response = await fetch(`${API_URL_2}?firstName=Jane&lastName=Doe`);
    const users = await response.json();

    users.forEach((user) => {
      const row = document.createElement("tr");

      row.innerHTML = `
        <td>${user.id}</td>
        <td>${user.name}</td>
        <td>${user.firstName}</td>
        <td>${user.lastName}</td>
      `;

      jane_tbody.appendChild(row);
    });

    janetable.style.display = "table";
  } catch (error) {}
});

fetchIdBtn.addEventListener("click", async () => {
  id_tbody.innerHTML = "";
  idtable.style.display = "none";

  try {
    const response = await fetch(`${API_URL_2}/5`);
    
    if (!response.ok) {
      throw new Error("User not found");
    }

    const user = await response.json();

    const row = document.createElement("tr");

    row.innerHTML = `
      <td>${user.id}</td>
      <td>${user.name}</td>
      <td>${user.firstName}</td>
      <td>${user.lastName}</td>
    `;

    id_tbody.appendChild(row);

    idtable.style.display = "table";
  } catch (error) {}
});