using System;
using System.Collections.Generic;
using MySqlConnector;
namespace PolarPandaWebAPI
{
class DBSystem
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBSystem()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        server = "20.62.161.245";
        database = "plrpndadb";
        uid = "bcknd";
        password = "890708#Keith";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    public bool OpenConnection()
    {
          try
    {
        connection.Open();
        return true;
    }
    catch (MySqlException ex)
    {
        //When handling errors, you can your application's response based 
        //on the error number.
        //The two most common error numbers when connecting are as follows:
        //0: Cannot connect to server.
        //1045: Invalid user name and/or password.
        switch (ex.Number)
        {
            case 0:
                Console.WriteLine("Cannot connect to server.  Contact administrator");
                break;

            case 1045:
                Console.WriteLine("Invalid username/password, please try again");
                break;
        }
        return false;
    }
    }

    //Close connection
    public bool CloseConnection()
    {

    try
    {
        connection.Close();
        return true;
    }
    catch (MySqlException ex)
    {
       
        return false;
    }
    }
    public int GetPlayerGold(int twitchId)
    {
        int gold = 0;
        using var command = new MySqlCommand("SELECT twitchid,gold FROM players WHERE twitchid=" + twitchId  + ";", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            gold = (int)reader.GetValue(1);
        }
        return gold;
    }
    public void Test()
    {
   
        using var command = new MySqlCommand("SELECT twitchid,gold FROM players;", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("userid: " + reader.GetValue(0) + " gold: " + reader.GetValue(1));
            // do something with 'value'
        }
    }
    //Insert statement
    public void Insert()
    {
    }

    //Update statement
    public void Update()
    {
    }

    //Delete statement
    public void Delete()
    {
    }

    //Select statement
    public List <string> [] Select()
    {
        return null;
    }

    //Count statement
    public int Count()
    {
        return 0;
    }

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
}
}
