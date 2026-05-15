using API._Material.Dto;
using API._Material.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Material.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class MaterialController(IMaterialService materialService) : ControllerBase
{
    [HttpPost("CreateMaterial")]
    public async Task<ActionResult<Guid>> CreateMaterial([FromBody] CreateMaterialDto createMaterialDto, CancellationToken cancellationToken)
    {
        var materialId = await materialService.CreateMaterialAsync(createMaterialDto, cancellationToken);
        return Ok(materialId);
    }

    [HttpPut("UpdateMaterial/{materialId}")]
    public async Task<ActionResult> UpdateMaterial(Guid materialId, [FromBody] UpdateMaterialDto updateMaterialDto, CancellationToken cancellationToken)
    {
        await materialService.UpdateMaterialAsync(materialId, updateMaterialDto, cancellationToken);
        return NoContent();
    }

    [HttpGet("GetAllMaterials")]
    public async Task<ActionResult<List<MaterialDto>>> GetAllMaterials(CancellationToken cancellationToken)
    {
        var result = await materialService.GetAllMaterials(cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetMaterialById/{materialId}")]
    public async Task<ActionResult<MaterialDto>> GetMaterialById(Guid materialId, CancellationToken cancellationToken)
    {
        var result = await materialService.GetMaterialById(materialId, cancellationToken);
        return Ok(result);
    }
}

