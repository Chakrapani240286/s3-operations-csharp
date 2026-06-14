using S3BucketExample;

Console.Title = "S3 Bucket Example";

while (true)
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          S3 OPERATIONS");
    Console.WriteLine("=================================");
    Console.WriteLine("1.  Create Bucket");
    Console.WriteLine("2.  List Buckets");
    Console.WriteLine("3.  Delete Bucket");
    Console.WriteLine("4.  Upload File");
    Console.WriteLine("5.  List Files");
    Console.WriteLine("6.  Download File");
    Console.WriteLine("7.  Delete Object");
    Console.WriteLine("8.  Generate Presigned URL");
    Console.WriteLine("9.  Enable Versioning");
    Console.WriteLine("10. Get Versioning Status");
    Console.WriteLine("11. List Object Versions");
    Console.WriteLine("12. Download Specific Version");
    Console.WriteLine("13. Delete Specific Version");
    Console.WriteLine("0.  Exit");
    Console.WriteLine("=================================");

    Console.Write("Choice : ");

    if (!int.TryParse(Console.ReadLine(), out int option))
        continue;

    Console.WriteLine();

    switch (option)
    {
        case 1:
            Console.Write("Bucket Name : ");
            await S3Methods.CreateBucket(Console.ReadLine()!);
            break;

        case 2:
            await S3Methods.ListBuckets();
            break;

        case 3:
            Console.Write("Bucket Name : ");
            await S3Methods.DeleteBucket(Console.ReadLine()!);
            break;

        case 4:
            Console.Write("Bucket Name : ");
            string bucket = Console.ReadLine()!;

            Console.Write("File Path : ");
            string path = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string key = Console.ReadLine()!;

            await S3Methods.UploadFileAsync(bucket, key, path);
            break;

        case 5:
            Console.Write("Bucket Name : ");
            await S3Methods.ListFileAsync(Console.ReadLine()!);
            break;

        case 6:
            Console.Write("Bucket Name : ");
            string bucketDownload = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string keyDownload = Console.ReadLine()!;

            Console.Write("Download Folder : ");
            string folder = Console.ReadLine()!;

            await S3Methods.DownloadFileAsync(
                bucketDownload,
                keyDownload,
                folder);
            break;

        case 7:
            Console.Write("Bucket Name : ");
            string bucketDelete = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string keyDelete = Console.ReadLine()!;

            await S3Methods.DeleteObjectAsync(
                bucketDelete,
                keyDelete);
            break;

        case 8:
            Console.Write("Bucket Name : ");
            string bucketUrl = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string keyUrl = Console.ReadLine()!;

            S3Methods.GeneratePreSignedUrl(
                bucketUrl,
                keyUrl);
            break;

        case 9:
            Console.Write("Bucket Name : ");
            await S3Methods.EnableVersioning(
                Console.ReadLine()!);
            break;

        case 10:
            Console.Write("Bucket Name : ");
            await S3Methods.GetVersioningStatus(
                Console.ReadLine()!);
            break;

        case 11:
            Console.Write("Bucket Name : ");
            await S3Methods.ListObjectVersions(
                Console.ReadLine()!);
            break;

        case 12:
            Console.Write("Bucket Name : ");
            string bucketVersionDownload = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string keyVersionDownload = Console.ReadLine()!;

            Console.Write("Version Id : ");
            string versionIdDownload = Console.ReadLine()!;

            Console.Write("Download Folder : ");
            string downloadFolder = Console.ReadLine()!;

            await S3Methods.DownloadSpecificVersionAsync(
                bucketVersionDownload,
                keyVersionDownload,
                versionIdDownload,
                downloadFolder);
            break;

        case 13:
            Console.Write("Bucket Name : ");
            string bucketVersionDelete = Console.ReadLine()!;

            Console.Write("Object Key : ");
            string keyVersionDelete = Console.ReadLine()!;

            Console.Write("Version Id : ");
            string versionIdDelete = Console.ReadLine()!;

            await S3Methods.DeleteSpecificVersionAsync(
                bucketVersionDelete,
                keyVersionDelete,
                versionIdDelete);
            break;

        case 0:
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press ENTER to continue...");
    Console.ReadLine();
}