using System.Text.Json.Serialization;

// https://bsmg.wiki/mapping/map-format.html#events-2
public class Event
{
	/// <summary>
	/// The time, in beats, where this object reaches the player
	/// </summary>
	[JsonPropertyName("_time")]
	public int Time { get; set; }
	/// <summary>
	/// An integer number which represents what exact kind of event this object represents
	/// </summary>
	[JsonPropertyName("_type")]
	public EventType Type { get; set; }
	/// <summary>
	/// Depending on the aforementioned _type of the event, the _value of it can do different things.
	/// </summary>
	[JsonPropertyName("_value")]
	public int Value { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("_customData")]
	public CustomData CustomData { get; set; }
}

// https://bsmg.wiki/mapping/map-format.html#type-3
public enum EventType
{
	/// <summary>
	/// Controls lights in the Back Lasers group.
	/// </summary>
	BackLaserLights = 0,
	/// <summary>
	/// Controls lights in the Ring Lights group.
	/// </summary>
	RingLights = 1,
	/// <summary>
	/// Controls lights in the Left Rotating Lasers group.
	/// </summary>
	LeftRotatingLasersLights = 2,
	/// <summary>
	/// Controls lights in the Right Rotating Lasers group.
	/// </summary>
	RightRotatingLasersLights = 3,
	/// <summary>
	/// Controls lights in the Center Lights group.
	/// </summary>
	CenterLights = 4,

	/// <summary>
	/// (Previously unused) Controls boost light colors (secondary colors).
	/// </summary>
	BoostLightColors = 5,
	/// <summary>
	/// (Previously unused) Controls extra left side lights in the Interscope environment.
	/// </summary>
	ExtraLeftSideLights = 6,
	/// <summary>
	/// (Previously unused) Controls extra right side lights in the Interscope environment.
	/// </summary>
	ExtraRightSideLights = 7,

	/// <summary>
	/// Creates one ring spin in the environment.
	/// </summary>
	CreateRingSpin = 8,
	/// <summary>
	/// Controls zoom for applicable rings. Is not affected by Vvalue.
	/// </summary>
	ControlRingZoon = 9,

	/// <summary>
	/// (Previously unused) Official BPM Changes.
	/// </summary>
	BPMChange = 10,

	/// <summary>
	/// Unused.
	/// </summary>
	Unused11 = 11,

	/// <summary>
	/// Controls rotation speed for applicable lights in Left Rotating Lasers.
	/// </summary>
	LeftRotatingLasersRotationSpeed = 12,
	/// <summary>
	/// Controls rotation speed for applicable lights in Right Rotating Lasers.
	/// </summary>
	RightRotatingLasersRotationSpeed = 13,

	/// <summary>
	/// (Previously unused) 360/90 Early rotation. Rotates future objects, while also rotating objects at the same time.
	/// </summary>
	EarlyRotation = 14,
	/// <summary>
	/// (Previously unused) 360/90 Late rotation. Rotates future objects, but ignores rotating objects at the same time.
	/// </summary>
	LateRotation = 15,

	/// <summary>
	/// Lowers car hydraulics in the Interscope environment.
	/// </summary>
	CarHydraulicsLower = 16,
	/// <summary>
	/// Raises car hydraulics in the Interscope environment.
	/// </summary>
	CarHydraulicsRaise = 17,
}

// https://bsmg.wiki/mapping/map-format.html#controlling-lights
public enum LightControlValue
{
	/// <summary>
	/// Turns the light group off.
	/// </summary>
	TurnOff = 0,

	/// <summary>
	/// Changes the lights to blue, and turns the lights on.
	/// </summary>
	ChangeToBlueAndTurnOn = 1,
	/// <summary>
	/// Changes the lights to blue, and flashes brightly before returning to normal.
	/// </summary>
	ChangeToBlueAndFlashThenReturn = 2,
	/// <summary>
	/// Changes the lights to blue, and flashes brightly before fading to black.
	/// </summary>
	ChangeToBlueAndFlashThenFade = 3,

	/// <summary>
	/// Unused.
	/// </summary>
	Unused4 = 4,

	/// <summary>
	/// Changes the lights to red, and turns the lights on.
	/// </summary>
	ChangeToRedAndTurnOn = 1,
	/// <summary>
	/// Changes the lights to red, and flashes brightly before returning to normal.
	/// </summary>
	ChangeToRedAndFlashThenReturn = 2,
	/// <summary>
	/// Changes the lights to red, and flashes brightly before fading to black.
	/// </summary>
	ChangeToRedAndFlashThenFade = 3,
}

// https://bsmg.wiki/mapping/map-format.html#controlling-boost-colors
public enum BoostColorControlValue
{
	/// <summary>
	/// Turns the event off - switches to first (default) pair of colors.
	/// </summary>
	Off = 0,
	/// <summary>
	/// Turns the event on - switches to second pair of colors.
	/// </summary>
	On = 1
}

// https://bsmg.wiki/mapping/map-format.html#controlling-cars
public enum CarControlValue
{
	/// <summary>
	/// Affects all the cars. Does not affect hydraulics.
	/// </summary>
	AllNotHydraulics = 0,
	/// <summary>
	/// Affects all the cars.
	/// </summary>
	All = 1,
	/// <summary>
	/// Affects the left cars.
	/// </summary>
	AllLeft = 2,
	/// <summary>
	/// Affects the right cars.
	/// </summary>
	AllRight = 3,
	/// <summary>
	/// Affects the front-most cars.
	/// </summary>
	AllFront = 4,
	/// <summary>
	/// Affects the front-middle cars.
	/// </summary>
	AllFrontMiddle = 5,
	/// <summary>
	/// Affects the back-middle cars.
	/// </summary>
	AllBackMiddle = 6,
	/// <summary>
	/// Affects the back-most cars.
	/// </summary>
	AllBack = 7,
}

// https://bsmg.wiki/mapping/map-format.html#controlling-360-90-rotation
public enum RotationControlValue
{
	/// <summary>
	/// 60 Degrees Counterclockwise
	/// </summary>
	CC60 = 0,
	/// <summary>
	/// 45 Degrees Counterclockwise
	/// </summary>
	CC45 = 1,
	/// <summary>
	/// 30 Degrees Counterclockwise
	/// </summary>
	CC30 = 2,
	/// <summary>
	/// 15 Degrees Counterclockwise
	/// </summary>
	CC15 = 3,
	/// <summary>
	/// 15 Degrees Clockwise
	/// </summary>
	C15 = 4,
	/// <summary>
	/// 30 Degrees Clockwise
	/// </summary>
	C30 = 5,
	/// <summary>
	/// 45 Degrees Clockwise
	/// </summary>
	C45 = 6,
	/// <summary>
	/// 60 Degrees Clockwise
	/// </summary>
	C60 = 7
}
