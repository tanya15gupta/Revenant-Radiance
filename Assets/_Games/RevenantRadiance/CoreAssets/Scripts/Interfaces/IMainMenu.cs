using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance
{
    public interface IMainMenu
    {
        internal void LoadSelectGamePanel();

        internal void LoadOptionsPanel();

        internal void ExitGame();

        internal void LoadMainMenu();
    }
}
