using Sandbox;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class MapPlayer : Entity
{
	public Map Map;
	public DifficultyFile Difficulty;

	int Beat;
	TimeSince TimeSinceLastBeat;
	TimeSince TimeSinceStart;
	float CurrentBPM;
	float BPMInterval => 60 / CurrentBPM;

	public MapPlayer(Map m)
	{
		Map = m;

		CurrentBPM = m.BeatsPerMinute;
		TimeSinceLastBeat = 0;
		TimeSinceStart = 0;
	}

	[Sandbox.Event.Tick]
	void Tick()
	{
		// Just in case there's multiple beats this tick
		while (TimeSinceLastBeat >= BPMInterval)
		{
			TimeSinceLastBeat = TimeSinceLastBeat - BPMInterval;
			Step();
		}
	}

	void Step()
	{
		foreach (var note in GetNotes(Beat))
		{
			switch (note.Type)
			{
				case NoteType.Left:
				case NoteType.Right:
					Log.Info($"{note.Type} {note.CutDirection} ({note.LineIndex},{note.LineLayer})");
					break;

				case NoteType.Bomb:
					Log.Info($"Bomb ({note.LineIndex},{note.LineLayer})");
					break;

				default:
					Log.Warning($"Unknown note type {note.Type}");
					Log.Warning(JsonSerializer.Serialize(note));
					break;
			}
		}

		foreach (var e in GetEvents(Beat))
		{
			switch (e.Type)
			{
				case EventType.BPMChange:
					CurrentBPM = (float)e.Value;
					break;

				default:
					Log.Warning($"Unhandled evet type {e.Type}");
					Log.Warning(JsonSerializer.Serialize(e));
					break;
			}
		}

		Beat++;
	}

	IEnumerable<Note> GetNotes(int time)
		=> Difficulty.Notes.Where(n => n.Time == time);

	IEnumerable<Event> GetEvents(int time)
		=> Difficulty.Events.Where(n => n.Time == time);
}
