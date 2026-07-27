using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Services.Application.HashPassword
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32;  // 256 bit

        public PasswordHasher(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public string Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Options.Iterations,
                HashAlgorithmName.SHA256);

            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{Options.Iterations}.{salt}.{key}";
        }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(password))
                return (false, false);

            var parts = hash.Split('.', 3);
            if (parts.Length != 3)
                return (false, false);

            if (!int.TryParse(parts[0], out var iterations))
                return (false, false);

            byte[] salt;
            byte[] key;
            try
            {
                salt = Convert.FromBase64String(parts[1]);
                key = Convert.FromBase64String(parts[2]);
            }
            catch (FormatException)
            {
                return (false, false);
            }

            var needsUpgrade = iterations != Options.Iterations;

            using var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(KeySize);

            // Timing-safe comparison to mitigate timing attacks
            var verified = CryptographicOperations.FixedTimeEquals(keyToCheck, key);

            return (verified, needsUpgrade);
        }
    }
}
