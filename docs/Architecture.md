# Kohiv Architecture Document

## 1. Overview

Kohiv is designed as a modular personal experience library.

The MVP focuses on the Experiences module, allowing users to save, organize, and manage personal experiences such as hiking tracks, cafes, scenic locations, and other activities.

The architecture is designed to:

- Support clean separation of responsibilities.
- Improve maintainability.
- Allow future expansion into additional modules.
- Support future frontend changes such as React.
- Provide practical experience with professional software architecture patterns.

---

# 2. Architecture Style

Kohiv follows a Clean Architecture inspired approach.

The main principle is:

> Business rules should not depend on external technologies.

The system is separated into four main projects:
Kohiv.Web

Kohiv.Application

Kohiv.Domain

Kohiv.Infrastructure

Each layer has a specific responsibility.

---

# 3. Solution Structure
Kohiv.slnx

src

├── Kohiv.Web
│
├── Kohiv.Application
│
├── Kohiv.Domain
│
└── Kohiv.Infrastructure

tests

├── Kohiv.UnitTests
│
└── Kohiv.IntegrationTests

---

# 4. Project Responsibilities

# 4.1 Kohiv.Web

## Purpose

The presentation layer responsible for communication with users.

The MVP uses:

- ASP.NET Core MVC
- Razor Views

## Responsibilities

Kohiv.Web handles:

- HTTP requests
- Controllers
- Views
- ViewModels
- User interaction
- Authentication UI

Example:

ExperienceController

Responsibilities:

- Receive requests.
- Call application services.
- Return views.

## Should NOT contain:

- Business rules.
- Database access.
- EF Core code.

---

# 4.2 Kohiv.Application

## Purpose

The application layer represents what the system can do.

It coordinates business workflows.

## Responsibilities

Contains:

- Application services.
- DTOs.
- Interfaces.
- Use cases.

Example:
ExperienceService

Possible operations:
Create Experience

Update Experience

Search Experiences

Change Experience Status

The Application layer coordinates actions but does not know:

- SQL Server.
- EF Core.
- UI technology.

---

## Repository Interfaces

Repository contracts are defined here.

Example:
IExperienceRepository

The Application layer defines what it needs:

Example:
Get Experience

Save Experience

Delete Experience

It does not care how data is stored.

The implementation exists in Infrastructure.

---

# 4.3 Kohiv.Domain

## Purpose

The Domain layer contains the core business concepts and rules.

This is the heart of Kohiv.

## Responsibilities

Contains:

- Entities.
- Enums.
- Value Objects.
- Business rules.

Example:
Experience.cs


An Experience represents a meaningful place or activity.

Example properties:


Id

Title

Category

Description

Location

Status


The entity may contain business behaviour.

Example:


MarkAsCompleted()

ChangeStatus()


Business rules belong here.

Example:


An Experience can only have one status.

Status changes must follow business rules.


The Domain layer does not know about:

- Database.
- Web.
- EF Core.
- Azure.

---

# 4.4 Kohiv.Infrastructure

## Purpose

Infrastructure handles external technology.

## Responsibilities

Contains:

- Entity Framework Core.
- Database context.
- Repository implementations.
- External services.

Examples:


ApplicationDbContext

ExperienceRepository

Azure Storage Service


Infrastructure communicates with:


SQL Server

Azure Services

External APIs


---

# 5. Dependency Direction

The dependency direction is:


Kohiv.Web

  ↓

Kohiv.Application

  ↓

Kohiv.Domain



Infrastructure:


Kohiv.Infrastructure

  ↓

Kohiv.Application

  ↓

Kohiv.Domain


The Domain layer is the centre.

External technologies depend on business rules.

Business rules do not depend on external technologies.

---

# 6. Data Flow Example

## User creates an Experience

Flow:


Browser

↓

ExperienceController

↓

ExperienceService

↓

Experience Entity

↓

ExperienceRepository

↓

ApplicationDbContext

↓

SQL Server


Explanation:

1. Browser sends request.
2. Controller receives request.
3. Application service coordinates the operation.
4. Domain entity applies business rules.
5. Repository saves data.
6. Infrastructure communicates with database.

---

# 7. Domain Model Approach

Kohiv will use a balanced domain model approach.

The project will avoid:

## Pure Anemic Model

Where entities only contain properties and all logic exists in services.

Example problem:


ExperienceService

1000+ lines

Many business rules


---

Kohiv will also avoid:

## Over-engineered Enterprise DDD

The project will not introduce unnecessary complexity.

---

The chosen approach:

## Rich Entities + Simple Services

Meaning:

Entities:

- Protect important business rules.

Services:

- Coordinate workflows.

Repositories:

- Handle persistence.

---

# 8. Frontend Decision

## MVP

Kohiv will use:


ASP.NET Core MVC + Razor


Reasons:

- Faster MVP development.
- Existing developer experience.
- Allows focus on backend architecture.
- Suitable for portfolio demonstration.

---

## Future React Support

The architecture allows future migration to:


React

↓

Kohiv.API

↓

Application

↓

Domain

↓

Infrastructure


The core business logic does not need to be rewritten.

Only the presentation layer changes.

---

# 9. API Future Direction

Currently:


Kohiv.Web


handles:

- Controllers.
- Views.
- User interface.

Future option:

Add:


Kohiv.API


Responsibilities:

- Provide JSON endpoints.
- Support React frontend.
- Support mobile applications.

Example:


GET /api/experiences


Returns:


ExperienceDto


---

# 10. Image Storage Design

Experience images are separated from the Experience entity.

Relationship:


Experience

  1

  *

ExperienceImage


Example:

Experience:


Hooker Valley Track


Images:


image1.jpg
image2.jpg
image3.jpg


One image can be marked as the cover image.

Example:


ExperienceImage

Id

ExperienceId

ImageUrl

IsCover


Future storage:


Azure Blob Storage


Database stores image references rather than image files.

---

# 11. Future Module Expansion

Kohiv may expand into:

- Recipes.
- Health Tracking.
- Journal.
- AI Features.

The initial architecture supports future modules.

Possible future structure:


Application

├── Experiences

├── Recipes

├── Health

└── Journal


Modules will be introduced only when they provide real value.

---

# 12. Architectural Principles

## Separation of Concerns

Each layer has a clear responsibility.

---

## Dependency Independence

Business logic should not depend on infrastructure.

---

## Avoid Overengineering

Build current requirements first.

Future possibilities should guide decisions but not complicate MVP development.

---

## Maintainability

The system should be easy to understand and extend.

---

# Document Status

Status:

Architecture Design Completed

Next Phase:

Database Design
