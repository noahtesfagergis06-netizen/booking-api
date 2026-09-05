# Booking API

A REST API for managing bookings at small beauty/hair businesses, with authentication and logic that prevents double-booking a stylist.

This project grew out of real conversations with small business owners about scheduling problems — see [`database/database-design.md`](./database/database-design.md) for the full background and data model reasoning.

## Tech Stack

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- JWT authentication

## Features

- Full CRUD for Customers, Stylists, Services, and Bookings
- JWT-based registration and login
- Automatic double-booking prevention (checks for overlapping appointment times per stylist)
- Automatic end-time calculation based on service duration

## Status

In progress. Core API and authentication are complete. Still to come: full endpoint authorization, API documentation (Swagger), unit tests, and deployment.

## Running Locally

Clone the repo, then from the `BookingApi/BookingApi` folder:

    dotnet restore
    dotnet ef database update
    dotnet run

Then visit `https://localhost:<port>/openapi/v1.json` to see the API spec (port shown in the console output).