using UnityEngine;
using UnityEngine.UI;

namespace NoSurrender
{
    public class PauseButton : UIBase
    {
        public void OnPause()
		{
            GameStateManager.SetState(GameState.Pause);
		}
    }
}
