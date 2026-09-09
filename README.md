# Booking API

A REST API for managing bookings at small beauty/hair businesses, with authentication and logic that prevents double-booking a stylist.

This project grew out of real conversations with small business owners about scheduling problems — see [`database/database-design.md`](./database/database-design.md) for the full background and data model reasoning.

## Live Demo

[Swagger UI](https://noah-booking-api.azurewebsites.net/swagger/index.html)

Hosted on Azure's free tier, so the app may take 10-20 seconds to wake up if it hasn't been visited recently.

## Tech Stack

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- JWT authentication
- Swagger / OpenAPI
- xUnit
- Deployed on Azure App Service

## Features

- Full CRUD for Customers, Stylists, Services, and Bookings
- JWT-based registration and login
- Automatic double-booking prevention (checks for overlapping appointment times per stylist)
- Automatic end-time calculation based on service duration
- Interactive API documentation via Swagger UI
- Unit tests covering the overlap-detection logic

## Status

✅ Complete: core API, authentication, documentation, tests, and live deployment.

## Running Locally

Clone the repo, then from the `BookingApi/BookingApi` folder:

    dotnet restore
    dotnet ef database update
    dotnet run

Then visit `https://localhost:<port>/swagger` for the interactive API documentation (port shown in the console output).

## Running Tests

From the `BookingApi.Tests` folder:

    dotnet test