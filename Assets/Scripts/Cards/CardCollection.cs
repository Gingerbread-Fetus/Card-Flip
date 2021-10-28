using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "CardCollection", menuName = "Card-Flip/Create New Card Set", order = 0)]
    public class CardCollection : ScriptableObject {
        [SerializeField] List<Card> cards;

        public List<Card> GetValidCards()
        {
            return cards;
        }
    }
}
