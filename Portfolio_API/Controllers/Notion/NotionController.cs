using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.Notion;
using Portfolio_API.Services.Notion;

namespace Portfolio_API.Controllers.Notion
{
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName= "v2")] 
    [ApiController]
    public class NotionController : ControllerBase
    {
        private readonly NotionClientService _notionClient;
        public NotionController(NotionClientService notionClient)
        {
            _notionClient = notionClient;
        }

        [HttpGet("query/{pageId}")]
        public async Task<ActionResult<PageCard>> QueryPage(string pageId)
        {
            var result = await _notionClient.QueryPageAsync(pageId);
            return Ok(result); // returns raw JSON string
        }

    }
}
