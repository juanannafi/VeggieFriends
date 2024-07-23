using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemScore : MonoBehaviour
{
    public int DataTotalScore;

    public Image GambarInfoAtas;
    public Sprite[] GambarInfo;

    public Text TeksScore;
    public Text TeksScoreTertinggi;

    int TargetScore = 1100;

   
    private void OnEnable()
    {
        DataTotalScore = SistemGame.DataScore;

        TeksScore.text = DataTotalScore.ToString("N0");

        if(DataTotalScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", DataTotalScore);
        }

        TeksScoreTertinggi.text = PlayerPrefs.GetInt("Score").ToString("N0");

        if(DataTotalScore >= TargetScore)
        {
            GambarInfoAtas.sprite = GambarInfo[0];
            SistemKumpulanSuara.instance.v_SuaraSFX(4);
        }
        else
        {
            GambarInfoAtas.sprite = GambarInfo[1];
            SistemKumpulanSuara.instance.v_SuaraSFX(5);
        }
    }


}
