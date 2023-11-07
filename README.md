# Backend Week 1 Task - Quote of the Day REST API

This repository contains the solution for the **Back End Week 1 Task**, which involves building a REST API for providing users with a daily "Quote of the Day" message. Below are the details of the task:

## Task Description

Develop an API system that allows users to access a random "Quote of the Day." The API should provide the following functionalities:

- **Get a Random Quote**: Users can request a random quote.
- **Add a New Quote**: Users can add new quotes to the database.
- **Update a Quote**: Users can edit and update existing quotes.
- **Delete a Quote**: Users can remove a quote from the database.
- **Search by Author (Optional)**: Users can search for quotes by the name of the author (optional feature).

## Technologies Used

- **Programming Language**: C#
- **Framework**: ASP.NET MVC
- **Database**: MS-SQL

## Project Structure

The project is organized as follows:

- **Controllers**: Contains the API endpoints for retrieving, adding, updating, and deleting quotes.
- **Models**: Defines the data models used within the application.
- **Views**: In an API project, views are not used as in traditional MVC applications. Instead, this directory may contain documentation or Swagger UI for API testing.
- **Services**: Contains the business logic for managing quotes and interacting with the database.
- **Repositories**: Manages the data access to the database.
- **App_Start**: Configuration files and settings.
- **Scripts**: Front-end scripts (if applicable).
- **Styles**: CSS files (if applicable).

## Getting Started

Follow these steps to set up and run the project:

1. **Clone the Repository**: Use the `git clone` command to clone this repository to your local machine.

2. **Database Setup**: Create the database and configure the connection string in the `web.config` or an environment-specific configuration file.

3. **Build and Run**: Build the project and start the application.

4. **API Endpoints**: Access the API endpoints to interact with the Quote of the Day system.

## API Endpoints

- `GET /api/quote`: Get a random quote of the day.
- `POST /api/quote`: Add a new quote.
- `PUT /api/quote/{id}`: Update an existing quote.
- `DELETE /api/quote/{id}`: Delete a quote by its ID.
- `GET /api/quote?author={authorName}` (Optional): Search for quotes by the author's name.

## Contributors

- Lukesh Bahurupi

Feel free to contribute to this project by creating pull requests and improving the features or documentation.

Thank you for your interest in the Back End Week 1 Task - Quote of the Day REST API project. If you have any questions or need further information, please don't hesitate to reach out.

Happy coding! 🚀
