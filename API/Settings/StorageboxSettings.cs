namespace API.Settings;

public sealed class StorageboxSettings
{
    public string ServiceUrl { get; set; }
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string BucketName { get; set; }
    public string ArchivePath { get; set; }
    public bool ForcePathStyle { get; set; }   
}