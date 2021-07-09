using Sandbox;
using Sandbox.UI;
using System.Linq;

partial class MainMenu
{
	public Label MapMenuSongName { get; set; }

	Map SelectedMap;

	public void ShowMapMenu(Map map)
	{
		SelectedMap = map;

		if (map == null)
		{
			MapMenuSongName.Parent.SetClass("hidden", true);
			return;
		}

		MapMenuSongName.Text = $"{map.SongAuthorName} - {map.SongName}";
		MapMenuSongName.Parent.SetClass("hidden", false);
	}

	public void StartSelectedMap()
	{
		Hide();

		ConsoleSystem.Run($"saber_map", SelectedMap.Id,
			SelectedMap.DifficultyBeatmapSets.First().DifficultyBeatmaps.First().BeatmapFilename);
	}
}
