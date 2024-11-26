# Inventory Management System

This project implements an **Inventory Management System** with a database schema designed to manage inventory items, categories, batches, and purchase orders efficiently. The system supports relationships between entities with well-defined foreign key constraints.

## Features

- Inventory item management with attributes such as name, description, SKU, and category.
- Relationships with:
  - **Batch** for batch tracking.
  - **Category** for inventory categorization.
  - **Inventory** for overall stock management.
  - **Purchase Order** for procurement tracking.
- Controlled cascading behaviors to prevent multiple cascade paths and ensure data integrity.

## Table Schema

### `InventoryItem`
| Column               | Data Type         | Description                                |
|----------------------|-------------------|--------------------------------------------|
| `Id`                | `int`            | Primary key.                              |
| `Name`              | `nvarchar(max)`  | Name of the inventory item.               |
| `Description`       | `nvarchar(max)`  | Detailed description of the item.         |
| `SKU`               | `nvarchar(max)`  | Stock Keeping Unit identifier.            |
| `CategoryId`        | `int`            | Foreign key to the `Category` table.      |
| `BatchId`           | `int`            | Foreign key to the `Batch` table.         |
| `PurchaseOrderId`   | `int` (nullable) | Foreign key to the `PurchaseOrder` table. |
| `IsPrescriptionRequired` | `bit`         | Indicates if a prescription is required.  |
| `InventoryId`       | `int`            | Foreign key to the `Inventory` table.     |

### Relationships and Constraints
- **Primary Key**: `Id`
- **Foreign Keys**:
  - `BatchId` → References `Batch(Id)` with `ON DELETE CASCADE`.
  - `CategoryId` → References `Category(Id)` with `ON DELETE NO ACTION`.
  - `InventoryId` → References `Inventory(Id)` with `ON DELETE NO ACTION`.
  - `PurchaseOrderId` → References `PurchaseOrder(PurchaseOrderId)` with `ON DELETE SET NULL`.

## Prerequisites

- **.NET Core** 6.0+
- **Entity Framework Core** 7.0+
- **SQL Server**

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/inventory-management.git
   cd inventory-management
