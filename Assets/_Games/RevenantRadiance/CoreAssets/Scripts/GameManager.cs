using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RevenantRadiance.Game
{
    public enum InGameState
    {
        Paused,
        InGame
    }
    public class GameManager : Singleton<GameManager>
    {

        public event Action OnSetupStart;
        public event Action OnPaused;
        public event Action OnInGameStateChanged;
        
        public Core.Game game;
        
        
        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize(Core.Game game)
        {
            this.game = game;
            StartCoroutine(InitializeRoutine());
        }


        private IEnumerator InitializeRoutine()
        {
            yield return new WaitForEndOfFrame();
            game.SetGameReady();
        }
    }
}
