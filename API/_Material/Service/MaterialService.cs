using API._Material.Dto;
using API._Material.Repository;

namespace API._Material.Service;

public class MaterialService(IMaterialRepository materialRepository) : IMaterialService
{
    public async Task<Guid> CreateMaterialAsync(CreateMaterialDto createMaterialDto, CancellationToken cancellationToken = default)
    {
        return await materialRepository.CreateMaterialAsync(createMaterialDto, cancellationToken);
    }

    public async Task UpdateMaterialAsync(Guid materialId, UpdateMaterialDto updateMaterialDto, CancellationToken cancellationToken = default)
    {
        await materialRepository.UpdateMaterialAsync(materialId, updateMaterialDto, cancellationToken);
    }

    public async Task<List<MaterialDto>> GetAllMaterials(CancellationToken cancellationToken = default)
    {
        return await materialRepository.GetAllMaterials(cancellationToken);
    }

    public async Task<MaterialDto> GetMaterialById(Guid materialId, CancellationToken cancellationToken = default)
    {
        return await materialRepository.GetMaterialById(materialId, cancellationToken);
    }
}

