namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static IReadOnlyList<string> BuildProductionNotes()
    {
        return
        [
            "Demo hiĂ¡Â»â€¡n Ă†Â°u tiÄ‚Âªn test Postman nÄ‚Âªn repository runtime lÄ‚Â  in-memory, dĂ¡Â»Â¯ liĂ¡Â»â€¡u sĂ¡ÂºÂ½ reset khi chĂ¡ÂºÂ¡y lĂ¡ÂºÂ¡i app.",
            "AppDbContext vÄ‚Â  migrations Ă„â€˜Ä‚Â£ sĂ¡ÂºÂµn sÄ‚Â ng Ă„â€˜Ă¡Â»Æ’ tĂ¡ÂºÂ¡o database, nhĂ†Â°ng chĂ†Â°a thay runtime sang EF repository thĂ¡ÂºÂ­t.",
            "Auth Ă„â€˜ang lÄ‚Â  token demo base64, chĂ†Â°a phĂ¡ÂºÂ£i JWT/refresh token/role policy production.",
            "AI chat lÄ‚Â  mock theo dĂ¡Â»Â¯ liĂ¡Â»â€¡u OMS mĂ¡ÂºÂ«u, chĂ†Â°a tÄ‚Â­ch hĂ¡Â»Â£p dĂ¡Â»â€¹ch vĂ¡Â»Â¥ AI thĂ¡ÂºÂ­t.",
            "Upload POD/export bÄ‚Â¡o cÄ‚Â¡o Ă„â€˜ang lĂ†Â°u URL/file giĂ¡ÂºÂ£ lĂ¡ÂºÂ­p, chĂ†Â°a lĂ†Â°u file vĂ¡ÂºÂ­t lÄ‚Â½ hoĂ¡ÂºÂ·c cloud storage.",
            "UI web Ă„â€˜Ä‚Â£ cÄ‚Â³ mÄ‚Â n hÄ‚Â¬nh chÄ‚Â­nh, nhĂ†Â°ng backend API hiĂ¡Â»â€¡n Ă„â€˜Ă¡ÂºÂ§y Ă„â€˜Ă¡Â»Â§ hĂ†Â¡n UI Ă„â€˜Ă¡Â»Æ’ test bĂ¡ÂºÂ±ng Postman."
        ];
    }
}

