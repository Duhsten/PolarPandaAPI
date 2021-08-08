using System;
using System.Collections.Generic;
using MySqlConnector;
namespace PolarPandaWebAPI {
  class DBSystem {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBSystem() {
      Initialize();

    }

    //Initialize values
    private void Initialize() {
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
    public bool OpenConnection() {
      try {
        connection.Open();
        return true;
      } catch (MySqlException ex) {
        //When handling errors, you can your application's response based 
        //on the error number.
        //The two most common error numbers when connecting are as follows:
        //0: Cannot connect to server.
        //1045: Invalid user name and/or password.
        switch (ex.Number) {
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
    public bool CloseConnection() {

      try {
        connection.Close();
        return true;
      } catch (MySqlException ex) {

        return false;
      }
    }
    public int GetPlayerGold(int twitchId) {
      int gold = 0;
      using
      var command = new MySqlCommand("SELECT twitchid,gold FROM players WHERE twitchid=" + twitchId + ";", connection);
      using
      var reader = command.ExecuteReader();
      while (reader.Read()) {
        gold = (int) reader.GetValue(1);
      }
      return gold;
    }
    public PlayerInfo GetUserInfo(int twitchId) {
      PlayerInfo gui = new PlayerInfo();
      using
      var command = new MySqlCommand("SELECT * FROM players WHERE twitchid=" + twitchId + ";", connection);
      using
      var reader = command.ExecuteReader();
      while (reader.Read()) {

        gui.twitchID = (int) reader.GetValue(1);
        gui.displayName = (string) reader.GetValue(2);
        gui.avatarURL = (string) reader.GetValue(3);
        gui.gold = (int) reader.GetValue(4);
      }
      return gui;
    }
    public bool UpdateUserInfo(PlayerInfo plyInfo) {
      int twitchID = 0;
      string displayName = "";
      string avatar_url = "";
      int gold = 0; 
      using
      var command = new MySqlCommand("SELECT * FROM players WHERE twitchid=" + plyInfo.twitchID + ";", connection);

      using
      var reader = command.ExecuteReader();
      while (reader.Read()) {

        twitchID = (int) reader.GetValue(1);
        displayName = (string) reader.GetValue(2);
        avatar_url = (string) reader.GetValue(3);
        gold = (int) reader.GetValue(4);

      }
      if (twitchID == 0) {
        CloseConnection();
        OpenConnection();
        using
        var command2 = new MySqlCommand("INSERT INTO players (twitchid, display_name, avatar_url, gold) VALUES ('" + plyInfo.twitchID + "', '" + plyInfo.displayName + "', '" + plyInfo.avatarURL + "', '" + plyInfo.gold + "');", connection);
        using
        var reader2 = command2.ExecuteReader();
        while (reader2.Read()) {

          twitchID = (int) reader2.GetValue(1);

        }
      }
      else if (twitchID == plyInfo.twitchID)
      {
          string sqlString = "SET ";
          if(displayName != "" && displayName != "null")
          {
              sqlString = sqlString + "display_name = '" + displayName + "', ";
          }
          if(avatar_url != "" && avatar_url != "null")
          {
              sqlString = sqlString + "avatar_url = '" + avatar_url + "', ";
          }
         if(gold != plyInfo.gold)
          {
              sqlString = sqlString + "gold = " + gold + "";
          }
            sqlString.TrimEnd(' ', ',' , '<');
                 CloseConnection();
        OpenConnection();
        Console.WriteLine(sqlString);
        using
        var command2 = new MySqlCommand("UPDATE players " + sqlString + " WHERE twitchid=" + twitchID + ";", connection);
        using
        var reader2 = command2.ExecuteReader();
        while (reader2.Read()) {

          twitchID = (int) reader2.GetValue(1);

        }
      }
      return true;
    }
    public NewsInfo GetNewsInfo() {
      NewsInfo newsInfo = new NewsInfo();
      using
      var command = new MySqlCommand("SELECT * FROM news;", connection);
      using
      var reader = command.ExecuteReader();
      while (reader.Read()) {
        newsInfo.id = (int) reader.GetValue(0);
        newsInfo.title = (string) reader.GetValue(1);
        newsInfo.content = (string) reader.GetValue(2);
        newsInfo.date = (DateTime) reader.GetValue(3);
      }
      return newsInfo;
    }
    public void Test() {

      using
      var command = new MySqlCommand("SELECT twitchid,gold FROM players;", connection);
      using
      var reader = command.ExecuteReader();
      while (reader.Read()) {
        Console.WriteLine("userid: " + reader.GetValue(0) + " gold: " + reader.GetValue(1));
        // do something with 'value'
      }
    }
    //Insert statement
    public void Insert() {}

    //Update statement
    public void Update() {}

    //Delete statement
    public void Delete() {}

    //Select statement
    public List < string > [] Select() {
      return null;
    }

    //Count statement
    public int Count() {
      return 0;
    }

    //Backup
    public void Backup() {}

    //Restore
    public void Restore() {}
  }
}