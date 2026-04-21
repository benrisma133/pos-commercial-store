# 🛒 POS Commercial Store

A clean and simple Point of Sale (POS) system designed for managing a small to medium commercial store.

This project is built for learning and real-world practice of database design, layered architecture, and POS workflows.

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/benrisma133/pos-commercial-store.git
```

### 2. Open the project

Open the solution file in Visual Studio:

```
POSApp.slnx
```

### 3. Run the application

- Restore NuGet packages
- Build the solution
- Run the .NET MAUI application

---

## 🧱 Architecture

The project follows a simple **3-Tier Architecture**:

```
UI Layer        → POSApp (.NET MAUI)
Business Layer  → Service
Data Layer      → Repository
```

Each layer is independent to ensure:

- ✅ Clean separation of concerns
- ✅ Easy maintenance
- ✅ Scalability

---

## 📊 Features

- 🏷️ Product management with categories
- 👤 Customer management *(optional for walk-in sales)*
- 🛒 Sales transactions with multiple items (cart system)
- 📦 Stock movement tracking **(IN / OUT / ADJUST)**
- 🕓 Full sales history preservation
- 🔄 Real-time inventory updates

---

## 🗂 Database Design

### Main Tables

| Table | Description |
|---|---|
| `Categories` | Organize products into groups |
| `Products` | Store inventory items |
| `Customers` | Optional customer tracking |
| `Sales` | Main transactions (header) |
| `SaleItems` | Items inside each sale (details) |
| `StockMovements` | Track all stock changes |

### 🔗 Relationships

- One **Category** → Many **Products**
- One **Sale** → Many **SaleItems**
- One **Product** → Many **SaleItems**
- One **Product** → Many **StockMovements**
- Optional **Customer** → Many **Sales**

---

## 🧠 Business Rules

- Prices and quantities are always **≥ 0**
- Stock **cannot go below zero**
- Sales are **immutable** (history preserved)
- Product snapshot *(name & price)* is stored in sales
- Foreign keys ensure **data integrity**
- Stock movements provide a **full audit trail**

---

## 🛠 Tech Stack

| Technology | Role |
|---|---|
| .NET MAUI | Cross-platform UI |
| C# (.NET 8+) | Core language |
| SQLite | Database |
| 3-Tier Architecture | Design pattern |

---

## 🎯 Purpose

This project is intended for:

- 📚 Learning real-world software architecture
- 🛠️ Practicing POS system development
- 🏪 Building scalable commercial store systems
- 🚀 Preparing for production-level applications

---

## 📌 Repository Info

- **GitHub:** [pos-commercial-store](https://github.com/benrisma133/pos-commercial-store)
- **Author:** Ismail Benrahhal