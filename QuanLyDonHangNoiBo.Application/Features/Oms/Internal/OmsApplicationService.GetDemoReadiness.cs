namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    // BĂ¡ÂºÂ£ng kiĂ¡Â»Æ’m tra demo giÄ‚Âºp test nhanh bĂ¡ÂºÂ±ng Postman: nhÄ‚Â¬n mĂ¡Â»â„¢t response lÄ‚Â  biĂ¡ÂºÂ¿t dĂ¡Â»Â¯ liĂ¡Â»â€¡u mĂ¡ÂºÂ«u,
    // module API, bĂ¡Â»â„¢ phĂ¡ÂºÂ­n sĂ¡Â»Â­ dĂ¡Â»Â¥ng vÄ‚Â  luĂ¡Â»â€œng nghiĂ¡Â»â€¡p vĂ¡Â»Â¥ nÄ‚Â o Ă„â€˜Ä‚Â£ cÄ‚Â³.
    public DemoReadinessDto GetDemoReadiness(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var tenant = _repository.Tenants.First(item => item.Id == resolvedTenantId);

        return new DemoReadinessDto(
            DateTimeOffset.UtcNow,
            "Demo in-memory cho Postman/UI; AppDbContext + migrations Ă„â€˜Ä‚Â£ cÄ‚Â³ Ă„â€˜Ă¡Â»Æ’ tĂ¡ÂºÂ¡o schema SQL Server.",
            ToTenantDto(tenant),
            BuildSeedCounts(resolvedTenantId),
            BuildModuleStatuses(),
            BuildDemoWorkflow(),
            BuildSmokeTestEndpoints(),
            BuildProductionNotes());
    }
}

