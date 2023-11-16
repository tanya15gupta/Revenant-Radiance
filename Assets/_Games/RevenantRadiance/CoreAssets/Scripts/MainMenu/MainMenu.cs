using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RevenantRadiance.Core.Input;
using RevenantRadiance.Core.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace RevenantRadiance.Core
{
    public class MainMenu : GameState, IMainMenu, RevenantRadianceInput.IMenuActions
    {
        public override GameStates Type => GameStates.MainMenu;
        [SerializeField] private CanvasGroup mainMenuCanvas;
        [SerializeField] private MainMenuUI menuUI;
        [SerializeField] private LoadGameUI gameSelectorPanel;
        [SerializeField] private OptionsPanelUI optionsPanel;

        private IMainMenuUI currentActiveMenu;

        protected void Awake()
        {
            mainMenuCanvas.alpha = 0;
        }
        
        void Start()
        {
            // GameUtilities.ToggleCursorStatus(true);
        }

        public override void Initialize(params object[] stateParams)
        {
            mainMenuCanvas.DOFade(1,2f);
            GameStateHandler.Instance.RequestStateChange(this);
        }

        public override void EnterState()
        {
            StartCoroutine(EnterStateRoutine());
        }

        public override void ExitState()
        {
            InputProvider.Input.Menu.RemoveCallbacks(this);
            InputProvider.Input.Menu.Disable();
            SceneManager.UnloadSceneAsync(GameStateHandler.MAIN_MENU_SCENE);
        }
        
        
        private IEnumerator EnterStateRoutine()
        {
            menuUI.Initialize(this);
            menuUI.Disable();
            
            optionsPanel.Initialize(this);
            optionsPanel.Disable();
            
            gameSelectorPanel.Initialize(this);
            gameSelectorPanel.Disable();

            yield return null;
            
            InputProvider.Input.Menu.SetCallbacks(this);
            InputProvider.Input.Menu.Enable();
            SwitchMenu(menuUI);
        }
        
        private void SwitchMenu(IMainMenuUI menu)
        {
            if (currentActiveMenu == menu) return;
            if (currentActiveMenu != null)
            {
                currentActiveMenu.Disable();
            }
            currentActiveMenu = menu;
            currentActiveMenu.Enable();
        }

        
        
        #region Control Points
        void IMainMenu.LoadMainMenu()
        {
            SwitchMenu(menuUI);
        }

        void IMainMenu.LoadSelectGamePanel()
        {
            GameStateHandler.Instance.LoadGame();
            // SwitchMenu(gameSelectorPanel);
            
        }

        void IMainMenu.LoadOptionsPanel()
        {
            SwitchMenu(optionsPanel);
        }
        
        void IMainMenu.ExitGame()
        {
            GameConfig.Instance.ExitGame();
        }
        #endregion

        #region Input

        public void OnNavigate(InputAction.CallbackContext context)
        {
            
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ((IMainMenu)this).LoadMainMenu();
            }
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            
        }

        #endregion
    }
}
