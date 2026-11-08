# Kohiv

Kohiv is a personal experience library for saving, organising, and revisiting places, activities, and moments that matter.

It helps turn "I should do that someday" into a personal collection that can be updated after the experience and returned to over time.

## What Kohiv Does

Kohiv helps people save experiences such as:

- Places they want to visit
- Activities they want to try
- Cafes, restaurants, hikes, and destinations they want to remember
- Experiences they have already completed

Each Experience can include a title, category, status, location, description, and source link.

The goal is simple: make it easier to save meaningful experiences now and find them again later.

## Current Features

Kohiv currently supports:

- Viewing a list of Experiences
- Creating an Experience
- Viewing Experience details
- Editing an Experience
- Deleting an Experience
- Organising Experiences by category
- Marking an Experience as Wishlist or Completed
- Saving optional location, description, and source URL information

## Current Focus

Kohiv is an ongoing portfolio project.

The current focus is completing the Experience feature from end to end: storing Experiences, managing them through the application, and building a modern frontend for viewing them.

The existing web interface is built with ASP.NET Core MVC and Razor views.

Kohiv is gradually introducing a React and TypeScript frontend, beginning with the Experience List. ASP.NET Core will continue to handle business logic, data access, authentication, and API endpoints.

## In Progress

Upcoming Experience work includes:

- React and TypeScript Experience List interface
- ASP.NET Core API integration
- Secure personal accounts with registration, login, logout, and Experience ownership
- Each user will be able to view and manage only their own Experiences
- Experience images and cover images
- Search and filtering
- AI-assisted source import using Azure AI, helping users extract useful Experience details from supported links before reviewing and saving them

## Future Direction

Experiences are Kohiv's first module, not its final limit.

Over time, Kohiv may grow into a broader personal platform for helping people save, organise, plan, and revisit meaningful parts of their lives. New features will be added only when they solve a real user problem.

Kohiv may also use AI to reduce manual data entry. For example, a user may provide a supported source link and receive suggested Experience details to review before saving. Users remain in control of the final information stored in Kohiv.

As Kohiv grows, personal accounts will ensure that each user's saved Experiences remain private and accessible only to them.

## Current Technology

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor Views
- Azure App Service
- Azure SQL Database

## Technology Being Introduced

- React
- TypeScript
- ASP.NET Core Identity
- ASP.NET Core Web API
- Azure AI for assisted source import

## Architecture

The backend follows Clean Architecture principles.

```text
Kohiv.Domain
    Core business entities and rules

Kohiv.Application
    Application use cases and interfaces

Kohiv.Infrastructure
    Entity Framework Core, SQL Server, repositories, and external services

Kohiv.Web
    ASP.NET Core MVC application, API endpoints, and web-facing concerns
```

The React and TypeScript client will be introduced as a separate frontend project. It will communicate with the ASP.NET Core backend through API endpoints rather than directly accessing the database.

## Project Status

Kohiv is actively being developed as a production-minded portfolio project.

The aim is not simply to add features quickly. Each feature is built to practise practical software-engineering skills including domain modelling, clean architecture, database design, API design, frontend development, authentication, testing, AI integration, and cloud deployment.

## Running Locally

Requirements:

- .NET 10 SDK
- SQL Server or SQL Server LocalDB
- Node.js, once the React client is added

Run the ASP.NET Core application:

```bash
dotnet run --project src/Kohiv.Web
```

The application uses Entity Framework Core migrations to create and update the database schema.

## Deployment

Kohiv is deployed to Azure using:

- Azure App Service
- Azure SQL Database

## Author

Built by Anh as an ongoing full-stack software engineering portfolio project.

