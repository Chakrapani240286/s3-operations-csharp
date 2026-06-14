# s3-operations-csharp

A beginner-friendly C# console application demonstrating Amazon S3 operations using the AWS SDK for .NET. This project covers bucket management, file upload/download, object deletion, pre-signed URLs, and object versioning with practical examples.

## Features

- Create Bucket
- List Buckets
- Delete Bucket
- Upload Files
- List Objects
- Download Files
- Delete Objects
- Generate Pre-Signed URLs
- Enable Bucket Versioning
- Check Versioning Status
- List Object Versions
- Download Specific Versions
- Delete Specific Versions

## Technologies Used

- C#
- .NET
- Amazon S3
- AWS SDK for .NET
- Async/Await

## Prerequisites

- .NET 8 SDK
- AWS Account or LocalStack/Floci
- AWS CLI configured

## Install Package

```bash
dotnet add package AWSSDK.S3
```

## Project Structure

```text
S3BucketExample
│
├── Program.cs
├── S3Methods.cs
├── S3BucketExample.csproj
└── README.md
```

## Menu

```text
=================================
          S3 OPERATIONS
=================================
1.  Create Bucket
2.  List Buckets
3.  Delete Bucket
4.  Upload File
5.  List Files
6.  Download File
7.  Delete Object
8.  Generate Presigned URL
9.  Enable Versioning
10. Get Versioning Status
11. List Object Versions
12. Download Specific Version
13. Delete Specific Version
0.  Exit
=================================
```

## Example Usage

### Create Bucket

```csharp
await S3Methods.CreateBucket("my-first-bucket");
```

### Upload File

```csharp
await S3Methods.UploadFileAsync(
    "my-first-bucket",
    "sample.txt",
    @"D:\Files\sample.txt");
```

### List Objects

```csharp
await S3Methods.ListFileAsync(
    "my-first-bucket");
```

### Download File

```csharp
await S3Methods.DownloadFileAsync(
    "my-first-bucket",
    "sample.txt",
    @"D:\Downloads");
```

### Delete Object

```csharp
await S3Methods.DeleteObjectAsync(
    "my-first-bucket",
    "sample.txt");
```

### Generate Pre-Signed URL

```csharp
S3Methods.GeneratePreSignedUrl(
    "my-first-bucket",
    "sample.txt");
```

### Enable Versioning

```csharp
await S3Methods.EnableVersioning(
    "my-first-bucket");
```

### Check Versioning Status

```csharp
await S3Methods.GetVersioningStatus(
    "my-first-bucket");
```

### List Object Versions

```csharp
await S3Methods.ListObjectVersions(
    "my-first-bucket");
```

### Download Specific Version

```csharp
await S3Methods.DownloadSpecificVersionAsync(
    "my-first-bucket",
    "sample.txt",
    "VERSION_ID",
    @"D:\Downloads");
```

### Delete Specific Version

```csharp
await S3Methods.DeleteSpecificVersionAsync(
    "my-first-bucket",
    "sample.txt",
    "VERSION_ID");
```

## Sample Workflow

1. Create a bucket.
2. Upload a file.
3. Enable versioning.
4. Upload the same file again.
5. List object versions.
6. Download a previous version.
7. Generate a pre-signed URL.
8. Delete a specific version.
9. Delete the object.
10. Delete the bucket.

## Learning Objectives

This project helps developers understand:

- Amazon S3 Bucket Management
- Object Operations
- File Upload and Download
- Object Versioning
- Pre-Signed URLs
- AWS SDK for .NET
- Async and Await Programming

## Suitable For

- AWS Beginners
- .NET Developers
- AWS Interview Preparation
- Hands-on Amazon S3 Practice

## Future Enhancements

- Copy Object
- Move Object
- Multipart Upload
- Batch Delete
- Bucket Tags
- Object Metadata
- Server-Side Encryption
- Lifecycle Rules
- Transfer Utility
- Bucket Policies

## License

This project is intended for learning and educational purposes.
