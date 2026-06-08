namespace QuanLyDonHangNoiBo.Application.Features.Demo.Common;

public sealed record DemoReadinessDto(
    DateTimeOffset CheckedAt,
    string RuntimeMode,
    TenantDto Tenant,
    IReadOnlyList<DemoSeedCountDto> SeedData,
    IReadOnlyList<DemoModuleStatusDto> Modules,
    IReadOnlyList<DemoWorkflowStepDto> Workflow,
    IReadOnlyList<string> PostmanSmokeTestEndpoints,
    IReadOnlyList<string> ProductionNotes);


