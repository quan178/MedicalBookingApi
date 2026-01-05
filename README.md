# 🏥 Medical Booking API

Backend API for a Medical Appointment Booking System built with **ASP.NET Core 9.0**.
This project demonstrates how to handle **booking logic**, **concurrency control**, and **database management** using Entity Framework Core.

## 🚀 Tech Stack

* **Framework:** ASP.NET Core 9.0 Web API
* **Database:** SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Documentation:** Swagger / OpenAPI
* **Tools:** Visual Studio 2022

## 🔥 Key Features

* **Doctor Management:** List available doctors and specializations.
* **Appointment Booking:** Schedule appointments for patients.
* **⚠️ Concurrency Handling:** Implemented logic to prevent **double-booking** (preventing multiple patients from booking the same doctor at the same time).
* **Validation:** Input data validation using Data Transfer Objects (DTOs).

## 🛠️ How to Run

1.  **Clone the repo**
    ```bash
    git clone [https://github.com/](https://github.com/)[quan178]/MedicalBookingApi
    ```
2.  **Configure Database**
    Update the connection string in `appsettings.json` if necessary.
3.  **Run Migrations**
    Open Package Manager Console (or Terminal) and run:
    ```bash
    Update-Database
    # Or: dotnet ef database update
    ```
4.  **Start the API**
    Run the project in Visual Studio (F5). Access Swagger UI at:
    `https://localhost:[port]/swagger`

## 📸 Screenshots

![Swagger UI]([https://github.com/user-attachments/assets/fcd9442f-e2d2-4478-8b2e-81e43d2fbe1d])
*API Documentation with Swagger*

![Conflict Error]([https://github.com/user-attachments/assets/ea49efe9-e986-42b0-83bc-f860f322803d])
*Logic handling: Preventing duplicate bookings*
