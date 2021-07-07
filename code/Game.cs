
using Sandbox;

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
}
