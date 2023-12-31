using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELORankingCalculation : MonoBehaviour
{
    // returns probability of winning for player 1
    public static float GetProbabilityWinning(float ratingPlayer1, float ratingPlayer2)
    {
        return 1f / (1f + Mathf.Pow(10f, (ratingPlayer2 - ratingPlayer1) / 400f));
    }
    public /*static*/ Vector2 UpdatePlayerRankings(float ratingPlayer1, float ratingPlayer2,
        float multiplier,// it is the number of game played
        bool isPlayer1Winner)
    {

        float probabilityWinPlayer1 = GetProbabilityWinning(ratingPlayer1, ratingPlayer2);

        if (isPlayer1Winner)
        {
            ratingPlayer1 += multiplier * (1 - probabilityWinPlayer1);
            // 0 - probabilityWinPlayer2 =  probabilityWinPlayer1 - 1
            ratingPlayer2 += multiplier * (probabilityWinPlayer1 - 1);
        }
        else
        {
            ratingPlayer1 += multiplier * (-probabilityWinPlayer1);
            // 1 - probabilityWinPlayer2 = 1 - (1 - probabilityWinPlayer1) = probabilityWinPlayer1
            ratingPlayer2 += multiplier * probabilityWinPlayer1;
        }

        return new Vector2(ratingPlayer1, ratingPlayer2);
    }
}
