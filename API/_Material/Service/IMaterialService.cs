using API._Material.Dto;

namespace API._Material.Service;

public interface IMaterialService
{
    Task<Guid> CreateMaterialAsync(CreateMaterialDto createMaterialDto, CancellationToken cancellationToken = default);
    Task UpdateMaterialAsync(Guid materialId, UpdateMaterialDto updateMaterialDto, CancellationToken cancellationToken = default);
    Task<List<MaterialDto>> GetAllMaterials(CancellationToken cancellationToken = default);
    Task<MaterialDto> GetMaterialById(Guid materialId, CancellationToken cancellationToken = default);
}

