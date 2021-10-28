using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIWagerOverlay : MonoBehaviour
    {
        void Awake() 
        {
            if(gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
