using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if UNITY_WEBGL
public class WebglDespositToken : MonoBehaviour
{
    public TMP_Text Log;
    async public void OnSendTransaction()
    {
        // account to send to
        string to = "0xb6eeA2ACbf8B8b809879f877F287d5B4Cf1C4986";
        // amount in wei to send
        string value = "12300000000000000";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try
        {
            string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
            Debug.Log(response);
            Log.text = response;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Log.text = "Error";
        }
    }
}
#endif