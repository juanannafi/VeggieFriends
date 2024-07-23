using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemMateri : MonoBehaviour
{
    [System.Serializable]

    public class DataMateri
    {
        public string Materi_Nama;
        public Sprite Materi_Gambar;
        public AudioClip Materi_Suara;
    }

    public List<DataMateri> _Data;

    [Header("Data Component")]
    public int Data_Materi;
    public Image Gambar_Materi;
    public Text Teks_NamaBuah;
    public Text Teks_Nomor;

    public AudioSource SourceSuara;


    // Start is called before the first frame update
    void Start()
    {
        Data_Materi = 0;
        v_SetMateri();
    }


    public void v_Tombol(bool ArahKanan)
    {
        if (ArahKanan)
        {
            Data_Materi++;


            if(Data_Materi >= _Data.Count)
            {
                Data_Materi = 0;
            }
        }
        else
        {
            if(Data_Materi == 0)
            {
                Data_Materi = _Data.Count - 1;
            }
            else
            {
                Data_Materi--;
            }
        }

        v_SetMateri();
        SistemKumpulanSuara.instance.v_SuaraSFX(0);
    }


    public void v_SetMateri()
    {
        Gambar_Materi.GetComponent<Animation>().Play("AnimasiTombol");
        Gambar_Materi.GetComponent<Animation>().Play("AnimasiBaru");
        //Gambar_Materi.GetComponent<Animation>().Play("AnimasiHome");
        //Gambar_Materi.GetComponent<Animation>().Play("AnimasiKiri");

        Gambar_Materi.sprite = _Data[Data_Materi].Materi_Gambar;
        Teks_NamaBuah.text = _Data[Data_Materi].Materi_Nama;


        v_SetSuara();
        v_PanggilSuara();

        Teks_Nomor.text = (Data_Materi + 1) + " / " + (_Data.Count);
    }

    public void v_SetSuara()
    {
        if(SourceSuara.clip != null && SourceSuara.isPlaying)
        {
            SourceSuara.Stop();
        }

        SourceSuara.clip = _Data[Data_Materi].Materi_Suara;
    }


    public void v_PanggilSuara()
    {
        if (SourceSuara.clip != null && SourceSuara.isPlaying)
        {
            SourceSuara.Stop();
        }

        SourceSuara.Play();
        SistemKumpulanSuara.instance.v_SuaraSFX(0);
    }
}
