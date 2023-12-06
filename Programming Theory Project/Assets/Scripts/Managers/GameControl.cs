using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Encapsulation
    public static GameControl Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    [Serializable]
    class SaveData
    {
        private string bestPlayer { get; set; }
    }

    public void SaveGameInfo()
    {

    }

    public void LoadGameInfo()
    {

    }
}
