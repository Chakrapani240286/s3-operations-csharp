using Amazon.S3;
using Amazon.S3.Model;

namespace S3BucketExample
{
    public static class S3Methods
    {
        private static readonly AmazonS3Client _client = new AmazonS3Client();

        public static async Task CreateBucket(string bucketName)
        {
            Console.WriteLine("Creating bucket...");

            await _client.PutBucketAsync(new PutBucketRequest
            {
                BucketName = bucketName
            });

            Console.WriteLine("Bucket created successfully.");
        }

        public static async Task ListBuckets()
        {
            Console.WriteLine("\nBuckets:");
            var response = await _client.ListBucketsAsync();

            foreach (var bucket in response.Buckets)
            {
                Console.WriteLine(bucket.BucketName);
            }
        }

        public static async Task DeleteBucket(string bucketName)
        {
            await _client.DeleteBucketAsync(new DeleteBucketRequest
            {
                BucketName = bucketName
            });

            Console.WriteLine("Bucket deleted.");
        }

        public static async Task UploadFileAsync(
            string bucketName,
            string key,
            string filePath)
        {
            await _client.PutObjectAsync(new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                FilePath = filePath
            });

            Console.WriteLine($"Uploaded: {key}");
        }

        public static async Task ListFileAsync(string bucketName)
        {
            var response = await _client.ListObjectsAsync(new ListObjectsRequest
            {
                BucketName = bucketName
            });

            Console.WriteLine();

            foreach (var item in response.S3Objects)
            {
                Console.WriteLine($"{item.Key} ({item.Size} bytes)");
            }
        }

        public static async Task DownloadFileAsync(
            string bucketName,
            string key,
            string downloadFolder)
        {
            using var response = await _client.GetObjectAsync(
                bucketName,
                key);

            Directory.CreateDirectory(downloadFolder);

            string filePath = Path.Combine(downloadFolder, key);

            await response.WriteResponseStreamToFileAsync(
                filePath,
                false,
                CancellationToken.None);

            Console.WriteLine($"Downloaded to {filePath}");
        }

        public static async Task DeleteObjectAsync(
            string bucketName,
            string key)
        {
            await _client.DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = key
            });

            Console.WriteLine("Object deleted.");
        }

        public static void GeneratePreSignedUrl(
            string bucketName,
            string key)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            string url = _client.GetPreSignedURL(request);

            Console.WriteLine();
            Console.WriteLine("PreSigned URL");
            Console.WriteLine("----------------------");
            Console.WriteLine(url);
        }

        public static async Task EnableVersioning(string bucketName)
        {
            await _client.PutBucketVersioningAsync(
                new PutBucketVersioningRequest
                {
                    BucketName = bucketName,
                    VersioningConfig = new S3BucketVersioningConfig
                    {
                        Status = VersionStatus.Enabled
                    }
                });

            Console.WriteLine("Versioning enabled.");
        }

        public static async Task GetVersioningStatus(string bucketName)
        {
            var response = await _client.GetBucketVersioningAsync(
                new GetBucketVersioningRequest
                {
                    BucketName = bucketName
                });

            Console.WriteLine();
            Console.WriteLine($"Versioning Status : {response.VersioningConfig.Status}");
        }

        public static async Task ListObjectVersions(string bucketName)
        {
            var response = await _client.ListVersionsAsync(
                new ListVersionsRequest
                {
                    BucketName = bucketName
                });

            Console.WriteLine();
            Console.WriteLine("Versions");
            Console.WriteLine("-------------------------");

            foreach (var version in response.Versions)
            {
                Console.WriteLine(
                    $"Key : {version.Key}");
                Console.WriteLine(
                    $"Version Id : {version.VersionId}");
                Console.WriteLine(
                    $"Latest : {version.IsLatest}");
                Console.WriteLine();
            }
        }

        public static async Task DownloadSpecificVersionAsync(
            string bucketName,
            string key,
            string versionId,
            string downloadFolder)
        {
            using var response = await _client.GetObjectAsync(
                new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    VersionId = versionId
                });

            Directory.CreateDirectory(downloadFolder);

            string filePath = Path.Combine(downloadFolder, key);

            await response.WriteResponseStreamToFileAsync(
                filePath,
                false,
                CancellationToken.None);

            Console.WriteLine($"Downloaded version {versionId}");
        }

        public static async Task DeleteSpecificVersionAsync(
            string bucketName,
            string key,
            string versionId)
        {
            await _client.DeleteObjectAsync(
                new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    VersionId = versionId
                });

            Console.WriteLine("Specific version deleted.");
        }
    }
}