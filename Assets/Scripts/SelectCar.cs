using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using SQLite;
using System.Linq;

public class Car {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public string model_path { get; set; }
    public int price { get; set; }
    public float max_speed { get; set; }
    public float traction { get; set; }
}

public class Player {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public int money { get; set; } 
}

public class PlayerCar {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int player_id { get; set; }
    public int car_id { get; set; }
    public string car_color { get; set; }
    public int is_used { get; set; }
}

public class SelectCar : MonoBehaviour
{
    // public SqliteConnection connection;
    // public string path;

    public Button nextCar;
    public Button prevCar;

    public Text carName;

    private int carIndex;
    private IEnumerable<Car> carList;

    public Transform carSpawn;

    private void Start() {
        getData();
        nextCar.onClick.AddListener(() => ShowNextCar());
        prevCar.onClick.AddListener(() => ShowPrevCar());
    }

    public void ShowNextCar() 
    {
        if(carIndex < carList.Count() - 1)
        {
            carIndex++;
        }
        Debug.Log(carIndex);
        ShowCurrentCar();
    }

    public void ShowPrevCar()
    {
        if(carIndex > 0 )
        {
            carIndex--;
        }
        Debug.Log(carIndex);
        ShowCurrentCar();
    }

    public void ShowCurrentCar()
    {
        if (carIndex < 0 || carIndex >= carList.Count())
        {
            Debug.Log("No car to display");
            return;
        }
        Car currentCar = carList.ElementAt(carIndex);
        const string frmt = "ID: {0}; Name: {1};";
        // carName.text = currentCar.name;
        if(carSpawn.childCount > 0)
        {
            Destroy(carSpawn.GetChild(0).gameObject);
        }
        PlayerPrefs.SetString("car_prefab", "Prefabs/" + currentCar.model_path);
        PlayerPrefs.Save();
        var prefab = Resources.Load("Prefabs/" + currentCar.model_path) as GameObject;
        Instantiate(prefab, carSpawn);
    }
    

    public void getData()
    {
        using (var db = new SQLiteConnection(Application.dataPath + "/DB/drift_arcade.db"))
        {
            IEnumerable<Car> list = db.Query<Car>("SELECT * FROM Cars");
            carList = list;
            carIndex = 0;
            ShowCurrentCar();
        }
    }

    public void GetPlayerCars ()
    {
        using (var db = new SQLiteConnection(Application.dataPath + "/DB/drift_arcade.db"))
        {
            IEnumerable<Car> list = db.Query<Car>(String.Format("SELECT * FROM PlayerCars INNER JOIN Cars ON PlayerCars.car_id = Cars.id WHERE player_id = ${0};", PlayerPrefs.GetInt("player_id")));

        }
    }
}
