using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletAddress : MonoBehaviour
{
    public TMP_Text Address;
    void Start()
    {
        Address.text = PlayerPrefs.GetString("Account");
    }

}
