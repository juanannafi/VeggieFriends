using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Musik : MonoBehaviour
{
    public Sprite[] GambarTombol;
    public Image Tombol;
    public Text TeksTombol;

    private void OnEnable()
    {
        if (SistemKumpulanSuara.instance.SourceSuaraMusik.isPlaying)
        {
            Tombol.sprite = GambarTombol[0];
            TeksTombol.text = "Musik On";
        }
        else
        {
            Tombol.sprite = GambarTombol[1];
            TeksTombol.text = "Musik Off";
        }

    }

    public void v_BtnMusik()
    {
        SistemKumpulanSuara.instance.v_SuaraSFX(0);
        if (SistemKumpulanSuara.instance.SourceSuaraMusik.isPlaying)
        {
            SistemKumpulanSuara.instance.SourceSuaraMusik.Pause();
            Tombol.sprite = GambarTombol[1];
            TeksTombol.text = "Musik Off";
        }
        else
        {
            SistemKumpulanSuara.instance.SourceSuaraMusik.UnPause();
            Tombol.sprite = GambarTombol[0];
            TeksTombol.text = "Musik On";
        }
    }
}
