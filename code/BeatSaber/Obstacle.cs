using System.Text.Json.Serialization;

public class Obstacle
{
	/// <summary>
	/// The time, in beats, where this object reaches the player.
	/// </summary>
	[JsonPropertyName("_time")]
	public float Time { get; set; }
	/// <summary>
	/// An integer number, from 0 to 3, which represents the column where the left side of the obstacle is located.
	/// The far left column is located at index 0, and increases to the far right column located at index 3.
	/// </summary>
	[JsonPropertyName("_lineIndex")]
	public int LineIndex { get; set; }
	/// <summary>
	/// An integer number which represents the state of the obstacle
	/// </summary>
	[JsonPropertyName("_type")]
	public ObstacleType Type { get; set; }
	/// <summary>
	/// The time, in beats, that the obstacle extends for. While Duration can go into negative numbers, be aware that this has some unintended effects.
	/// </summary>
	[JsonPropertyName("_duration")]
	public float Duration { get; set; }
	/// <summary>
	/// How many columns the obstacle takes up.
	/// A Width of 4 will mean that this wall will extend the entire playable grid.
	/// While Width can go into negative numbers, be aware that this has some unintended effects.
	/// </summary>
	[JsonPropertyName("_width")]
	public int Width { get; set; }
	/// <summary>
	/// This is an optional field that contains data unrelated to the official Beat Saber level format.
	/// If no custom data exists, this object should be removed entirely.
	/// The exact specifics of what goes in _customData is entirely dependent on community-created content that needs them.
	/// As such, we cannot list all CustomData fields here.
	/// You will have to do your own searching throughout the Beat Saber community to find map editors, tools, or mods that use this CustomData object.
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#type-2
public enum ObstacleType
{
	FullHeightWall = 0,
	CrouchWall = 1
}
