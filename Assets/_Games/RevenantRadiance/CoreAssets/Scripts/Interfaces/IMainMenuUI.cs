using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance
{
    public interface IMainMenuUI
    {
        public void Initialize(IMainMenu mainMenu);
        public void Enable();
        public void Disable();
    }
}
