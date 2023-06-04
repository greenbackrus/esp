namespace espverbs.Server.Helpers
{
    public class GeneralHelpers
    {
        public static string EncodeString(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashedInputBytes = System.Security.Cryptography.SHA512.HashData(bytes);
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
