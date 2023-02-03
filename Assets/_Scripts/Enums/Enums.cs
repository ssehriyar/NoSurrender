using System;

[Serializable]
public enum GameState
{
    Countdown,
    Play,
    Pause,
    Fail,
    Win,
    TimesUp
}

public enum ForceType
{
    Small,
    Medium,
    Huge,
}