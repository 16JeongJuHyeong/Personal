﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLobby : MonoBehaviour
{
    public void Load_Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}