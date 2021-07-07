using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DifficultyFile
{
	/// <summary>
	/// This field describes the version of the map format we are using.
	/// Currently, Beat Saber's map format is on version 2.0.0.
	/// </summary>
	[JsonPropertyName("_version")]
	public Version Version { get; set; }
	/// <summary>
	/// This is an array of Note objects for the map.
	/// </summary>
	[JsonPropertyName("_notes")]
	public List<Note> Notes { get; set; }
	/// <summary>
	/// This is an array of Obstacle objects for the map.
	/// </summary>
	[JsonPropertyName("_obstacles")]
	public List<Obstacle> Obstacles { get; set; }
	/// <summary>
	/// This is an array of Event objects for the map.
	/// </summary>
	[JsonPropertyName("_events")]
	public List<Event> Events { get; set; }
	/// <summary>
	/// This is an optional field that contains data unrelated to the official Beat Saber level format. If no custom data exists, this object should be removed entirely.
	/// The exact specifics of what goes in _customData is entirely dependent on community-created content that needs them.
	/// As such, we cannot list all _customData fields here.
	/// You will have to do your own searching throughout the Beat Saber community to find map editors, tools, or mods that use this _customData object.
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
}
