using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }

    public enum GameState
    {
        ARTISTCASE,
        PRIESTCASE,
        BAKERCASE,
        KILLERCASE,
        NOCASE,
    }

    public GameState CurrentGameState { get; set; } = GameState.NOCASE;

    public void ChangeCaseState(GameState state)
    {
        CurrentGameState = state;
    }
}
