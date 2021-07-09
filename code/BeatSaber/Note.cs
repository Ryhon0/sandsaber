using System.Text.Json.Serialization;

// https://bsmg.wiki/mapping/map-format.html#notes-2
public class Note
{
	/// <summary>
	/// The time, in beats, where this object reaches the player.
	/// </summary>
	[JsonPropertyName("_time")]
	public float Time { get; set; }
	/// <summary>
	/// An integer number, from 0 to 3, which represents the column where this note is located.
	/// The far left column is located at index 0, and increases to the far right column located at index 3.
	/// </summary>
	[JsonPropertyName("_lineIndex")]
	public int LineIndex { get; set; }
	/// <summary>
	/// An integer number, from 0 to 2, which represents the layer where this note is located.
	/// The bottom most layer is located at layer 0, and inceases to the topmost layer located at index 2.
	/// </summary>
	[JsonPropertyName("_lineLayer")]
	public int LineLayer { get; set; }
	/// <summary>
	/// This indicates the type of note there is.
	/// Currently, there are 4 known types, but 1 remains unused
	/// </summary>
	[JsonPropertyName("_type")]
	public NoteType Type { get; set; }
	// This indicates the cut direction for the note
	[JsonPropertyName("_cutDirection")]
	public CutDirection CutDirection { get; set; }
	/// <summary>
	/// This is an optional field that contains data unrelated to the official Beat Saber level format. If no custom data exists, this object should be removed entirely.
	/// The exact specifics of what goes in _customData is entirely dependent on community-created content that needs them.
	/// As such, we cannot list all _customData fields here.
	/// You will have to do your own searching throughout the Beat Saber community to find map editors, tools, or mods that use this _customData object.
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#type
public enum NoteType
{
	Left = 0,
	Right = 1,
	Unused = 2,
	Bomb = 3
}

// https://bsmg.wiki/mapping/map-format.html#notes-2
public enum CutDirection
{
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3,

	UpLeft = 4,
	UpRight = 5,

	DownLeft = 6,
	DownRight = 7,

	Any = 8
}
