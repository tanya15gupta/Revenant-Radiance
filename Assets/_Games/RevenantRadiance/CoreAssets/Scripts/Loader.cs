using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using RevenantRadiance.Core;
using RevenantRadiance.Core.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RevenantRadiance
{
    public class Loader : GameState
    {
        public override GameStates Type => GameStates.Loading;

        public event Action<float> LoadingProgress;
        public event Action OnSceneReady;

        [SerializeField] private LoadingScreenUI loaderUI;
        [SerializeField] private float loadingPercentage;


        private bool readyToActivate = false;

        private bool inputGiven = false;
        private bool sceneReady = false;
        
        private bool waitForActivation;
        private string sceneToLoad;
        private object[] forwardingSceneParams;
        
        
        public virtual void Initialize(params object[] stateParams)
        {
            loadingPercentage = 0;
            readyToActivate = false;
            if (stateParams == null || stateParams.Length == 0)
            {
                Debug.LogError($"Cannot use a loader without a forwarding scene");
            }
            sceneToLoad = (string)stateParams[0];
            waitForActivation = (bool)stateParams[1];
            forwardingSceneParams = stateParams.Skip(2).ToArray();

        }
        
        public override void EnterState()
        {
            StartCoroutine(LoadScene());
            loaderUI.Initialize(this);
        }

        public override void ExitState()
        {
            base.ExitState();
            SceneManager.UnloadSceneAsync(GameStateHandler.LOADER_SCENE);
        }

        private void Update()
        {
            if (sceneReady && Input.GetKeyDown(KeyCode.E))
            {
                inputGiven = true;
            }
        }


        private IEnumerator LoadScene()
        {
            LoadingProgress?.Invoke(loadingPercentage);
            var waitForEndOfFrame = new WaitForEndOfFrame();
            // SceneManager.UnloadSceneAsync()
            var loadOp = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            if (waitForActivation)
            {
                loadOp.allowSceneActivation = false;
            }
            loadOp.completed += (asyncOp) =>
            {
                foreach (var rootGameObject in SceneManager.GetSceneByName(sceneToLoad).GetRootGameObjects())
                {
                    if (rootGameObject.TryGetComponent<GameState>(out var gameState))
                    {
                        gameState.Initialize(forwardingSceneParams);
                        break;
                    }
                }
            };
            if (waitForActivation)
            {
                while (loadOp.progress < 0.9f)
                {
                    loadingPercentage = loadOp.progress;
                    LoadingProgress?.Invoke(loadingPercentage);
                    yield return null;
                }
                loadingPercentage = 1f;
                LoadingProgress?.Invoke(loadingPercentage);
                yield return new WaitForSeconds(1);
                OnSceneReady?.Invoke();
                sceneReady = true;
                if (waitForActivation)
                {
                    yield return new WaitWhile(() => !inputGiven);
                    loadOp.allowSceneActivation = true;
                }
            }
            else
            {
                
            }
            while (!loadOp.isDone)
            {
                loadingPercentage = loadOp.progress;
                yield return null;
            }


            
            
        }
    }
}
