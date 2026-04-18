using System;

namespace Portfolio_API.DataTypes.Models.Notion;

public class PageMarkdown
{
  public string Object { get; set; }  = string.Empty;
  public string Id { get; set; } = string.Empty;      
  public string Markdown { get; set; } = string.Empty;
  public bool Truncated { get; set; }
  public List<string> UnknownBlockIds { get; set; } = new List<string>();
  public string RequestId { get; set; } = string.Empty;

}
