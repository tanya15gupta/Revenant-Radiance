using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RevenantRadiance.Core.UI
{
    public class LoadGameUI : MonoBehaviour, IMainMenuUI
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private GameObject firstSelected;
        
        [Header("Buttons")]
        [SerializeField] private Button backButton;
        
        private IMainMenu _mainMenu;
        
        public void Initialize(IMainMenu mainMenu)
        {
            _mainMenu = mainMenu;
            backButton.onClick.AddListener(OnBackClicked);
        }

        public void Enable()
        {
            EventSystem.current.SetSelectedGameObject(firstSelected);
            panel.gameObject.SetActive(true);
        }

        public void Disable()
        {
            panel.gameObject.SetActive(false);
        }

        public void OnBackClicked()
        {
            _mainMenu.LoadMainMenu();
        }
    }
}
