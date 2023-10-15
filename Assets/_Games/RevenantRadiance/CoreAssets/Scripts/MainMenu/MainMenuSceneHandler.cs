using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace RevenantRadiance.Core
{
    public class MainMenuSceneHandler : Singleton<MainMenuSceneHandler>
    {
        [SerializeField] private CanvasGroup preInitUI;
        [SerializeField] private Splash splashSetup;
        [SerializeField] private MainMenu mainMenuSetup;
        
        void Start()
        {
            preInitUI.gameObject.SetActive(true);
            DOTween.Init();

            Sequence seq = DOTween.Sequence()
                .AppendInterval(1)
                .Append(preInitUI.DOFade(0, 2.1f))
                .InsertCallback(2,() =>
                {
                    if (GameStateHandler.Instance.GameState == GameStates.Game)
                    {
                        SetupMainMenu();
                    }
                    else
                    {
                        SetupSplash();
                    }
                });
        }

        public void SetupMainMenu()
        {
            mainMenuSetup.Initialize();
        }

        public void SetupSplash()
        {
            splashSetup.Initialize();
        }
    }
}
