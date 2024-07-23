﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemUI : MonoBehaviour
{
    public void v_Btn_PindahScene(string NamaScene)
    {
        SceneManager.LoadScene(NamaScene);
    }

    public void v_Btn_RestartScene()
    {
        string NamaSceneSaatIni = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(NamaSceneSaatIni);
    }

    public void v_Suara(int id)
    {
        SistemKumpulanSuara.instance.v_SuaraSFX(id);
    }

    public void v_ExitGame()
    {
        Application.Quit();
    }
}
