namespace Cards
{
    using UnityEngine;
    using UnityEngine.UI;

    [CreateAssetMenu(fileName = "Card", menuName = "Card-Flip/Create New Card", order = 0)]
    public class Card : ScriptableObject 
    {
        [SerializeField] Image cardImage;
        [SerializeField] Suit suit;
        public int value = 1;

        public Image CardImage {get => cardImage;}
        public Suit Suit { get => suit;}
    }
}
