using API._Lesson;
using API._Material.Dto;
using API._Student;
using API._Teacher;

namespace API._Material;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Filetype { get; set; } = string.Empty;
    public double? Filesize { get; set; }
    public string Filesource { get; set; } = string.Empty;
    public Guid? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public Guid? StudentId { get; set; }
    public Student? Student { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public void HandleCommand(CreateMaterialDto cmd)
    {
        CreateMaterial(cmd);
    }

    public void HandleCommand(UpdateMaterialDto cmd)
    {
        UpdateMaterial(cmd);
    }

    private void CreateMaterial(CreateMaterialDto cmd)
    {
        Id = Guid.NewGuid();
        Name = cmd.Name;
        Description = cmd.Description;
        Filetype = cmd.Filetype;
        Filesize = cmd.Filesize;
        Filesource = cmd.Filesource;
        TeacherId = cmd.TeacherId ?? null;
        StudentId = cmd.StudentId ?? null;
        CreatedAt = DateTime.UtcNow;
    }

    private void UpdateMaterial(UpdateMaterialDto cmd)
    {
        Name = cmd.Name;
        Description = cmd.Description;
        Filetype = cmd.Filetype;
        Filesize = cmd.Filesize;
        Filesource = cmd.Filesource;
        TeacherId = cmd.TeacherId ?? null;
        StudentId = cmd.StudentId ?? null;
        UpdatedAt = DateTime.UtcNow;
    }
}