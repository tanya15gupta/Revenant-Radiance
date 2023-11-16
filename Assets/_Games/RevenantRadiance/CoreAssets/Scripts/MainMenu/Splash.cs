using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RevenantRadiance.Core;
using RevenantRadiance.Core.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace RevenantRadiance
{
    public class Splash : GameState
    {
        public override GameStates Type => GameStates.Init;
        [SerializeField] private CanvasGroup splashUI;
        
        private void Awake()
        {
            splashUI.alpha = 0;
        }

        public override void Initialize(params object[] stateParams)
        {
            GameStateHandler.Instance.RequestStateChange(this);
        }

        public override void EnterState()
        {
            InputProvider.Input.Menu.Disable();
            Sequence seq = DOTween.Sequence()
                .Append(splashUI.DOFade(1, 2))
                .AppendCallback(() =>
                {
                    InputSystem.onAnyButtonPress
                        .CallOnce(ctrl => OnAnyKeyPressed());
                })
                .Play();
        }

        public override void ExitState()
        {
            // preCanvasUI.DOFade(0, 0.5f);
            splashUI.DOFade(0, 2).OnComplete(() =>
            {
                splashUI.gameObject.SetActive(false);
            });
        }
        
        private void OnAnyKeyPressed()
        {
            MainMenuSceneHandler.Instance.SetupMainMenu();
        }

    }
}
