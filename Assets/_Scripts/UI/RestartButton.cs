using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NoSurrender
{
	public class RestartButton : MonoBehaviour
	{
		[SerializeField] private Image _image;

		private void Start()
		{
			GameStateManager.OnGameStateChange += StateChange;
			_image.enabled = false;
		}

		private void StateChange(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Fail:
					_image.enabled = true;
					break;
				case GameState.Win:
					_image.enabled = true;
					break;
				case GameState.TimesUp:
					_image.enabled = true;
					break;
			}
		}

		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChange -= StateChange;
		}
	}
}
