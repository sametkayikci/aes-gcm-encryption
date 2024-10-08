
# AES-GCM Encryption and Decryption in .NET 8

This repository contains an implementation of AES-GCM NoPadding encryption and decryption in .NET 8. The project follows SOLID principles and includes unit tests written using xUnit.

## Table of Contents
- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Testing](#testing)
- [Contributing](#contributing)

## Introduction
AES-GCM (Galois/Counter Mode) is a widely used encryption algorithm that provides both confidentiality and integrity. This project implements a service for performing AES-GCM encryption and decryption, ensuring SOLID principles by defining the `IAesGcmEncryptionService` interface.

## Project Structure
- `IAesGcmEncryptionService.cs` - Defines the contract for AES-GCM encryption and decryption services.
- `AesGcmEncryptionService.cs` - Implements the AES-GCM encryption and decryption logic.
- `AesGcmEncryptionServiceTests.cs` - Contains xUnit tests for the encryption service.
- `Program.cs` - Entry point for the .NET project (if needed).
- `README.md` - Project documentation (this file).

## Features
- AES-GCM NoPadding encryption and decryption.
- Supports 256-bit AES keys.
- Handles nonce and associated data for additional security.
- Designed with SOLID principles in mind.
- Unit tests using xUnit.

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/aes-gcm-encryption.git
   ```
2. Navigate to the project directory:
   ```bash
   cd aes-gcm-encryption
   ```
3. Restore the .NET dependencies:
   ```bash
   dotnet restore
   ```

## Usage
You can use the `AesGcmEncryptionService` to perform AES-GCM encryption and decryption as follows:

```csharp
// Example of using IAesGcmEncryptionService
IAesGcmEncryptionService encryptionService = new AesGcmEncryptionService();

// Define key, nonce, and associated data
byte[] key = GenerateRandomBytes(32);  // 256-bit key
byte[] nonce = GenerateRandomBytes(12); // 12 bytes nonce
byte[] associatedData = Encoding.UTF8.GetBytes("AssociatedData");
byte[] plainText = Encoding.UTF8.GetBytes("SensitiveData");

// Encrypt
byte[] cipherText = encryptionService.Encrypt(plainText, key, nonce, associatedData);

// Decrypt
byte[] decryptedText = encryptionService.Decrypt(cipherText, key, nonce, associatedData);
```

### Generating Random Bytes
Helper function to generate secure random bytes:
```csharp
private static byte[] GenerateRandomBytes(int length)
{
    byte[] randomBytes = new byte[length];
    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomBytes);
    }
    return randomBytes;
}
```

## Testing
The project includes unit tests written using xUnit. To run the tests:

```bash
dotnet test
```

Ensure that all tests pass before using the service in production.

## Contributing
If you would like to contribute to this project, please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.
