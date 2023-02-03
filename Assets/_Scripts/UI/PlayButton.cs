using UnityEngine;
using UnityEngine.UI;

namespace NoSurrender
{
    public class PlayButton : UIBase
    {
        public void OnPlay()
        {
            GameStateManager.SetState(GameState.Play);
        }
    }
}
