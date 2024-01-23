// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using System.Data;
// using Mono.Data.Sqlite;
// using UnityEngine.UI;
// using SQLite;
// using System.Linq;

// public class Car {
//     [PrimaryKey, AutoIncrement]
//     public int id { get; set; }
//     public string name { get; set; }
//     public string model_path { get; set; }
// }

// public class DBTest : MonoBehaviour
// {
//     // public SqliteConnection connection;
//     // public string path;

//     public Button nextCar;
//     public Button prevCar;

//     public Text carName;

//     private int carIndex;
//     private IEnumerable<Car> carList;

//     public Transform carSpawn;

//     private void Start() {
//         getData();
//         nextCar.onClick.AddListener(() => ShowNextCar());
//         prevCar.onClick.AddListener(() => ShowPrevCar());
//     }

//     public void ShowNextCar() 
//     {
//         if(carIndex < carList.Count() - 1)
//         {
//             carIndex++;
//         }
//         Debug.Log(carIndex);
//         ShowCurrentCar();
//     }

//     public void ShowPrevCar()
//     {
//         if(carIndex > 0 )
//         {
//             carIndex--;
//         }
//         Debug.Log(carIndex);
//         ShowCurrentCar();
//     }

//     public void ShowCurrentCar()
//     {
//         if (carIndex < 0 || carIndex >= carList.Count())
//         {
//             Debug.Log("No car to display");
//             return;
//         }
//         Car currentCar = carList.ElementAt(carIndex);
//         const string frmt = "ID: {0}; Name: {1};";
//         carName.text = currentCar.name;
//         if(carSpawn.childCount > 0)
//         {
//             Destroy(carSpawn.GetChild(0).gameObject);
//         }
        
        
        
//         var prefab = Resources.Load("Prefabs/" + currentCar.model_path) as GameObject;
//         Instantiate(prefab, carSpawn);
//         carSpawn.GetChild(0).GetComponent<CarController2>().enabled = false;
//     }
    

//     public void getData()
//     {
//         using (var db = new SQLiteConnection(Application.dataPath + "/DB/drift_arcade.db"))
//         {
//             IEnumerable<Car> list = db.Query<Car>("SELECT * FROM Cars");
//             carList = list;
//             carIndex = 0;
//             // IEnumerable<Car> list = db.Query<Car>("SELECT * FROM Cars");
//             // carList = list;
//             // carIndex = 0;
//             // foreach (Car car in list)
//             // {
//             //     const string frmt = "ID: {0}; Name: {1};";
//             //     Debug.Log(string.Format(frmt,
//             //         car.id,
//             //         car.name
//             //        ));
//             // }
//             ShowCurrentCar();
//         }
//         // path = Application.dataPath + "/DB/test.db";
//         // connection = new SqliteConnection("Data Source=" + path);
//         // connection.Open();
//         // if(connection.State == ConnectionState.Open)
//         // {
//         //     SqliteCommand command = new SqliteCommand();
//         //     command.Connection = connection;
//         //     command.CommandText  = "SELECT * FROM Cars";
//         //     SqliteDataReader reader = command.ExecuteReader();
//         //     Debug.Log(reader.FieldCount);
//         //     if(reader.FieldCount > 0)
//         //     {
//         //         while (reader.Read())
//         //         {
//         //             Debug.Log(String.Format("{0}: {1}", reader[0], reader[1]));
//         //         }
//         //     }
//         //     else 
//         //     {
//         //         Debug.Log("Empty");
//         //     }
//         // } else 
//         // {
//         //     Debug.Log("Error");
//         // }
//     }
// }
