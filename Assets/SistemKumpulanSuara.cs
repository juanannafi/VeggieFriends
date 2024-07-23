using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemKumpulanSuara : MonoBehaviour
{
    public static SistemKumpulanSuara instance;
    public AudioClip[] DataSuara;
    public AudioSource SourceSuaraSFX;
    public AudioSource SourceSuaraMusik;


    private void OnEnable()
    {
        if(instance == null)
        {
            Application.targetFrameRate = 60;
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void v_SuaraSFX(int IDSuara)
    {
        if (IDSuara >= 0 && IDSuara < DataSuara.Length) // Periksa apakah IDSuara berada dalam rentang yang benar
        {
            Debug.Log("Memutar suara dengan ID: " + IDSuara);
            SourceSuaraSFX.PlayOneShot(DataSuara[IDSuara]);
        }
        else
        {
            Debug.LogWarning("ID Suara tidak valid: " + IDSuara);
        }

    }
}
