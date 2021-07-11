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

	public MapPlayer(Map m, DifficultyFile dif)
	{
		Map = m;
		Difficulty = dif;

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
					SpawnBlock(note);
					break;

				case NoteType.Bomb:
					Log.Info($"Bomb ({note.LineIndex},{note.LineLayer})");
					SpawnBomb(note);
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
					Log.Info($"BPM changed to {e.Value}");
					CurrentBPM = (float)e.Value;
					break;

				default:
					Log.Warning($"Unhandled evet type {e.Type}");
					Log.Warning(JsonSerializer.Serialize(e));
					break;
			}
		}

		foreach (var o in GetObstacles())
		{
			Log.Info($"Obstacle {o.Type} ({o.LineIndex},{o.Width},{o.Duration})");
			SpawnObstacle(o);
		}
	}

	IEnumerable<Note> GetNotes()
		=> Difficulty.Notes.Where(n => n.Time > LastBeat && n.Time <= MaxBeat);

	IEnumerable<Event> GetEvents()
		=> Difficulty.Events.Where(e => e.Time > LastBeat && e.Time <= MaxBeat);

	IEnumerable<Obstacle> GetObstacles()
		=> Difficulty.Obstacles.Where(o => o.Time > LastBeat && o.Time <= MaxBeat);


	void SpawnBlock(Note n)
	{
		var b = new Block();

		if (n.CutDirection == CutDirection.Any)
			b.SetMaterialGroup(1);

		var rot = 0f;

		switch (n.CutDirection)
		{
			case CutDirection.Any:
			case CutDirection.Up:
				rot = 0f;
				break;

			case CutDirection.Left:
				rot = 90;
				break;

			case CutDirection.Right:
				rot = -90;
				break;

			case CutDirection.Down:
				rot = 180;
				break;

			case CutDirection.DownLeft:
				rot = 135;
				break;

			case CutDirection.DownRight:
				rot = -135;
				break;

			case CutDirection.UpLeft:
				rot = 15;
				break;

			case CutDirection.UpRight:
				rot = -45;
				break;
		}

		b.Rotation = Rotation.From(0, 180, rot);

		b.Position = new Vector3(1000, (n.LineIndex * -32f) + 48, 32 + (n.LineLayer * 32));

		b.RenderColor = b.GlowColor =
			n.Type == NoteType.Left ? new Color(1, 0, 0) : new Color(0, 0, 1);
	}

	void SpawnBomb(Note n)
	{
		var b = new Bomb();

		b.Position = new Vector3(1000, (n.LineIndex * -32f) + 48, (n.LineLayer + 1.5f) * 20);
	}

	void SpawnObstacle(Obstacle o)
	{
		var len = (int)(o.Duration * 2000f);
		var h = o.Type == ObstacleType.FullHeightWall ? 100 : 50;
		var w = o.Width * 32;
		var rect = VertexMeshBuilder.GenerateRectangleServer(len, w, h, 1);
		var obstacle = new ObstacleEntity()
		{
			Model = rect
		};
		obstacle.Position = new Vector3(1000 + len / 2,
			48 - (o.LineIndex * 32) - ((o.Width - 1) * 16)
			, 100 - h / 2);
		obstacle.Tick();

		obstacle.MoveType = MoveType.MOVETYPE_FLY;
		obstacle.Velocity = new Vector3(-1000, 0, 0);
		obstacle.CollisionGroup = CollisionGroup.Never;
	}
}
