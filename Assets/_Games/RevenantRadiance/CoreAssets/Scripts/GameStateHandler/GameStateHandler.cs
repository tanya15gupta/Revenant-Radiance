using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance.Core
{
    public class GameStateHandler : Singleton<GameStateHandler>
    {
        public event System.Action<GameState> OnGameStateChanged;
        private GameStates _currentGameState;

        private GameState _currentState;
        public GameStates GameState => _currentGameState;
        
        
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
            _currentGameState = GameStates.None;
        }


        public void LoadMainMenuState()
        {
            
        }

        public void LoadGameState(params object[] gameParams)
        {
            
        }

        public void RequestStateChange(GameState state)
        {
            if(_currentGameState == state.Type) return;
            _currentState?.ExitState();
            _currentGameState = state.Type;
            _currentState = state;
            _currentState?.EnterState();
            OnGameStateChanged?.Invoke(_currentState);
        }
    }
}
