using Sandbox;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class MapPlayer : Entity
{
	public Map Map;
	public DifficultyFile Difficulty;

	float LastBeat;
	float MaxBeat;

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
		LastBeat = MaxBeat;

		MaxBeat = LastBeat + TimeSinceLastBeat / BPMInterval;
		//Log.Info(MaxBeat);

		TimeSinceLastBeat = 0;

		Step();
	}

	void Step()
	{
		foreach (var note in GetNotes())
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

		foreach (var e in GetEvents())
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

	IEnumerable<Note> GetNotes()
		=> Difficulty.Notes.Where(n => n.Time > LastBeat && n.Time <= MaxBeat);

	IEnumerable<Event> GetEvents()
		=> Difficulty.Events.Where(e => e.Time > LastBeat && e.Time <= MaxBeat);

		Beat++;
	}


}
