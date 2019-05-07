using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Models
{
  public class Shelter
  {
    private string _name;
    private int _id;
    private string _type;
    private string _breed;
    private DateTime _date;

    public Shelter(string name, string type, string breed, DateTime date, int id = 0)
    {
      _id = id;
      _name = name;
      _type = type;
      _breed = breed;
      _date = date;
    }

    public int GetId()
   {
     return _id;
   }

   public void SetId(int newId)
   {
     _id = newId;
   }

   public string GetName()
   {
     return _name;
   }

   public void SetName(string newName)
   {
     _name = newName;
   }

   public string GetType()
   {
     return _type;
   }

   public void SetType(string newType)
   {
     _type = newType;
   }
   public string GetBreed()
   {
     return _breed;
   }

   public void SetBreed(string newBreed)
   {
     _breed = newBreed;
   }
   public DateTime GetDate()
   {
     return _date;
   }

   public void SetDate(DateTime newDate)
   {
     _date = newDate;
   }

   public static List<Shelter> GetAll()
   {
     List<Shelter> allAnimals = new List<Shelter>{};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM shelter;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

     while (rdr.Read())
     {
       int shelterId = rdr.GetInt32(0);
       string shelterName = rdr.GetString(2);
       string shelterType = rdr.GetString(1);
       string shelterBreed = rdr.GetString(4);
       DateTime shelterDate = rdr.GetDateTime(3);
       Shelter newShelter= new Shelter (shelterName, shelterType, shelterBreed, shelterDate, shelterId);
       allAnimals.Add(newShelter);
     }

     conn.Close();

     if (conn != null)
     {
       conn.Dispose();
     }

     return allAnimals;

   }

   public void Save()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO shelter (name, type, breed, date) VALUES (@ShelterName, @ShelterType, @ShelterBreed, @ShelterDate);";
     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@ShelterName";
     name.Value = this._name;
     cmd.Parameters.Add(name);
     MySqlParameter type = new MySqlParameter();
     type.ParameterName = "@ShelterType";
     type.Value = this._type;
     cmd.Parameters.Add(type);
     MySqlParameter breed = new MySqlParameter();
     breed.ParameterName = "@ShelterBreed";
     breed.Value = this._breed;
     cmd.Parameters.Add(breed);
     MySqlParameter date = new MySqlParameter();
     date.ParameterName = "@ShelterDate";
     date.Value = this._date;
     cmd.Parameters.Add(date);
     cmd.ExecuteNonQuery();
     _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public override bool Equals(System.Object otherShelter)
    // {
    //   if (!(otherShelter is Shelter))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Shelter newShelter = (Shelter) otherShelter;
    //     bool idEquality = (this.GetId() == newShelter.GetId());
    //     bool typeEquality = (this.GetType() == newShelter.GetType());
    //     return (idEquality && typeEquality);
    //   }
    // }


   // public static List<City> SortAscending()
   // {
   //   List<City> allCitiesAscending = new List<City>{};
   //   MySqlConnection conn = DB.Connection();
   //   conn.Open();
   //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
   //   cmd.CommandText = @"SELECT id, name, population FROM city ORDER by population ASC;";
   //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
   //
   //   while (rdr.Read())
   //   {
   //     int cityId = rdr.GetInt32(0);
   //     string cityName = rdr.GetString(1);
   //     int cityPopulation = rdr.GetInt32(2);
   //     City newCity= new City (cityId ,cityName, cityPopulation);
   //     allCitiesAscending.Add(newCity);
   //   }
   //
   //   conn.Close();
   //
   //   if (conn != null)
   //   {
   //     conn.Dispose();
   //   }
   //
   //   return allCitiesAscending ;
   //
   // }
   //
   // public static List<City> SortDescending()
   // {
   //   List<City> allCitiesDescending = new List<City>{};
   //   MySqlConnection conn = DB.Connection();
   //   conn.Open();
   //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
   //   cmd.CommandText = @"SELECT id, name, population FROM city ORDER by population DESC;";
   //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
   //
   //   while (rdr.Read())
   //   {
   //     int cityId = rdr.GetInt32(0);
   //     string cityName = rdr.GetString(1);
   //     int cityPopulation = rdr.GetInt32(2);
   //     City newCity= new City (cityId ,cityName, cityPopulation);
   //     allCitiesDescending.Add(newCity);
   //   }
   //
   //   conn.Close();
   //
   //   if (conn != null)
   //   {
   //     conn.Dispose();
   //   }
   //
   //   return allCitiesDescending ;
   //
   // }





 }
}
