using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace ExamenAWSConciertoMauricio.Helpers
{
    public static class HelperSecretManager
    {
        public static async Task<string> GetSecretAsync()
        {
            string secretName = "secreto-examen";
            string region = "us-east-1";
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };
            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }

            string secret = response.SecretString;
            return secret;
        }
    }
}
