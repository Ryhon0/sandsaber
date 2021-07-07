﻿using Sandbox;

partial class SaberPlayer : Sandbox.Player
{
	public override void Respawn()
	{
		SetModel("models/citizen/citizen.vmdl");

		Controller = new WalkController();
		Animator = new StandardPlayerAnimator();
		Camera = new ThirdPersonCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		base.Respawn();
	}

	public override void Simulate(Client cl)
	{
		base.Simulate(cl);

		SimulateActiveChild(cl, ActiveChild);

		if (IsServer && Input.Pressed(InputButton.Attack1))
		{
			var ragdoll = new Block();
			ragdoll.Position = EyePos + EyeRot.Forward * 40;
			ragdoll.Rotation = Rotation.LookAt(Vector3.Random.Normal);
			ragdoll.SetupPhysicsFromModel(PhysicsMotionType.Dynamic, false);
			ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
		}
	}

	public override void OnKilled()
	{
	}
}
