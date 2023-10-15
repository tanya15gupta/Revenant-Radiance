/*
*  Author: Rutvij
*  Created On: 20-06-2021 17:36:26
* 
*  Copyright (c) 2021 ArcadeBox
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RevenantRadiance
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"> Class name</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("A instance already exists");
                Destroy(this); //Or GameObject as appropriate
                return;
            }
            Instance = this.GetComponent<T>();
        }
    }
}

