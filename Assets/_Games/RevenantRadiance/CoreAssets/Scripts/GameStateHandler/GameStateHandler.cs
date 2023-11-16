using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RevenantRadiance.Core
{
    public class GameStateHandler : Singleton<GameStateHandler>
    {
        public static string LOADER_SCENE => "Loader";
        public static string MAIN_MENU_SCENE => "MainMenu";
        public static string GAME_BASE_SCENE => "GameBase";
        
        public event System.Action<GameState> OnGameStateChanged;
        private GameStates _currentGameState;

        private GameState _currentState;
        public GameStates GameState => _currentGameState;

        private object[] gameParams = null; 
        
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
            _currentGameState = GameStates.None;
        }


        public async void LoadMainMenu()
        {
            await LoadSceneAsync(LOADER_SCENE, () => { LoaderSetup(MAIN_MENU_SCENE, false); });
        }


        public async void LoadGame(params object[] gameParams)
        {
            await LoadSceneAsync(LOADER_SCENE, () => { LoaderSetup(GAME_BASE_SCENE, true, gameParams); });
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
        
        private async System.Threading.Tasks.Task LoadSceneAsync(string sceneName, Action onComplete)
        {
            // Start the asynchronous operation
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            asyncOperation.completed += (asyncOp) =>
            {
                if(onComplete != null) onComplete?.Invoke();
            };
            // Wait until the scene is fully loaded
            while (!asyncOperation.isDone)
            {
                // Yielding null will wait for the next frame before continuing the loop
                await System.Threading.Tasks.Task.Yield();
            }
        }
        
        
        private void LoaderSetup(string sceneName, bool waitForActivation, params object[] otherParams)
        {
            foreach (var rootGameObject in SceneManager.GetSceneByName(LOADER_SCENE).GetRootGameObjects())
            {
                if (rootGameObject.TryGetComponent<Loader>(out var loader))
                {
                    loader.Initialize(sceneName, waitForActivation, otherParams);
                    RequestStateChange(loader);
                    break;
                }
            }
        }
    }
}
