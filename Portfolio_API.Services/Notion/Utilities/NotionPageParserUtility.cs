using System;
using System.Xml.Linq;
using Portfolio_API.DataTypes.Models.Notion;

namespace Portfolio_API.Services.Notion;

public static class NotionPageParserUtility
{
  public static List<PageCard> Parse(string markdown)
  {
    // Wrap root because input has multiple top-level nodes
    var xml = $"<root>{markdown}</root>";

    var doc = XDocument.Parse(xml);

    var cards = doc.Descendants("page")
        .Select(page =>
        {
          var url = (string)page.Attribute("url")! ?? "";

          var mentionDate = page.Descendants("mention-date").FirstOrDefault();

          var date = (string)mentionDate?.Attribute("start")! ?? "";

          var title = page.Value
                  .Replace("—", "")
                  .Trim();

          return new PageCard
          {
            Url = url,
            Date = date,
            Title = title
          };
        })
        .ToList();

    return cards;
  }
}
