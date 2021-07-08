using Sandbox;
using Sandbox.UI;

[UseTemplate]
public class MapEntry : Panel
{
	public Image Cover { get; set; }
	public Label SongName { get; set; }

	public Map Map;
	public MapEntry(Map m)
	{
		AddEventListener("onclick", () =>
		{
			MainMenu.Current.ShowMapMenu(Map);
		});
		StyleSheet.Load("/code/UI/MapEntry.scss");

		Map = m;

		var img = Sandbox.TextureLoader.Image.Load(FileSystem.Data.OpenRead("maps/" + m.Id + "/" + m.CoverImageFilename));
		Cover.Texture = img;

		SongName.Text = $"{Map.SongAuthorName} - {Map.SongName}";
	}
}
