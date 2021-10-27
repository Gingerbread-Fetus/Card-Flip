using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Deck", menuName = "Card-Flip/Create Deck", order = 0)]
    public class Deck : ScriptableObject 
    {
        public List<Card> cards;

        public List<Card> Shuffle()
        {
            List<Card> result = cards;
            for(int i = 0; i < result.Count;i++)
            {
                int pos = Random.Range(0,result.Count - i);
                Card tmp = result[pos+i];
                result[pos+i] = result[i];
                result[i] = tmp;
            }
            return result;
        } 
    }
}