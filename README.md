![Drumschule Harsch](http://drumschule-harsch.de/wp-content/uploads/2022/01/drumschule-harsch_logo-1.jpg)

# DSH – Musikschule Verwaltungssystem

DSH ist eine Webanwendung zur Verwaltung einer Musikschule. Das Backend ist eine ASP.NET Core Web API (.NET 10), das Frontend wird als Angular-Applikation umgesetzt. Die Datenhaltung erfolgt über eine relationale Datenbank (Entity Framework Core).

## Tech Stack

| Schicht   | Technologie              |
|-----------|--------------------------|
| Backend   | ASP.NET Core (.NET 10)   |
| Frontend  | Angular                  |
| Datenbank | PostgreSQL / EF Core     |
| Container | Docker / Docker Compose  |

---

## Features

### Backend – API

- [ ] **Instrument** – Verwaltung von Musikinstrumenten (CRUD)
- [ ] **Lektion** – Verwaltung von Unterrichtsstunden (CRUD)
- [ ] **Material** – Verwaltung von Lernmaterialien (CRUD)
- [ ] **Raum** – Verwaltung von Unterrichtsräumen inkl. Adresse (CRUD)
- [ ] **Schüler** – Verwaltung von Schülern (CRUD)
- [ ] **Lehrer** – Verwaltung von Lehrkräften (CRUD)

### Frontend – Angular

- [ ] **Instrument** – Liste, Erstellen, Bearbeiten, Löschen
- [ ] **Lektion** – Liste, Erstellen, Bearbeiten, Löschen
- [ ] **Material** – Liste, Erstellen, Bearbeiten, Löschen
- [ ] **Raum** – Liste, Erstellen, Bearbeiten, Löschen
- [ ] **Schüler** – Liste, Erstellen, Bearbeiten, Löschen
- [ ] **Lehrer** – Liste, Erstellen, Bearbeiten, Löschen

---

## Projektstruktur

```
dsh/
├── API/          # ASP.NET Core Web API
├── Contract/     # Gemeinsame Verträge / Interfaces
├── Database/     # Datenbankmigrationen / Skripte
├── Docu/         # Dokumentation & Diagramme
└── docker-compose.yml
```

