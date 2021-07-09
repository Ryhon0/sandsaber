
using Sandbox;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

[Library("sandsaber")]
public partial class Game : Sandbox.Game
{
	public Game()
	{
		if (IsServer)
		{
			new Hud();
		}

		if (IsClient)
		{
		}
	}

	public override void ClientJoined(Client client)
	{
		base.ClientJoined(client);

		var player = new SaberPlayer();
		client.Pawn = player;

		player.Respawn();
	}

	public override void DoPlayerNoclip(Client player)
	{
	}

	[ServerCmd("saber_map")]
	public static void PlayMap(string id, string difficulty)
	{

		var json = FileSystem.Data.ReadAllText($"maps/{id}/Info.dat");
		var opts = new JsonSerializerOptions();
		opts.Converters.Add(new JsonStringEnumConverter(new PascalCase()));

		var map = JsonSerializer.Deserialize<Map>(json, opts);
		map.Id = id;

		try
		{
			var dif = FileSystem.Data.ReadJson<DifficultyFile>($"maps/{id}/{difficulty}");

			Log.Info($"Playing {map.SongAuthorName} - {map.SongName} @ {difficulty}");

			var player = new MapPlayer(map, dif);
		}
		catch (Exception e) { Log.Trace(e); }
	}
}
