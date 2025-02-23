# Implementing Clean Architecture with .NET Core and AWS S3 Integration

## 📌 About the Project

**CleanArchitecture.S3FileGateway** is a project based on **Clean Architecture** principles, designed to act as gateway for file manipulation in **AWS S3**. It provides a clean and organized abstraction to facilitate interaction with S3 without coupling business logic directly to AWS API calls.

## 🚀 Technologies Used

- **.NET Core / .NET 6+**

- **AWS SDK for .NET**

## 📦 Project Structure

The project follows Clean Architecture and is divided into:

```
📂 CleanArchitecture.S3FileGateway
├── 📂 Application        # Business rules and use cases
├── 📂 Domain             # Entities and interfaces
├── 📂 Infrastructure     # External service implementations (S3, database, etc.)
├── 📂 Presentation       # API or communication interface
```

## 🔧 Setup and Usage

### 1️⃣ **Cloning the Repository**
```sh
git clone https://github.com/flavio-santos-ti/CleanArchitecture.S3FileGateway.git
cd CleanArchitecture.S3FileGateway
```

### 2️⃣ **Configuring AWS Credentials**
Make sure to set up your AWS credentials correctly in the **appsettings.json** file or as environment variables:

```json
{
  "AWS": {
    "AccessKey": "YOUR_ACCESS_KEY",
    "SecretKey": "YOUR_SECRET_KEY",
    "Region": "us-east-1",
    "BucketName": "your-bucket"
  }
}
```

> ⚠️ **Important:** The `appsettings.Development.json` file is ignored by `.gitignore` to prevent credential leaks.

### 3️⃣ **Running the Project**
```sh
dotnet run --project src/Presentation
```

### 4️⃣ **Running Tests**
```sh
dotnet test
```

---

✉️ **Contact:** If you have any questions or suggestions, feel free to open an issue or contact me via [LinkedIn](https://www.linkedin.com/in/flavio-santos-ti/).

