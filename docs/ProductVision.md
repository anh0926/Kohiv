# Kohiv Product Vision Document

## 1. Product Overview

### Product Name

Kohiv

### Product Positioning

Kohiv is a **personal experience library** that helps users collect, organize, and revisit meaningful experiences.

The product provides one place where users can save places and activities they discover, track experiences they plan to complete, and preserve experiences they have already completed.

The MVP is designed as a personal application focused on individual users and personal data ownership.

Future versions may expand into additional personal life management areas such as Recipes, Health Tracking, Journal, and other modules.

---

# 2. Vision Statement

> Kohiv helps users build a personal library of experiences by providing a simple way to save, organize, and revisit places and activities they want to explore while preserving memories of experiences they have completed.

---

# 3. Problem Statement

People frequently discover interesting places and activities through:

* Websites
* Travel blogs
* Social media
* Videos
* Recommendations
* Online articles

However, this information becomes scattered across:

* Browser bookmarks
* Notes
* Screenshots
* Saved posts
* Memory

As a result, users often:

* Forget places they wanted to visit.
* Spend time searching for the same information again.
* Cannot easily remember experiences they have already completed.

Kohiv provides a dedicated personal library where users can store and manage these experiences.

---

# 4. Product Purpose

Kohiv connects three stages of a user's journey:

## Future Self

Places and activities the user wants to experience.

Example:

> "I want to visit this hiking track someday."

## Current Self

Helping users decide what experiences to do next.

Example:

> "What interesting places have I saved nearby?"

## Past Self

Remembering completed experiences.

Example:

> "I visited this place before and want to remember it."

---

# 5. Target Users

## MVP User

The initial user is the product owner.

The MVP focuses on personal use while building a production-quality portfolio project.

## Future Users

Individuals who want a personal experience library to:

* Save interesting places.
* Organize experiences.
* Track completed activities.
* Preserve memories.

Each Experience belongs to exactly one authenticated user.

---

# 6. Core Domain: Experience

The main concept in Kohiv is an **Experience**.

An Experience represents a place or activity that a user wants to save, plan, or remember.

Examples:

* Hiking tracks
* Cycling routes
* Travel destinations
* Scenic locations
* Cafés
* Restaurants
* Camping locations

An Experience has a lifecycle:

```
Saved → Planned → Completed
```

## Saved

The user discovered something interesting and wants to keep it.

## Planned

The user intends to complete the experience.

## Completed

The user has completed the experience and may add photos or notes.

Only one status can exist for an Experience at a time.

---

# 7. MVP Scope

## Experience Management

Users can:

* Create Experiences.
* View Experience details.
* Edit Experiences.
* Delete Experiences.

---

## Organization

Users can:

* Search Experiences.
* Filter Experiences by category.
* Filter Experiences by status.

---

## Experience Information

Each Experience supports:

Required information:

* Title
* Category
* Status

Optional information:

* Description
* Cover image
* Multiple images
* Source URL
* Distance
* Duration
* Difficulty
* Location

### Images

An Experience may contain multiple images.

One image may be designated as the primary (cover) image used throughout the application.

Advanced image capabilities such as albums, captions, image editing, image ordering, and tagging are outside the MVP.

---

## Categories

The MVP uses predefined categories.

Users cannot create custom categories.

Initial categories:

* Hiking
* Cycling
* Destination
* Scenic Spot
* Café
* Restaurant
* Camping
* Other

---

# 8. Assisted URL Import

URL Import is included in the MVP.

The goal is to reduce manual data entry.

User workflow:

1. User provides a source URL.
2. Kohiv stores the URL.
3. Kohiv attempts to retrieve basic information where possible.
4. Information is presented to the user.
5. User reviews and edits the information.
6. User saves the Experience.

The system assists users but does not automatically create Experiences without user approval.

---

# 9. Authentication

Authentication is included in the MVP.

Users must:

* Create an account.
* Sign in.
* Manage their own Experiences.

Users can only access Experiences belonging to their account.

---

# 10. Product Principles

## Keep Capture Simple

Saving an interesting experience should be quick and easy.

## User Controls Their Data

Users review and approve information before saving.

## AI Assists, Not Replaces

Future AI capabilities should enhance user decisions rather than remove user control.

## Build for Extension

The system should support future modules without unnecessary redesign.

## Avoid Overengineering

Future possibilities should guide decisions, but current user value remains the priority.

---

# 11. Future Roadmap

## Phase 1 — Experience Library MVP

* Experience management
* Authentication
* Search
* Filtering
* Status tracking
* Assisted URL Import

---

## Phase 2 — Enhanced Experience Management

Potential features:

* AI-assisted content understanding
* Better extraction
* Improved search
* Recommendations

---

## Phase 3 — Experience Discovery

Potential features:

* Maps
* Location-based discovery
* Nearby experiences
* Smart suggestions

---

## Phase 4 — Planning Features

Potential features:

* Trips
* Itineraries
* Group Experiences into journeys

---

## Phase 5 — Personal Life Modules

Potential modules:

* Recipes
* Health Tracking
* Journal
* Finance Management

---

# 12. Learning Objective

Kohiv is both:

1. A product designed to solve a genuine personal problem.
2. A portfolio project to develop professional software engineering skills.

The project provides opportunities to practice:

* Modern .NET development.
* Software architecture.
* Cloud deployment.
* Azure capabilities.
* AI integration where it provides meaningful user value.

Technology choices should support the product vision rather than introduce unnecessary complexity.
