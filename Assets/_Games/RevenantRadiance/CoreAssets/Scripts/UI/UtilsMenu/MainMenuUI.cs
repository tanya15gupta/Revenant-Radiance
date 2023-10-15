using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RevenantRadiance.Core.UI
{
    public class MainMenuUI : MonoBehaviour, IMainMenuUI
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private GameObject firstSelected;

        [Header("Buttons")]
        [SerializeField] private Button loadGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button exitGameButton;
        
        private IMainMenu _mainMenu;
        
        public void Initialize(IMainMenu mainMenu)
        {
            _mainMenu = mainMenu;
            loadGameButton.onClick.AddListener(OnLoadGameClicked);
            optionsButton.onClick.AddListener(OnOptionsClicked);
            exitGameButton.onClick.AddListener(OnExitClicked);
            panel.gameObject.SetActive(true);
        }
        
        public void Enable()
        {
            panel.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }

        public void Disable()
        {
            panel.gameObject.SetActive(false);
        }

        public void OnLoadGameClicked()
        {
            _mainMenu.LoadSelectGamePanel();
        }

        public void OnOptionsClicked()
        {
            _mainMenu.LoadOptionsPanel();
        }

        public void OnExitClicked()
        {
            _mainMenu.ExitGame();
        }
    }
}
