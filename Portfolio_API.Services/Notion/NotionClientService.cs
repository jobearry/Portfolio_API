using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Options;
using Portfolio_API.DataTypes.Models.Notion;
using Portfolio_API.DataTypes.Options;

namespace Portfolio_API.Services.Notion;

public interface INotionClientService
{
  Task<List<PageCard>> QueryPageAsync(string pageId);
}
public class NotionClientService: INotionClientService
{
  private readonly HttpClient _httpClient;
  private readonly NotionOptions _opts;

  public NotionClientService(HttpClient httpClient, IOptions<NotionOptions> opts)
  {
    _httpClient = httpClient;
    _opts = opts.Value;
    _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _opts.Token);
    _httpClient.DefaultRequestHeaders.Add("Notion-Version", _opts.Version);
  }

  public async Task<List<PageCard>> QueryPageAsync(string pageId)
{
    var response = await _httpClient.GetAsync(
        $"https://api.notion.com/v1/pages/{pageId}/markdown"
    );

    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<PageMarkdown>();

    if (result is null)
        throw new InvalidOperationException("Failed to deserialize Notion page markdown.");

    var parsedResult = NotionPageParserUtility.Parse(result.Markdown);
    return parsedResult;
}

}
