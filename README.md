# nq-blazor-test

## Overview

This is a Blazor Server application that demonstrates advanced weather data visualization, role-based filtering, and interactive acknowledgment features. The project is designed with SOLID principles for maintainability and extensibility.

## How to Run the Project

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- Modern web browser (Chrome, Edge, Firefox, Safari)

### Steps

1. **Clone the repository:**
   ```bash
   git clone <your-repo-url>
   cd nq-blazor-test
   ```
2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
3. **Build the project:**
   ```bash
   dotnet build
   ```
4. **Run the project:**
   ```bash
   dotnet run
   ```
5. **Open in browser:**
   - Navigate to `http://localhost:5135/weather` (or the port shown in your terminal)

---

## Features

### 1. Weather Data Table

- Displays weather data for multiple locations, dates, and conditions.
- Columns: Location, Date, Temperature (with emoji), Summary, Severity (with emoji/label).
- Data is generated with realistic temperature ranges and severity levels.

### 2. Sorting

- Click any column header to sort by that column (ascending/descending).
- Sort indicator (▲/▼) shows current sort direction.
- Sorting applies to the entire dataset, not just the current page.

### 3. Pagination

- Only 10 records are shown per page.
- Use Previous/Next buttons to navigate between pages.
- Pagination works with sorting and role-based filtering.

### 4. Role-Based Personalization

- **Role Selector:** Dropdown at the top lets you choose between Default User, Firefighter, and Snow Groomer.
- **Firefighter:**
  - Only cares about "Scorching" (dangerous hot) conditions.
  - Can review/acknowledge these conditions ("Review" button).
  - Cold conditions are de-emphasized (faded).
- **Snow Groomer:**
  - Only cares about "Freezing" and "Bracing" (dangerous/harsh cold) conditions.
  - Can review/acknowledge these conditions ("Review" button).
  - Hot conditions are de-emphasized (faded).
- **Default User:**
  - Sees all data.
  - Dangerous conditions ("Freezing", "Scorching") are highlighted, but less urgently than for special roles.
  - Cannot review/acknowledge any conditions.

### 5. Review/Acknowledgment System

- For Firefighter and Snow Groomer roles, a "Review" button appears for relevant dangerous/harsh conditions.
- Clicking "Review" marks the row as reviewed (shows a checkmark and moves it to the top for that role).
- Reviewed status is tracked per row and role.

### 6. Visual Hierarchy & Highlighting

- Dangerous and harsh weather conditions are visually highlighted with color and icons.
- De-emphasized (irrelevant) rows are faded and italicized for clarity.
- Emojis are used for both temperature and severity for quick visual cues.

### 7. SOLID Principles & Code Quality

- All role-based logic is encapsulated in `WeatherRoleService` for maintainability.
- The main component (`Weather.razor`) is focused on UI and state, not business rules.
- Easy to add new roles or change logic by updating the service.

---

## File Structure (Key Files)

- `Components/Pages/Weather.razor` — Main weather table and UI logic
- `Components/WeatherRoleService.cs` — Role-based logic (SRP, OCP)
- `Models/WeatherCondition.cs` — Weather data model
- `Data/WeatherService.cs` — Generates test weather data
- `wwwroot/app.css` — Custom styles for highlighting, de-emphasis, and table

---

## Accessibility & UX

- Responsive design, works on all screen sizes
- Accessible color contrast and clear visual cues
- User-friendly, modern UI with Bootstrap

---
