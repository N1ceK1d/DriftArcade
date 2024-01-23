using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using SQLite;
using System.Linq;

public class CreateUser : MonoBehaviour
{
    public GameObject create_player;
    public GameObject main_menu;
    public InputField inputName;

    private void Start()
    {
        if(PlayerPrefs.HasKey("id"))
        {
            create_player.SetActive(false);
            main_menu.SetActive(true);
        }
    }

    public void CreatePlayer()
    {
        using (var db = new SQLiteConnection(Application.dataPath + "/DB/drift_arcade.db"))
        {
            string query = $"INSERT INTO Player (name, money) VALUES ('{inputName.text}', 0)";
            db.Execute(query);
            
            string getLastIdQuery = "SELECT last_insert_rowid()";
            int lastId = db.ExecuteScalar<int>(getLastIdQuery);
            PlayerPrefs.SetInt("id", lastId);
            PlayerPrefs.Save();
            Debug.Log(lastId); 
            create_player.SetActive(false);
            main_menu.SetActive(true);
        }
    }
}
