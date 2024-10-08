namespace AesGcmEncryptionServiceTests;

using AesGcmEncryptionService;
using System.Security.Cryptography;
using Xunit;

public class AesGcmEncryptionServiceTests
{
    private readonly IAesGcmEncryptionService _encryptionService;

    public AesGcmEncryptionServiceTests()
    {
        _encryptionService = new AesGcmEncryptionService();
    }

    [Fact]
    public void Encrypt_Decrypt_ShouldReturnOriginalPlainText()
    {
        // Arrange
        byte[] plainText = System.Text.Encoding.UTF8.GetBytes("Hello, AES-GCM!");
        byte[] key = GenerateRandomBytes(32); // AES-256 key size
        byte[] nonce = GenerateRandomBytes(12); // Recommended nonce size for GCM
        byte[] associatedData = System.Text.Encoding.UTF8.GetBytes("SampleAssociatedData");

        // Act
        byte[] cipherText = _encryptionService.Encrypt(plainText, key, nonce, associatedData);
        byte[] decryptedText = _encryptionService.Decrypt(cipherText, key, nonce, associatedData);

        // Assert
        Assert.Equal(plainText, decryptedText);
    }

    private static byte[] GenerateRandomBytes(int length)
    {
        byte[] randomBytes = new byte[length];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        return randomBytes;
    }
}
