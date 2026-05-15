using API._Material.Dto;
using API.Infrastructure;
using API.Shared;
using Microsoft.EntityFrameworkCore;

namespace API._Material.Repository;

public class MaterialRepository(DshDatabaseContext context) : IMaterialRepository
{
    public async Task<Guid> CreateMaterialAsync(CreateMaterialDto createMaterialDto, CancellationToken cancellationToken = default)
    {
        var newMaterial = new Material();
        newMaterial.HandleCommand(createMaterialDto);

        await context.Materials.AddAsync(newMaterial, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newMaterial.Id;
    }

    public async Task UpdateMaterialAsync(Guid materialId, UpdateMaterialDto updateMaterialDto, CancellationToken cancellationToken = default)
    {
        var material = await context.Materials
            .Include(m => m.Teacher)
            .Include(m => m.Student)
            .FirstOrDefaultAsync(m => m.Id == materialId, cancellationToken);

        if (material is null) throw new KeyNotFoundException($"Kein Material mit der Id vorhanden: {materialId}");

        material.HandleCommand(updateMaterialDto);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<MaterialDto>> GetAllMaterials(CancellationToken cancellationToken = default)
    {
        var materials = await context.Materials
            .Include(m => m.Teacher)
            .Include(m => m.Student)
            .ToListAsync(cancellationToken);

        return materials.Select(m => m.ToDto()).ToList();
    }

    public async Task<MaterialDto> GetMaterialById(Guid materialId, CancellationToken cancellationToken = default)
    {
        var material = await context.Materials
            .Include(m => m.Teacher)
            .Include(m => m.Student)
            .FirstOrDefaultAsync(m => m.Id == materialId, cancellationToken);

        if (material is null) throw new KeyNotFoundException($"Kein Material mit der Id vorhanden: {materialId}");

        return material.ToDto();
    }
}



