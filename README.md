---

# 🛠️ Back End - Social Media API

This is the **Back-End REST API** for a Social Media App, built with [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) and [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/). It powers the core features of the platform, such as user authentication, post creation, commenting, and real-time notifications.


---
## 👉 Front-End: [Here](https://github.com/phuongle841/SocialMediaPlatformFrontend)

## 📁 Project Structure

```
backend/
├── Properties/                  # Project properties and settings
├── Configuration/              # Service configs (DB, JWT, CORS)
├── Controller/                 # API endpoints
├── Data/                       # DbContext, DAOs, DTOs
├── Migrations/                 # EF Core migrations
├── Models/                     # Entity models
└── Program.cs                  # Application entry point

Test/
├── Controller/                 # Controller unit tests
└── Repository/                 # Repository unit tests
```

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone git@github.com:your-username/social-media-backend.git
cd backend
```

### 2. Install Dependencies

Make sure you have the .NET SDK installed.

```bash
dotnet restore
```

### 3. Set Up Environment Variables

Create a `secrets.json` or configure your environment as needed. For example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
  },
  "Jwt": {
    "Key": "YourJWTSecretKey",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  }
}
```

> Alternatively, use `appsettings.Development.json` or `User Secrets` in .NET Core.

### 4. Run the Application

```bash
dotnet run
```

The API will be available at: [http://localhost:5000](http://localhost:5000)

---

## 🔑 Features

* 🔐 **JWT-based Authentication**
* 📝 **User Registration & Login**
* 🖼️ **Post Creation, Editing, Deletion**
* 💬 **Commenting & Likes**
* 🧑‍🤝‍🧑 **Follow/Unfollow Users**
* 📡 **Real-Time Notifications** (via SignalR)
* 🔒 **Role-Based Access Control**

---

## 🧹 Tech Stack

* **C#**
* **ASP.NET Core**
* **Entity Framework Core**
* **SQL Server**
* **JWT Authentication**
* **SignalR** (for real-time communication)

---

## 🧪 Testing

* ✅ **Unit Tests** written with `xUnit`
* 📦 Use Visual Studio **Test Explorer** or run:

```bash
dotnet test
```

---

## 🛠️ Environment Variables

Set the following environment variables or define them in your config file:

```
ConnectionStrings__DefaultConnection=YourDatabaseConnectionString
Jwt__Key=YourJWTSecretKey
Jwt__Issuer=YourIssuer
Jwt__Audience=YourAudience
```

> For development, you can also use `appsettings.Development.json` or .NET User Secrets.

---

## 📌 To Do / Future Improvements

* [ ] Enable and configure CORS properly
* [ ] Implement post suggestion algorithm
* [ ] Add full integration of SignalR for real-time features
* [ ] Add Swagger documentation
* [ ] Improve error handling and validation responses

---

## 🤝 Contribution

Currently not open for contributions, but suggestions are welcome! Feel free to open an issue if you have ideas or feedback.

---

Let me know if you want this as a downloadable `.md` file or need a version tailored for public repositories (e.g., with license and badges).
