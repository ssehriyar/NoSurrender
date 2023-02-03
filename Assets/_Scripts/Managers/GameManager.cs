using UnityEngine;

namespace NoSurrender
{
	public class GameManager : MonoBehaviour
	{
		private void Start()
		{
			GameStateManager.SetState(GameState.Countdown);
		}
	}
}
