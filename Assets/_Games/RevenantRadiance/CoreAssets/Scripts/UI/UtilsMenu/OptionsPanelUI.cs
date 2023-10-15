using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RevenantRadiance.Core.UI
{
    public class OptionsPanelUI : MonoBehaviour, IMainMenuUI
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private GameObject firstSelected;

        [Header("Buttons")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button defaultsButton;
        [SerializeField] private Button applyButton;

        private IMainMenu _mainMenu;
        
        public void Initialize(IMainMenu mainMenu)
        {
            _mainMenu = mainMenu;
            
            backButton.onClick.AddListener(OnBackClicked);
            defaultsButton.onClick.AddListener(OnResetToDefualtsClicked);
            applyButton.onClick.AddListener(OnApplyClicked);
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

        public void OnBackClicked()
        {
            _mainMenu.LoadMainMenu();
        }
        
        public void OnApplyClicked()
        {
            
        }

        public void OnResetToDefualtsClicked()
        {
            
        }
    }
}
