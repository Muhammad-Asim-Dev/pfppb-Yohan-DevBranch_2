using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI ActionText;
    public TextMeshProUGUI playerNumberText;
    public TextMeshProUGUI playerUsernameText;

    public Button playerAttackButton;
    public Button playerHealButton;
    public Button playerDefendButton;
    public Button playerChargeButton;

    public Slider hpSlider;
    PlayerManager player;

    public Image PlayerPicture;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }

    public void SetMaxHealthSlider()
    {
        float sliderValue = GetNormalizedHP(player.HP, player.MaxHP);
        hpSlider.maxValue = sliderValue;
        hpSlider.value = sliderValue;
    }

    public void SetHealthSlider(int hp)
    {
        float sliderValue = GetNormalizedHP(hp, player.MaxHP);
        player.pv.RPC("SetHealthSliderRPC", RpcTarget.AllBuffered, hp, sliderValue);
    }

    [PunRPC]
    public void SetHealthSliderRPC(int hp, float sliderValue)
    {
        hpSlider.value = sliderValue;
        
    }
    public void SetActiveButtons(bool condition)
    {
        playerAttackButton.gameObject.SetActive(condition);
        playerHealButton.gameObject.SetActive(condition);
        playerDefendButton.gameObject.SetActive(condition);
        playerChargeButton.gameObject.SetActive(condition);
    }

    public void SetActiveTargetButtons(bool condition)
    {
        player.playerCombat.targetScript.playerUI.playerAttackButton.gameObject.SetActive(condition);
        player.playerCombat.targetScript.playerUI.playerHealButton.gameObject.SetActive(condition);
        player.playerCombat.targetScript.playerUI.playerDefendButton.gameObject.SetActive(condition);
        player.playerCombat.targetScript.playerUI.playerChargeButton.gameObject.SetActive(condition);
    }


    public void SetPlayerPicture()
    {
        if(gameObject.name == "Player1")
        {
            PlayerPicture.sprite =  Resources.Load<Sprite>("Sprites/$decimalist");
        }
        else
        {
            PlayerPicture.sprite = Resources.Load<Sprite>("Sprites/CardanoCroc1");
        }
    }

    public float GetNormalizedHP(int hp, int maxHealth)
    {
        return (float)hp / (float)maxHealth;
    }


}
