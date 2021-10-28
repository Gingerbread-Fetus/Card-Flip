using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    [SerializeField] Wallet wallet;
    // Start is called before the first frame update
    TMP_Text textCmp;
    private void Awake() {
        textCmp = GetComponent<TMP_Text>();
        textCmp.text = wallet.coins.ToString();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCmp.text = wallet.coins.ToString();
    }
}
