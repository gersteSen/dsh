namespace API.Settings;

public sealed class StorageboxSettings
{
    public required string ServiceUrl { get; set; }
    public required string AccessKey { get; set; }
    public required string SecretKey { get; set; }
    public required string BucketName { get; set; }
    public required string ArchivePath { get; set; }
    public bool ForcePathStyle { get; set; }   
}