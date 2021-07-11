using Sandbox;

public class Bomb : Prop
{
	public override void Spawn()
	{
		base.Spawn();
		SetModel("models/bomb/bomb.vmdl");
		MoveType = MoveType.MOVETYPE_FLY;
		Velocity = new Vector3(-1000, 0, 0);
	}

	public override void Touch(Entity other)
	{
		base.Touch(other);

		if (IsServer)
			Delete();
	}
}
