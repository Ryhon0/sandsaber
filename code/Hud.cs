using Sandbox.UI;

public partial class Hud : Sandbox.HudEntity<RootPanel>
{
	public Hud()
	{
		if (IsClient)
		{
			RootPanel.SetTemplate("/Hud.html");
		}
	}
}
