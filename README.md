# Vanguard

<h3 style="text-align:center;">United Across Galaxies</h3>
<h4 style="text-align:center;">A fan club management platform built with ASP.NET Core MVC</h4>

<p align="center">
  <img width="500" height="500" src="https://raw.githubusercontent.com/JayEeSea/Vanguard/refs/heads/main/src/Vanguard.Web/wwwroot/images/logo.jpg">
</p>

---

## 🚀 Overview

**Vanguard** is a modular fan club platform built to support communities across multiple science fiction universes, including **Star Wars** and **Star Trek**. Developed using ASP.NET Core MVC and MariaDB, it features user registration, character management, administrative tools, and comprehensive database integration.

Inspired by my time in fan organisations such as [Emperor's Hammer](https://emperorshammer.org/), [Dark Jedi Brotherhood](https://www.darkjedibrotherhood.com/), and [Bravo Fleet](https://bravofleet.com/), Vanguard reimagines what once required a dedicated webmaster to build from scratch — now achievable with some technical know-how and configuration.

This platform is ideal for clubs and fan communities seeking to manage characters, universes, factions, and events within a fully web-based environment.

---

## ✨ Features

- 🧑‍🚀 **Character Management System**  
  Full CRUD support for characters, species, ranks, genders, and more.

- 🪐 **Multi-Universe Support**  
  Built-in structure for universes, factions, branches, units, and sub-units.

- 🛠️ **Admin Interface**  
  Bootstrap-based modals for editing entities via AJAX for a seamless experience.

- 🛡️ **Role-Based Access Control**  
  Roles from `INACTIVEMEMBER` to `GLOBALADMIN` for permission-based visibility and control.

- 💬 **Localization Support**  
  Date/time formatting and future multi-language support.

- 📦 **Entity Framework with MariaDB**  
  Clean code-first setup using EF Core for maintainable and scalable data access.

---

## 🧱 Tech Stack

- **Backend:** ASP.NET Core MVC (.NET 8)
- **Frontend:** Bootstrap 5, JavaScript/jQuery (with plans for modernisation)
- **Database:** MariaDB via Entity Framework Core
- **Hosting:** Developed for Linux deployment with NGINX reverse proxy
- **Testing:** WSL for local testing, remote Ubuntu server for staging

---

## 🔧 Setup Instructions

### 1. Clone the repository
```bash
git clone https://github.com/JayEeSea/Vanguard.git
cd Vanguard
```

### 2. Configure the database and set global variables
Ensure MariaDB is running and update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=VanguardDb;user=youruser;password=yourpassword;"
},
"AppSettings": {
  "AppName": "Vanguard",
  "AppMotto": "United Across Galaxies"
},
```

### 3. Run migrations
```bash
dotnet ef database update
```

### 4. Run the application
```bash
dotnet run
```

---

## 🌐 Deployment Notes

- **Reverse Proxy:** NGINX configured to forward requests to Kestrel.
- **Environment:** Use `ASPNETCORE_ENVIRONMENT=Production` for deployment.
- **Docker:** Optional Docker setup available for local development (future enhancement).

---

## 📂 Project Structure

```plaintext
Vanguard/
├── Areas/
│   └── Admin/
│       ├── Controllers/
│       ├── Views/
│       └── Scripts/
├── Config/
├── Controllers/
├── Data/
│   └── AppDbContext.cs
├── Models/
├── Pages/
├── Services/
├── Views/
├── ViewComponents/
├── wwwroot/
└── Program.cs
```

---

## 🧑‍💻 Author

**Justin Cripps**  
Digital Coordinator & Developer  
[LinkedIn](https://www.linkedin.com/in/justin-c-17b722119/) | [GitHub](https://github.com/JayEeSea)

---

## 📜 Licence

This project is open-source under the [MIT License](LICENSE).

---

## 🌟 Acknowledgements

- Inspired by decades of fan club engagement in the Star Wars and Star Trek communities.
- Built with ❤️ in Queensland, Australia.

---

> _“That’s no moon… it’s a highly modular fan club platform.”_
