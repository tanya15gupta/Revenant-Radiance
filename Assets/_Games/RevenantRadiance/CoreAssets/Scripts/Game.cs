using System.Collections;
using System.Collections.Generic;
using RevenantRadiance.Game;
using UnityEngine;

namespace RevenantRadiance.Core
{
    public class Game : GameState
    {
        private GameManager manager;
        
        public override void Initialize(params object[] stateParams)
        {
            StartCoroutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            // get GameManager to setup everything
            manager = this.GetComponent<GameManager>();
            
            // then request state change
            yield return new WaitForEndOfFrame();
            manager.Initialize(this);
        }

        public void SetGameReady()
        {
            GameStateHandler.Instance.RequestStateChange(this);
        }

        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }
    }
}
