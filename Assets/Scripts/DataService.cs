using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using SQLite;

public class DataService 
{
    public SQLiteConnection _connection;

    public DataService(string databaseName)
    {
        string dbPath;

    #if UNITY_EDITOR
        dbPath = $"Assets/StreamingAssets/{databaseName}";
    #else
        dbPath = $"{Application.persistentDataPath}/{databaseName}";

        if (!File.Exists(dbPath))
        {
            Debug.Log("Database not in Persistent path");

        #if UNITY_ANDROID 
            var loadDb = new WWW($"jar:file://{Application.dataPath}!/assets/{databaseName}");
            while (!loadDb.isDone) { }
            File.WriteAllBytes(dbPath, loadDb.bytes);
        #else
            var loadDb = $"{Application.dataPath}/StreamingAssets/{databaseName}";
            File.Copy(loadDb, dbPath);
        #endif

            Debug.Log("Database written");
        }
    #endif

            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        
        Debug.Log("Final PATH: " + dbPath);     
    }
}