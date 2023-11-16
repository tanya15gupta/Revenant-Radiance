using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RevenantRadiance
{
    public class LoadingScreenUI : MonoBehaviour
    {
        private Loader loader;
        [SerializeField] private TMP_Text loadingContent;
        
        // Start is called before the first frame update
        public void Initialize(Loader loader)
        {
            this.loader = loader;
            this.loader.LoadingProgress += LoadingProgress;
            this.loader.OnSceneReady += OnSceneReady;
        }

        private void OnSceneReady()
        {
            loadingContent.text = "Press E to Continue";
        }

        private void LoadingProgress(float obj)
        {
            loadingContent.text = $"Loading ({((int)(obj * 100)).ToString()}%)";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
