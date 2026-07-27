# Kohiv API Design

**Version:** 1.0
**Status:** Approved
**Owner:** Solution Architecture
**Last Updated:** July 2026

---

# 1. Introduction

This document defines the API design principles and endpoint conventions for Kohiv.

The purpose of this document is to provide a consistent and maintainable approach for exposing application functionality.

This document focuses on **API design** rather than implementation details.

---

# 2. API Style

Kohiv follows the **REST (Representational State Transfer)** architectural style.

REST principles adopted by Kohiv include:

* Resource-based URLs
* Standard HTTP methods
* Stateless communication
* JSON request and response payloads
* Appropriate HTTP status codes

---

# 3. Design Principles

## Resource-Based URLs

URLs represent resources rather than actions.

Examples:

```text
/experiences
/categories
/users
```

Actions are determined by the HTTP method rather than the URL.

Example:

```text
GET    /experiences
POST   /experiences
PUT    /experiences/25
DELETE /experiences/25
```

---

## Stateless Communication

Each request contains all information required for the server to process it.

The server does not rely on information from previous requests.

Authentication information is included with every authenticated request.

---

## JSON

The API exchanges data using JSON.

Example response:

```json
{
  "id": 12,
  "title": "Hooker Valley Track",
  "category": "Hiking",
  "status": "Wishlist"
}
```

---

# 4. Authentication

The MVP uses:

* ASP.NET Core Identity
* Cookie Authentication

Authenticated users may only access resources that belong to their own account.

Future versions may support JWT authentication for React and mobile applications.

---

# 5. Endpoint Conventions

## Experience Resource

### Get all Experiences

```text
GET /experiences
```

Returns all Experiences belonging to the authenticated user.

---

### Get Experience by Id

```text
GET /experiences/{id}
```

Returns a single Experience.

---

### Create Experience

```text
POST /experiences
```

Creates a new Experience.

---

### Update Experience

```text
PUT /experiences/{id}
```

Updates an existing Experience.

---

### Delete Experience

```text
DELETE /experiences/{id}
```

Deletes an Experience.

---

# 6. Searching and Filtering

Filtering uses query parameters.

Examples:

Search:

```text
GET /experiences?search=Hooker
```

Filter by category:

```text
GET /experiences?categoryId=1
```

Filter by status:

```text
GET /experiences?status=Wishlist
```

Multiple filters:

```text
GET /experiences?categoryId=1&status=Wishlist
```

Future versions may support:

* Sorting
* Pagination
* Additional filters

---

# 7. HTTP Status Codes

| Status Code               | Meaning                       |
| ------------------------- | ----------------------------- |
| 200 OK                    | Request successful            |
| 201 Created               | Resource created successfully |
| 204 No Content            | Resource deleted successfully |
| 400 Bad Request           | Invalid request               |
| 401 Unauthorized          | User is not authenticated     |
| 403 Forbidden             | User does not have permission |
| 404 Not Found             | Resource not found            |
| 500 Internal Server Error | Unexpected server error       |

---

# 8. Validation

The API validates all incoming requests.

Examples include:

* Required fields
* Invalid identifiers
* Invalid URLs
* Invalid enum values
* Ownership validation

Invalid requests return appropriate HTTP status codes.

---

# 9. Authorization

Every Experience belongs to one authenticated user.

The API must ensure:

* Users can only view their own Experiences.
* Users can only modify their own Experiences.
* Users cannot access another user's data.

---

# 10. Error Handling

Errors should return consistent HTTP status codes and meaningful messages.

Example:

```json
{
  "message": "Experience not found."
}
```

Detailed internal exception information should never be exposed to clients.

---

# 11. Future Enhancements

Future API improvements may include:

* JWT Authentication
* API Versioning
* Pagination
* Sorting
* Batch Operations
* Rate Limiting
* Public API endpoints
* OpenAPI / Swagger documentation

---

# 12. Summary

The Kohiv API follows REST principles to provide a simple, consistent, and maintainable interface for managing Experiences.

The API is designed to support the current MVC application while remaining flexible enough to support future clients such as React or mobile applications.

---

# Document Status

**Solution Architecture Phase:** Completed

**Next Phase:** Application Development
