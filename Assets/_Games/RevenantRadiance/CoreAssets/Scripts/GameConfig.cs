using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RevenantRadiance.Core
{
    public class GameConfig : MonoBehaviour, IGameConfig
    {
        public static IGameConfig Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        public static void RuntimeInit()
        {
            Instantiate(Resources.Load<GameObject>("GameConfig"));
            Instantiate(Resources.Load<GameObject>("GameStateHandler"));
        }

        protected void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("A instance already exists");
                Destroy(this); //Or GameObject as appropriate
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


        
        /// <summary>
        /// Method to call when exiting a game. Do All Game Quit realted things from here
        /// </summary>
        public void ExitGame()
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
            Application.Quit();
        }
    }
}
