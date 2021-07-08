using System.Text.Json;

public class PascalCase : JsonNamingPolicy
{
	public override string ConvertName(string name)
		=> name;
}
