using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CardButton : MonoBehaviour
    {
        [SerializeField] Image backImage;
        
        Image frontImage;
        public void SetImage(Image newImage)
        {
            frontImage = newImage;
        }

        //TODO Remove this later, replace it with a method to reveal the image.
        [SerializeField] TMP_Text textCmp;
        public void ChangeText(string newText)
        {
            textCmp.text = newText;
        }
    }
}