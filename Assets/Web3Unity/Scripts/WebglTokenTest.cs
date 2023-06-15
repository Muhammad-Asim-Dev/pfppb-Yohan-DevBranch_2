using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Web3Unity.Scripts.Library.Ethers.Providers;
using TMPro;
using UnityEngine;

#if UNITY_WEBGL
public class WebglTokenTest : MonoBehaviour
{
    public TMP_Text Calling;
    async public void AddOneToVariable()
    {
        string contractAbi = "[{\"inputs\":[{\"internalType\":\"address\",\"name\":\"TokenAddress\",\"type\":\"address\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{ \"anonymous\":false,\"inputs\":[{ \"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{ \"inputs\":[],\"name\":\"ContractOwner\",\"outputs\":[{ \"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{ \"inputs\":[{ \"internalType\":\"uint256\",\"name\":\"Amount\",\"type\":\"uint256\"}],\"name\":\"DepositToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{ \"inputs\":[],\"name\":\"Rate\",\"outputs\":[{ \"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{ \"inputs\":[],\"name\":\"RateUsdt\",\"outputs\":[{ \"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{ \"inputs\":[{ \"internalType\":\"address payable\",\"name\":\"_receiver\",\"type\":\"address\"},{ \"internalType\":\"uint256\",\"name\":\"_Amount\",\"type\":\"uint256\"}],\"name\":\"TransferETH\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{ \"inputs\":[{ \"internalType\":\"contract IERC20\",\"name\":\"newtoken\",\"type\":\"address\"}],\"name\":\"change_token\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{ \"inputs\":[],\"name\":\"token\",\"outputs\":[{ \"internalType\":\"contract IERC20\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{ \"inputs\":[],\"name\":\"usdt\",\"outputs\":[{ \"internalType\":\"contract IERC20\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{ \"inputs\":[{ \"internalType\":\"uint256\",\"name\":\"_amount\",\"type\":\"uint256\"}],\"name\":\"withDrawBNB\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{ \"inputs\":[{ \"internalType\":\"contract IERC20\",\"name\":\"_addr\",\"type\":\"address\"},{ \"internalType\":\"uint256\",\"name\":\"_amount\",\"type\":\"uint256\"}],\"name\":\"withDrawUSDT\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        // address of contract
        string contractAddress = "0xb6eeA2ACbf8B8b809879f877F287d5B4Cf1C4986";
        string method = "DepositToken"; //DepositToken
        string amount = "1";
        string[] obj = { amount };
        string args = JsonConvert.SerializeObject(obj);
        try
        {
            string response = await Web3GL.SendContract(method, contractAbi, contractAddress, args, "0", "", "");
            // display response in game
            print("Please check the contract variable again in a few seconds once the chain has processed the request!");
            Calling.text = response;
        }
        catch (Exception ex)
        {
            Calling.text = ex.Message + "Error";
        }

    }
}
#endif