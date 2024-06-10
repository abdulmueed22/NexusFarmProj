# NexusFarm Platform

## Overview
NexusFarm is an innovative platform designed to address the challenges faced by farmers in Pakistan by connecting them directly with suppliers. This initiative aims to empower farmers by enabling them to showcase their agricultural products and negotiate fair prices through an online marketplace. Suppliers, on the other hand, can easily browse available products and place competitive bids, fostering a transparent and efficient agricultural trade ecosystem.

<br>

## Problem Statement
Pakistan's agricultural sector plays a crucial role in its economy, yet farmers often struggle with low profit margins due to reliance on intermediaries. NexusFarm seeks to eliminate these challenges by providing a direct platform for farmers and suppliers to interact, thereby ensuring better compensation for farmers' hard work.

<br>

## Proposed Solution
NexusFarm facilitates direct communication between farmers and suppliers through a user-friendly online platform. Farmers can upload details of their products, manage their profiles, and negotiate deals with suppliers who bid on their offerings. Similarly, suppliers can post bids for agricultural products they wish to purchase, creating a marketplace that benefits both parties.

<br>

## Modules and Functionalities

### Authentication Module
- **Registration**: Farmers and suppliers can create accounts securely.
- **Login**: Registered users can access their accounts.

<br>

### Farmer Module
- **Farmer Profile**: Manage product listings and personal information.
- **Product Upload**: Upload details of agricultural products for sale.
- **Image Upload**: Store product images in an AWS S3 bucket for display.

<br>

### Supplier Module
- **Supplier Profile**: Manage bid listings and business information.
- **Bid Upload**: Upload bids specifying desired products, quantity, and proposed prices.

<br>

### Farmer Product Module
- **Product Details**: View and manage product listings, including uploaded images.
- **Image Management**: Handle the upload and storage of product images using AWS S3.

<br>

### Supplier Bid Module
- **Bid Details**: View and manage bid listings for purchasing agricultural products.
- **Bid Management**: Facilitate the process of uploading bids to attract farmer sellers.

<br>

### DAL Library (Data Access Layer)
- **Database Interaction**: Manage data retrieval and storage in the SQL database.
- **Data Presentation**: Present retrieved data on the platform's interface.

<br>

## Technologies Used
- **Front End**: HTML, Bootstrap
- **Back End**: C# (ADO .NET)
- **Database**: SQL Server Management Studio (SSMS)
- **Cloud Storage**: AWS S3 for product image storage

<br>

## Development Environment
- **IDE**: Visual Studio
- **Database Management**: SQL Server Management Studio (SSMS)
- **Cloud Services**: AWS for image storage

<br>

## Architecture
This project follows a three-tier architecture, separating presentation, application processing, and data management layers to ensure scalability, maintainability, and efficient data handling.

<br>

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/abdulmueed22/NexusFarmProj.git
   ```
2. Open the solution in Visual Studio.
3. Set up the database using SQL Server Management Studio (SSMS).
4. Update database connection strings in the project's configuration files.
5. Build and run the application.

<br>

## Contribution
Contributions are welcome! Fork the repository, make improvements, and submit pull requests to enhance NexusFarm.
