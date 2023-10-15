using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceCollectables : MonoBehaviour
{
    public TMP_Text heartsNumber;
    public TMP_Text coinsNumber;
    public TMP_Text gemsNumber;
    public TMP_Text keysNumber;
    public PlayerEq eq;
    void Start()
    {
        Update();
    }

   
    void Update()
    {
        heartsNumber.text = eq.hearts.ToString();
        coinsNumber.text = eq.coins.ToString();
        gemsNumber.text = eq.gems.ToString();
        keysNumber.text = eq.keys.ToString();
    }
}
