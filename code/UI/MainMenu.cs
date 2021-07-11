using Sandbox;
using Sandbox.UI;
using System.Text.Json;
using System.Text.Json.Serialization;

[UseTemplate]
public partial class MainMenu : Panel
{
	public static MainMenu Current;

	public Label MapPathLabel { get; set; }
	public Panel MapList { get; set; }
	public MainMenu()
	{
		StyleSheet.Load("/code/UI/MainMenu.scss");
		LoadMaps();
		Current = this;

		MapPathLabel.Text = $"Maps are stored in '{FileSystem.Data.GetFullPath("/maps")}' as folders.\n" +
			"Visit BeastSaber.com to download maps";
	}

	void LoadMaps()
	{
		MapList.DeleteChildren();

		var folders = FileSystem.Data.FindDirectory("maps");
		foreach (var f in folders)
		{
			var infofile = "maps/" + f + "/Info.dat";
			if (FileSystem.Data.FileExists(infofile))
			{
				var json = FileSystem.Data.ReadAllText(infofile);
				var opts = new JsonSerializerOptions();
				opts.Converters.Add(new JsonStringEnumConverter(new PascalCase()));

				var map = JsonSerializer.Deserialize<Map>(json, opts);
				map.Id = f;
				MapList.AddChild(new MapEntry(map));
			}
		}
	}
	public override void OnHotloaded()
	{
		base.OnHotloaded();
		LoadMaps();
	}

	public void Show()
	{
		SetClass("hidden", false);
	}

	public void Hide()
	{
		SetClass("hidden", true);
	}
}
