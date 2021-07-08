using System.Collections.Generic;
using System.Text.Json.Serialization;

public class CustomData
{
}

// https://bsmg.wiki/mapping/map-format.html#base-object
public class Map
{
	/// <summary>
	/// Name of the directory the map is in
	/// </summary>
	public string Id;
	/// <summary>
	/// This field describes the version of the map format we are using. Currently, Beat Saber's map format is on version 2.0.0.
	/// </summary>
	[JsonPropertyName("_version")]
	public string Version { get; set; }
	/// <summary>
	/// This field describes the name of your song.
	/// </summary>

	[JsonPropertyName("_songName")]
	public string SongName { get; set; }
	/// <summary>
	/// This field describes any additional titles that could go into your song. These can include the following:
	/// Additional artists(Such as featured artists)
	/// Any variation in production(Song remix, VIP, etc.)
	/// </summary>

	[JsonPropertyName("_songSubName")]
	public string SongSubName { get; set; }
	/// <summary>
	/// This field describes the main artist, group, band, brand, etc. for the song.
	/// </summary>

	[JsonPropertyName("_songAuthorName")]
	public string SongAuthorName { get; set; }
	/// <summary>
	/// This field describes the person who created the map. That's you! Or, whoever makes a map using your tool or level editor.
	/// </summary>
	[JsonPropertyName("_levelAuthorName")]
	public string LevelAuthorName { get; set; }
	/// <summary>
	/// This describes the Beats Per Minute (BPM) of your song. This is a floating point number, so decimal BPMs are supported.
	/// </summary>
	[JsonPropertyName("_beatsPerMinute")]
	public int BeatsPerMinute { get; set; }
	/// <summary>
	/// This and ShufflePeriod are uncommon in the community.
	/// If your song has "swing" in it, where some beats in a measure are intentionally offset from the rest, you can correct potential timing issues in your map by utilizing _shuffle and _shufflePeriod.
	/// Shuffle indicates how far objects will move when they are determined to be on a swing beat.
	/// A positive value means they will be shifted forward in time, and a negative value means they will be shifted back in time.
	/// The total amount they will be offset by is described in _shufflePeriod, since they both work together to produce that value
	/// </summary>
	[JsonPropertyName("_shuffle")]
	public int Shuffle { get; set; }
	/// <summary>
	/// ShufflePeriod is used to determine when a swing beat will occur. More specifically, it is the time (in beats) where a swing beat will occur.
	/// But unfortunately, it's more complicated than this. Beat Saber alternates between a swing beat and a non swing beat using this value.
	/// For example, let's assume you have a _shufflePeriod of 0.25.
	/// This tells Beat Saber that, every 0.25 beats, it will alternate between a swing beat and a non swing beat, and will apply an offset if it lands on a swing beat.
	/// The offset value that will be applied to objects on a swing beat is approximately equal to Shuffle * ShufflePeriod beats.
	/// To hopefully help better understand this, here is a table of beats, whether or not they are on a swing beat, and the actual beat objects at those times will spawn in at.
	/// For this example, we will assume that _shuffle is 0.2, and _shufflePeriod is 0.25.
	///
	/// Beat from Map File	Is Swing Beat?	Resulting Beat
	/// 0					No				0
	/// 0.25				Yes				0.3
	/// 0.5					No				0.5
	/// 0.75				Yes				0.8
	/// 1					No				1
	/// 1.25				Yes				1.3
	/// 1.5					No				1.5
	/// 1.75				Yes				1.8
	/// </summary>
	[JsonPropertyName("_shufflePeriod")]
	public float ShufflePeriod { get; set; }
	/// <summary>
	/// This controls the start time (in seconds) for the in-game preview of your map. This is a floating point number, so decimals are supported.
	/// </summary>
	[JsonPropertyName("_previewStartTime")]
	public float PreviewStartTime { get; set; }
	/// <summary>
	/// This controls the duration (in seconds) of the in-game preview of your map. This is a floating point number, so decimals are supported.
	/// </summary>
	[JsonPropertyName("_previewDuration")]
	public int PreviewDuration { get; set; }
	/// <summary>
	/// This is the local location to your map's audio file.
	/// The standard practice is to have every map file in the same directory, so in most cases, this is just the name and extension for your audio file (For example, song.ogg).
	/// </summary>
	[JsonPropertyName("_songFilename")]
	public string SongFilename { get; set; }
	/// <summary>
	/// This is the local location to your map's cover image.
	/// Both .jpg and .png are supported image types. Similar to _songFilename, this is most often just the name and extension for the cover image (For example, cover.jpg).
	/// </summary>
	[JsonPropertyName("_coverImageFilename")]
	public string CoverImageFilename { get; set; }
	/// <summary>
	/// This defines the internal ID for the environment that the map uses.
	/// To get a complete list of valid environments, see the Info.dat Names of each environment in the Environment Previews section
	/// </summary>
	[JsonPropertyName("_environmentName")]
	public string EnvironmentName { get; set; }
	/// <summary>
	/// This defines the internal ID for the environment that the map uses when playing in 360 Degree or 90 Degree levels.
	/// This is a required field, even if the level does not include any 360 or 90 Degree difficulties.
	/// To get a complete list of valid 360 environments, see the Info.dat Names of each environment in the Environment Previews section.
	/// </summary>
	[JsonPropertyName("_allDirectionsEnvironmentName")]
	public string AllDirectionsEnvironmentName { get; set; }
	/// <summary>
	/// This is Beat Saber's method for tackling off-sync audio. This offsets the audio in game, based off the value of _songTimeOffset in milliseconds.
	/// </summary>
	[JsonPropertyName("_songTimeOffset")]
	public int SongTimeOffset { get; set; }
	/// <summary>
	/// This is an optional field that contains data unrelated to the official Beat Saber level format. If no custom data exists, this object should be removed entirely.
	/// The exact specifics of what goes in CustomData is entirely dependent on community-created content that needs them.
	/// As such, we cannot list all CustomData fields here.
	/// You will have to do your own searching throughout the Beat Saber community to find map editors, tools, or mods that use this CustomData object.
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
	/// <summary>
	/// This is an array of all Difficulty Beatmap Sets defined in the map
	/// </summary>
	[JsonPropertyName("_difficultyBeatmapSets")]
	public List<DifficultyBeatmapSet> DifficultyBeatmapSets { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#difficulty-beatmap-sets
public class DifficultyBeatmapSet
{
	/// <summary>
	/// This is the name of the characteristic attached to this beatmap set.
	/// Listed below is all commonly used characteristics. 
	/// While they have little to no "rules" attached to them in Beat Saber, they still have an intended purpose, and should be followed by both the map editor and the mapper creating maps.
	/// Certain characteristics, which are marked in the list below, do not belong to the base game; rather, they are added by external mods such as SongCore.
	/// These modded characteristics will only work if the user has installed mods that add them, and will not appear on unmodded copies of Beat Saber and could cause the map to not load.
	/// Characteristic Name	Included in Base Game	Intended Purpose
	/// Standard			✔️						Vanilla maps following standard mapping guidelines.
	/// NoArrows			✔️						Restrict notes to Dot (any direction) notes.
	/// OneSaber			✔️						Restrict notes to Right (Blue) notes, and disables the Left (Red) saber.
	/// 360Degree			✔️						Enables rotation events, with no restriction on total rotation.
	/// 90Degree			✔️						Enables rotation events, but restricts total rotation to 45 degrees to the left and right.
	/// Lightshow			❌						Place for maps that only contains lighting events.
	/// Lawless				❌						Modded maps and modcharts can safely go here. No rules should apply.
	/// </summary>
	[JsonPropertyName("_beatmapCharacteristicName")]
	public string BeatmapCharacteristicName { get; set; }
	/// <summary>
	/// This is an array of Difficulty Beatmaps defined within this beatmap set
	/// </summary>
	[JsonPropertyName("_difficultyBeatmaps")]
	public List<DifficultyBeatmap> DifficultyBeatmaps { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#difficulty-beatmaps
public class DifficultyBeatmap
{
	/// <summary>
	/// This is the internal difficulty, read by Beat Saber.
	/// Contrary to what you might think, this is not just a normal string, but rather an Enum.Here is a list of all valid difficulties:
	///		* Easy
	///		* Normal
	///		* Hard
	///		* Expert
	///		* ExpertPlus
	/// </summary>
	[JsonPropertyName("_difficulty")]
	public Difficulty Difficulty { get; set; }
	/// <summary>
	///	Note: this is dumb, this just returns (int)Difficulty instead
	/// 
	/// This is the sorting order in the song select screen in Beat Saber.
	/// While, yes, this is an ordinary integer, the widely-used BeatSaver Schema makes this another Enum, based off of the aforementioned Difficulty value:
	/// Difficulty	BeatSaver's Expected DifficultyRank
	/// Easy		1
	/// Normal		3
	/// Hard		5
	/// Expert		7
	/// ExpertPlus	9
	/// </summary>

	[JsonPropertyName("_difficultyRank")]
	// I'm not doing this
	public int DifficultyRank => (int)Difficulty;
	/// <summary>
	/// This is the local location to the difficulty file, which contains the difficulty's notes, obstacles, and lighting events.
	/// Similar to the SongFilename and CoverImageFilename from earlier, in most cases this is just the name and extension(always.dat) to the map file
	/// When creating new difficulties, it is recommended that the name be the Characteristic name for this difficulty's parent Beatmap Set, followed by the Difficulty value.
	/// For example, this particular difficulty should have it's difficulty file be named StandardExpertPlus.dat.
	/// </summary>
	[JsonPropertyName("_beatmapFilename")]
	public string BeatmapFilename { get; set; }
	/// <summary>
	/// Note Jump Movement Speed (Shortened to "Note Jump Speed", or just "NJS") is the velocity of objects approaching the player, in meters per second.
	/// Info on recommended NJS values can be found on the Intermediate Mapping Page. This can be a floating point number for precise velocity.
	/// This is used, along with the defined BPM of the song, to calculate 2 very important values, called Jump Duration and Jump Distance.
	///		* Jump Duration is the amount of beats where objects can be active.
	///		* Jump Distance is the total amount of distance that objects need to travel within that Jump Duration.
	/// The Player rests in the exact middle of both of these values, so most mappers find it more convenient to have Half Jump Distance and Half Jump Duration.
	///		* Half Jump Distance is the distance from the Player that objects spawn. Some mappers refer to this as the "Spawn Point".
	///		* Half Jump Duration is the amount of beats that is needed to reach the Player.It is also the amount of beats, forward in time, where objects spawn.
	/// </summary>
	[JsonPropertyName("_noteJumpMovementSpeed")]
	public int NoteJumpMovementSpeed { get; set; }
	/// <summary>
	/// This value acts as a direct offset to the Half Jump Duration, explained in NoteJumpMovementSpeed, which in turn affects the Jump Distance.
	/// This can be a floating point number to achieve a precise Jump Duration.
	/// </summary>
	[JsonPropertyName("_noteJumpStartBeatOffset")]
	public float NoteJumpStartBeatOffset { get; set; }
	/// <summary>
	/// This is an optional field that contains data unrelated to the official Beat Saber level format. If no custom data exists, this object should be removed entirely.
	/// The exact specifics of what goes in CustomData is entirely dependent on community-created content that needs them.
	/// As such, we cannot list all CustomData fields here.
	/// You will have to do your own searching throughout the Beat Saber community to find map editors, tools, or mods that use this CustomData object.
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#difficultyrank
public enum Difficulty
{
	Easy = 1,
	Normal = 3,
	Hard = 5,
	Expert = 7,
	ExpertPlus = 9
}
