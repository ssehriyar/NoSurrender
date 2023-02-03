using System;

public static class GameStateManager
{
    public static GameState currentState;
    public static Action<GameState> OnGameStateChange;

    public static GameState GetState()
    {
        return currentState;
    }

    public static void SetState(GameState gameState)
    {
        currentState = gameState;
        OnGameStateChange?.Invoke(gameState);
    }
}