using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 각각의 고유한 Marker Card ID값.
/// </summary>
class CardInfo
{
    // 카드의 고유 ID 상수로 지정
    public const int CARD0 = -507369470;
    public const int CARD1 = -251372376;
    public const int CARD2 = -361791111;
    public const int CARD3 = 920965051;
    public const int CARD4 = 704129356;
    public const int CARD5 = 655826756;



    // 카드의 고유 ID
    public static int [] card = {CARD0 , CARD1, CARD2, CARD3, CARD4, CARD5};
    // 카드 Check 
    public static bool[] cardExposedCheck = { false, false, false, false, false, false };

    public static void SetALLCardFlagsFalse()
    {
        int i; 
        for(i=0;i< card.Length; i++)
        {
            cardExposedCheck[i] = false;
        }
    }

    // 화면에 표출되는 카드값을 비교하여 cardExposedCheck를 true로 바꿔주는 함수
    public static void CheckID(int currentCardExposedCardID)
    {
        int i;
        for (i = 0; i < card.Length; i++)
        {
            if (card[i] == currentCardExposedCardID) //카드값 id와 현재 화면에 표출되는 카드값 id와 같다면
            {
                cardExposedCheck[i] = true; //해당 카드의 id값을 true로 바꾼다.
            }
        }

    }

    // 어떤 카드가 노출 되었는지 확인하기
    public static string PrintIsCardCheck()
    {
        int i;
        for (i = 0; i < card.Length; i++)
        {
            if(cardExposedCheck[i] == true) //카드들 중에 화면에 보여줬던 카드의 정보를 표시한다.
            {
                string str = "card " + i + "인 ID:" + card[i] + "가 " + cardExposedCheck[i] + "입니다.";
                return str;
            }
        }
        return " ";
        
    }

    //화면에 보여주고있는 마커의 해당 index 리턴한다.
    public static int GetCurrentTrueIndex()
    {
        int i;
        for (i = 0; i < card.Length; i++)
        {
            if(cardExposedCheck[i] == true)
            {
                return i;
            }
        }
        //모두 false면 -1을 리턴한다
        return -1;
    }


}