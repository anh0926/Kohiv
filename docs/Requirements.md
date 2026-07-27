# Kohiv Requirements Document

## 1. Introduction

This document defines the business requirements for Kohiv.

The purpose of this document is to translate the Product Vision into clear requirements that guide solution design and development.

This document describes **what the system should do** without defining technical implementation decisions.

---

# 2. Functional Requirements

## FR-001 User Authentication

The system shall allow users to:

* Register an account.
* Authenticate securely.
* Access their personal Experiences.

The system shall ensure users can only access their own data.

---

## FR-002 Create Experience

The system shall allow authenticated users to create an Experience.

Users shall provide:

* Title
* Category
* Status

Users may provide:

* Description
* Location
* Images
* Source URL
* Additional details

---

## FR-003 View Experience

The system shall allow users to view detailed information about an Experience.

---

## FR-004 Edit Experience

The system shall allow users to modify their Experiences.

---

## FR-005 Delete Experience

The system shall allow users to remove their Experiences.

---

## FR-006 Search Experiences

The system shall allow users to search their Experience collection.

---

## FR-007 Filter Experiences

The system shall allow users to filter Experiences by:

* Category
* Status

---

## FR-008 Experience Status Management

The system shall support the following statuses:

* Wishlist
* Completed

An Experience shall have only one status at any time.

---

## FR-009 Experience Images

The system shall allow users to attach multiple images to an Experience.

Advanced image management is outside MVP scope.

---

## FR-010 Assisted URL Import

The system shall allow users to paste a supported source URL.

Where supported, the system shall retrieve available information to assist Experience creation.

Imported information shall be presented to the user for review.

The user must approve or modify the imported information before the Experience can be saved.

The system shall always store the original source URL when provided.

---

# 3. Experience Data Requirements

Each Experience should support:

## Required

- Owner
- Title
- Category
- Status

## Optional

- Description
- Location
- Source URL
- Cover Image
- Additional Images
- Distance
- Duration
- Difficulty

## System Metadata

The system shall maintain:

- Creation information
- Last modified information

---

# 4. Business Rules

## BR-001 Ownership

Every Experience belongs to exactly one authenticated user.

---

## BR-002 Data Privacy

Users cannot view or modify Experiences belonging to another user.

---

## BR-003 Status

An Experience must have exactly one status.

---

## BR-004 Categories

Experience categories are predefined in the MVP.

Users cannot create custom categories.

---

# 5. Validation Rules

Examples:

* Title is required.
* Category is required.
* Status is required.
* Invalid URLs should not be accepted.
* Images must meet supported requirements.
- Exactly one image may be designated as the primary (cover) image.
- Assisted URL Import requires user review before saving.

---

# 6. User Permissions

## Authenticated User

Users can:

* Create Experiences.
* View their Experiences.
* Edit their Experiences.
* Delete their Experiences.

Users cannot:

* Access other users' Experiences.

---

# 7. Acceptance Criteria

## Create Experience

Given an authenticated user,

When the user enters valid Experience information,

Then the system creates and stores the Experience.

---

## Search Experience

Given a user has saved multiple Experiences,

When the user searches,

Then matching Experiences are displayed.

---

## Update Status

Given an existing Experience,

When the user changes its status,

Then the Experience reflects the new status.

---

## URL Import

Given a valid source URL,

When the user imports it,

Then the system assists with information retrieval and allows the user to review before saving.


### Experience Metadata

The system maintains metadata for each Experience, including:

- Creation information
- Last modified information

This metadata supports future auditing, sorting, and user history features.

---

# 8. Non-Functional Requirements

## Security

* User data must be protected.
* Users must only access their own information.

## Maintainability

The system should support future modules.

## Scalability

The design should allow future growth to multiple users.

## Usability

Common tasks such as saving an Experience should require minimal effort.

## Reliability

The system should handle invalid input gracefully.

---

# 9. Assumptions

* The MVP focuses on personal experience management.
* Users manually review imported information.
* Categories are predefined.
* Advanced AI features are future enhancements.

---

# 10. Out of Scope

The MVP does not include:

* Social features.
* Public profiles.
* Trip planning.
* Itineraries.
* AI recommendations.
* Smart categorisation.
* Advanced image management.
* Map-based discovery.

---

# Document Status

Product Planning Phase: Completed

Next Phase:

Solution Architecture
