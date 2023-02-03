using TMPro;
using UnityEngine;

namespace NoSurrender
{
	public class GameEndText : MonoBehaviour
	{
		[SerializeField] private Player _player;
		[SerializeField] private TMP_Text _text;

		private void Start()
		{
			GameStateManager.OnGameStateChange += StateChange;
			_text.text = "";
		}

		private void StateChange(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Fail:
					_text.text = "You're #" + _player.GameScore() + "\n" + _player.Score;
					break;
				case GameState.Win:
					_text.text = "You're #" + _player.GameScore() + "\n" + _player.Score;
					break;
				case GameState.TimesUp:
					_text.text = "You're #" + _player.GameScore() + "\n" + _player.Score;
					break;
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChange -= StateChange;
		}
	}
}
