# News Management API

This is an API developed in C# using Entity Framework, designed for a news website. The system allows users to create and submit their own news articles, while an administrator is responsible for reviewing and approving or rejecting these submissions.

## Features

- **News Creation**: Users can create new news articles with titles, content, and categories.
- **Review and Approval**: An admin panel where administrators can view all submitted news articles and approve or reject them.
- **Public Viewing**: Only approved news articles will be displayed publicly for all users of the site.
- **Authentication and Authorization**: Implementation of authentication for users and administrators, ensuring that only authorized users can submit news and perform reviews.

## Technologies Used

- **C#**: The main programming language.
- **ASP.NET Core**: Framework for building the API.
- **Entity Framework**: ORM used for database interaction.
- **PostgreSQL**: Database used to store news and user information.

## How to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/RafaelPJosephino/GlobalInsightsTribuneApi.git
   cd GlobalInsightsTribuneApi
   ```

2. Install the dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Access the API at `http://localhost:5000` (or the configured port).

## Contribution

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for more details.
