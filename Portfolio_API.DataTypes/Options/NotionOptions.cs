using System;

namespace Portfolio_API.DataTypes.Options;

public class NotionOptions
{
  public string Token {get; set;} = string.Empty;
  public string Version {get; set;} = "2026-03-11";
}
