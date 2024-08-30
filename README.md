SA Online Mart is an e-commerce platform designed to handle products, users, orders, and order items efficiently. This project demonstrates the use of ASP.NET Core with Entity Framework Core for database management and RESTful API development.

Project Overview
SA Online Mart is designed to provide an online shopping experience where users can browse products, place orders, and manage their shopping carts. It includes features for user authentication, product management, and order processing.

Setup Instructions
Follow these steps to set up and run the project on your local machine:

1. Clone the Repository
git clone https://github.com/kockubra12/SAOnlineMart.git

2.Navigate to the Project Directory
cd SAOnlineMart

3. Install Dependencies
Ensure you have .NET SDK installed. Run the following command to restore the project dependencies:
dotnet restore

4.Apply Migrations and Update the Database

Run the following command to apply Entity Framework Core migrations and update the database:
dotnet ef database update

5.Run the Application

Start the application using:
dotnet run

The application will be available at http://localhost:5000 for HTTP or https://localhost:5001 for HTTPS.

Usage
API Endpoints: The API documentation is available at /swagger (e.g., http://localhost:5000/swagger).
Authentication: Use JWT for user authentication. You will need to obtain a token by logging in and include it in the Authorization header of your requests.

Contributing

Contributions are welcome! To contribute:

1.Fork the repository.
2.Create a new branch (git checkout -b feature-branch).
3.Commit your changes (git commit -am 'Add new feature').
4.Push to the branch (git push origin feature-branch).
5.Create a new Pull Request on GitHub.

Issues and Bug Reporting
If you find any issues or bugs, please report them by creating an issue on the GitHub repository. Provide as much detail as possible to help us address the issue quickly.


