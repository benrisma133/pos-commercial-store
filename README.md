# POS Commercial Store

A simple and clean Point of Sale (POS) system designed for managing a small to medium commercial store.

This project focuses on database design and backend structure for handling real-world retail operations.

---

## 📊 Features

- Product management with categories
- Customer management (optional for walk-in sales)
- Sales transactions with multiple items
- Stock movement tracking (IN / OUT / ADJUST)
- Historical data preservation for sales accuracy

---

## 🗂 Database Structure

### Main Tables

- Categories → Organize products
- Products → Store inventory items
- Customers → Optional customer tracking
- Sales → Main transactions
- SaleItems → Items inside each sale
- StockMovements → Track stock changes

---

## 🔗 Relationships

- One Category → Many Products
- One Sale → Many SaleItems
- One Product → Many SaleItems
- One Product → Many StockMovements
- Optional Customer → Many Sales

---

## 🧠 Design Rules

- Prices and quantities are always >= 0
- Sales history is preserved even if products change
- Foreign keys ensure data integrity
- Stock movements provide full audit trail

---

## 🛠 Tech

- SQLite (or any relational database)
- Designed for .NET / MAUI / desktop POS systems

---

## 🚀 Purpose

This project is intended for learning, prototyping, and building real POS systems for commercial stores.

---

## 📌 Author

Ismail Benrahhal