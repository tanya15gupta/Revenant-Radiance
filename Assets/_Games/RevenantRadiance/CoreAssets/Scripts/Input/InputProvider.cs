using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance.Core.Input
{
    public class InputProvider
    {
        private static RevenantRadianceInput _input;

        public static RevenantRadianceInput  Input
        {
            get
            {
                if (_input == null)
                {
                    _input = new RevenantRadianceInput();
                }
                return _input;
            }
        }
    }
}
