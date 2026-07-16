# TheByteClubPOS - Point of Sale & Inventory Management System

![C#](https://img.shields.io/badge/C%23-Language-239120?logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET-Framework-512BD4?logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows-Forms-0078D6?logo=windows&logoColor=white)

This project was developed as part of a third-year software development group project at the University of KwaZulu-Natal.

This application is a Windows Forms Point of Sale (POS) and Inventory Management System designed for Sam's Liquor Store. The system replaces a traditional cash register with a modern desktop application that helps manage sales, inventory, products, employees and customers while providing business reporting and customer loyalty functionality.

The application includes secure role-based authentication, real-time inventory management, loyalty points, reporting, and automated receipt generation. The project was developed by **The Byte Club** using C#, Windows Forms and SQL Server.

## Features

### Authentication
- Secure login system
- Forgot password via email recovery
- Password validation
- Show/Hide password
- Light and Dark mode
- Dynamic motivational quotes

### Cashier
- Personalised dashboard
- Process sales
- Dynamic product & barcode search
- Shopping cart
- Cash, Card and Loyalty Point payments
- Loyalty point redemption
- Automatic discounts
- Printable & Email receipts
- Edit own profile

### Manager
- Business dashboard
- Product, Employee & Customer management
- Sales history
- PDF report generation
- Excel export
- Low stock monitoring
- Best & least selling products

### Inventory
- Real-time stock updates
- Product categorisation
- Image support
- Stock alerts

### Customer Loyalty
- Customer registration
- Loyalty point accumulation
- Loyalty point redemption
- Customer search
- Customer profile management

### Reporting
- Sales reports
- PDF exports
- Excel exports
- Dashboard analytics
- Sales statistics

## Authentication
### Loading Screen
<img width="1356" height="718" alt="0" src="https://github.com/user-attachments/assets/b119e2ee-25d5-4550-9c1f-0c134b080cda" />
The application launches with a branded loading screen before connecting to the database.

### Login
<img width="1356" height="718" alt="1" src="https://github.com/user-attachments/assets/3ef1003c-69fc-4346-b22b-c75177a3ecfe" />
The login screen supports secure authentication, password visibility, dynamic password validation, dark mode and rotating motivational quotes.

### Forgot Password
<img width="1356" height="718" alt="3" src="https://github.com/user-attachments/assets/1d203f6a-7ec4-4787-ba33-9f90a35109c2" />
Employees can recover their login credentials by entering their registered username or email address.

## Cashier Functionality
### Cashier Dashboard
<img width="1356" height="718" alt="5" src="https://github.com/user-attachments/assets/e2539ea7-4bfd-447b-b4f2-54f8eba0e9c9" />
Each cashier has their own dashboard showing personal sales statistics, revenue generated and recent transactions.

### Process Sale
<img width="1356" height="718" alt="7" src="https://github.com/user-attachments/assets/2ed0fff4-da01-45ac-8eab-941c130b6e21" />
Products can be searched dynamically by name or barcode before being added to the shopping cart.

### Shopping Cart
<img width="1356" height="718" alt="11" src="https://github.com/user-attachments/assets/3adaa920-ba66-426e-8a90-90f63fc4885a" />
The shopping cart supports discounts, multiple payment methods and loyalty point redemption.

### Transaction Complete
<img width="374" height="224" alt="12" src="https://github.com/user-attachments/assets/bb54b5d9-16c9-451b-a88a-359aa3ea140e" />

After every successful sale the system generates an invoice and calculates loyalty points earned.

### Printed Receipt
<img width="1356" height="718" alt="13" src="https://github.com/user-attachments/assets/79b3dcfc-9f1a-463b-8233-ac95c7703f80" />
Customers can receive a printed receipt.

### Email Receipt
<img width="662" height="637" alt="14" src="https://github.com/user-attachments/assets/34a795ec-f252-4f2b-b87b-be34b30e33a7" />

Receipts can also be emailed directly to customers.

### My Profile
<img width="1356" height="718" alt="16" src="https://github.com/user-attachments/assets/b82d66f1-4ac0-4bdd-9c65-b20f5820667b" />
Cashiers can update their own personal information without being able to modify other employees.

## Manager Functionality
### Manager Dashboard
<img width="1356" height="718" alt="20" src="https://github.com/user-attachments/assets/1ff165a3-59fc-46d1-8ece-25c707c3f053" />
Managers have access to business statistics including sales, employees, customers, low stock products and best-selling items.

### Sales History
<img width="1356" height="718" alt="21" src="https://github.com/user-attachments/assets/49aad127-c189-4018-8fdd-d494038c4238" />
Managers can review historical sales, payment methods and purchased items.

### PDF Reporting
<img width="1348" height="593" alt="23" src="https://github.com/user-attachments/assets/918f63ed-60fc-4b75-acbe-337e85e199f5" />
Filtered sales reports can be exported to PDF.

### Product Management
<img width="1356" height="718" alt="24" src="https://github.com/user-attachments/assets/735b7357-d56c-44d7-8da4-e68f2d4e6512" />
Managers can search, filter, edit and export product information.

### Add Product
<img width="1356" height="718" alt="26" src="https://github.com/user-attachments/assets/3f5e0243-1916-4e85-ae1f-2628476cbcfc" />
New products can be added with pricing, stock quantities, supplier information and images.

### Employee Management
<img width="1356" height="718" alt="28" src="https://github.com/user-attachments/assets/c11c4ec3-e7a6-48c8-b15a-24ee3e5e1a08" />
Managers can activate or deactivate employee accounts and manage staff information.

### Customer Management
<img width="1356" height="718" alt="31" src="https://github.com/user-attachments/assets/4662529f-1714-464e-8607-721d12a5b586" />
Customer records can be searched, filtered and updated while tracking loyalty information.

## System Information
### About
<img width="1356" height="718" alt="17" src="https://github.com/user-attachments/assets/a399c27a-c6b6-4147-a8f3-8b20b1cd058c" />
Displays information about the project, development team and technologies used.

### Help
<img width="1356" height="718" alt="18" src="https://github.com/user-attachments/assets/366f9c10-4e85-4a50-a077-769d94038df0" />

Built-in user guides help employees learn how to use the system.

### Troubleshooting
<img width="1356" height="718" alt="19" src="https://github.com/user-attachments/assets/b453fe20-004c-41d6-a127-193c56f2e738" />
Common issues and solutions are available directly inside the application.

## Technologies:
- C#
- Windows Forms
- .NET Framework
- SQL Server
- Visual Studio 2022
- GitHub

## Project Status
This project was completed as part of a third-year software development group assignment at the University of KwaZulu-Natal and is no longer under active development. It is being shared to showcase the work completed during the project.

## Installation:
> **Note:** This project was developed using a SQL Server database hosted on the University of KwaZulu-Natal network. Running the application requires access to the university's SQL Server database through the GlobalProtect VPN. As a result, the project cannot be run outside the UKZN environment without modifying the database configuration.
1. Clone the repository
2. Open the solution in Visual Studio 2022
3. Download any required NuGet packages if prompted.
4. Connect to GlobalProtect (University of KwaZulu-Natal VPN)
5. Configure the SQL Server connection
6. Build the solution
7. Run the application

## Future Improvements
Although the system meets the core project requirements, there are several features we would like to implement in future versions:
- Develop a web-based version of the application.
- Complete the refund processing functionality with automatic stock adjustments.
- Add supplier management functionality.
- Allow managers to create, track and receive purchase orders from suppliers.
- Automatically update inventory when stock orders are received.

## Authors (The Byte Club):
- Braeden Govender
- Divani Pillay
- Keenan Nainaar
- Kiyan Krishna
- Rashiven Govender
