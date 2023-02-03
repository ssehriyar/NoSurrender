using UnityEngine;

namespace NoSurrender
{
    public abstract class UIBase : MonoBehaviour
    {
        [SerializeField] protected GameState _gameState;

        protected virtual void Start()
		{
			GameStateManager.OnGameStateChange += OnGameStateChange;
		}

        protected virtual void OnGameStateChange(GameState gameState)
		{
			if (_gameState == gameState)
			{
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		protected virtual void OnDestroy()
		{
			GameStateManager.OnGameStateChange -= OnGameStateChange;
		}
	}
}
