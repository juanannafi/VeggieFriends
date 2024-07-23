using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemGame : MonoBehaviour
{
    public static SistemGame instance;
    public static int IDGame;
    public int IDKartu;


    [Header("Data Permainan")]
    public int DataTargetKartu;
    public static int DataScore = 0;
    public static int DataDarah = 5;

    [Header("Komponen UI")]
    public GameObject CanvasPause;
    public Text TeksLevel;
    public Text TeksScore;
    public RectTransform GambarDarah;

    [Header("Sistem Kartu")]
    public Transform TempatKartu;
    public GameObject KartuBuah;
    public Tempat_Drop[] KartuDrop;
    public Sprite[] GambarKartu;

    [Header("Sistem Acaknya")]
    public List<int> AcakSoal = new List<int>();
    public List<int> AcakUrutanMuncul = new List<int>();


    private void OnEnable()
    {
        instance = this;
        v_SetDataAwal();
        v_AcakSoal();
        //v_AcakUrutanMuncul();
    }


    public void v_SetDataAwal()
    {
        IDKartu = 0;
        DataTargetKartu = KartuDrop.Length;

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game0")
        {
            DataScore = 0;
            DataDarah = 5;
            IDGame = 0;
        }

        v_SetUI();
    }

    public void v_SetUI()
    {
        TeksLevel.text = (IDGame + 1 ).ToString();
        TeksScore.text = DataScore.ToString("N0");
        GambarDarah.sizeDelta = new Vector2(20f * DataDarah, 18f);
    }


    public void v_AcakSoal()
    {
        AcakSoal.Clear();
        AcakSoal = new List<int>(new int[KartuDrop.Length]);
        int Rand = 0;
        for(int i = 0; i < AcakSoal.Count; i++)
        {
            Rand = (Random.Range(1, GambarKartu.Length));

            while (AcakSoal.Contains(Rand))
            {
                Rand = (Random.Range(1, GambarKartu.Length));
            }

            AcakSoal[i] = Rand;

            KartuDrop[i].IDDrop = Rand - 1;
            KartuDrop[i].SR.sprite = GambarKartu[Rand - 1];
        }

        v_AcakUrutanMuncul();
    }


    public void v_AcakUrutanMuncul()
    {
        AcakUrutanMuncul.Clear();
        AcakUrutanMuncul = new List<int>(new int[KartuDrop.Length]);

        int Rand = 0;
        for (int i = 0; i < AcakUrutanMuncul.Count; i++)
        {
            Rand = Random.Range(1, AcakUrutanMuncul.Count + 1);

            while (AcakUrutanMuncul.Contains(Rand))
                Rand = Random.Range(1, AcakUrutanMuncul.Count + 1);

            AcakUrutanMuncul[i] = Rand;
        }

        v_SetKartuDrag();
    } 


    public void v_SetKartuDrag()
    {
        if(IDKartu < DataTargetKartu)
        {
            GameObject Kartu = Instantiate(KartuBuah);
            Kartu.transform.position = TempatKartu.position;
            Kartu.transform.localScale = TempatKartu.localScale;

            Sistem_Drag SistemKartuDrag = Kartu.GetComponent<Sistem_Drag>();
            int DataKartu = AcakSoal[ AcakUrutanMuncul[IDKartu] - 1 ] - 1;
            SistemKartuDrag.IDDrag = DataKartu;
            SistemKartuDrag.SR.sprite = GambarKartu[DataKartu];
            SistemKartuDrag.SavePos = TempatKartu.position;
        }
        else
        {
            SistemKumpulanSuara.instance.v_SuaraSFX(3);
            IDGame++;

            StartCoroutine(JedaPindah());
            IEnumerator JedaPindah()
            {
                yield return new WaitForSeconds(1f);

                int TargetLevel = 5;
                if(IDGame >= TargetLevel) // Max 5 Level
                {
                    Debug.Log("Game Finish");
                    IDGame = TargetLevel -1;
                    v_SetUI();

                    SceneManager.LoadScene("GameSelesai");
                }
                else
                {
                    string TargetSceneSelanjutnya = "Game" + IDGame;
                    SceneManager.LoadScene(TargetSceneSelanjutnya);
                }
            }


        }

        v_SetUI();

    }
}
