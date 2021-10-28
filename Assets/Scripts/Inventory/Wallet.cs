using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Wallet", menuName = "Card-Flip/Create New Wallet", order = 0)]
    public class Wallet : ScriptableObject 
    {
        public int coins = 100;
    }
}
