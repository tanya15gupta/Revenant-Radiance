using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance.Core
{
    
    public enum GameStates
    {
        None,
        Init,
        Loading,
        MainMenu,
        Game
    }

    public enum InputMaps
    {
        Menu,
        //MainMenu
        LoadGame,
        Options,
        //Game
        Map,
        InGame
    }
    
    public abstract class GameState : MonoBehaviour
    {
        public virtual GameStates Type { get; protected set; }

        public virtual void Initialize(params object[] stateParams) { }
        
        public virtual void EnterState() { }

        public virtual void ExitState() { }
    }
}
