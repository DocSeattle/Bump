using System;
using System.Text;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Bump.Register
{
  public class RegisterUser
  {
    /// <summary>
    /// Take inputs, those being Username & Password
    /// Hash them, confirm that Password is the intended password.
    /// Then push this to the User database as a new item.
    /// </summary>
    /// <param name="unhashed">String input for hashing.</param>
    /// <returns></returns>
    // Connection string: "Data Source=.;Initial Catalog=RegisterTestDB;'Server=(localdb)\\localdb;Database=RegisterTestDB;Integrated Security=true;"
    public static void RegisterAndPush()
    {
      string connectionString;
      connectionString = "Data Source=.;Initial Catalog=RegisterTestDB;'Server=(localdb)\\localdb;Database=RegisterTestDB;Integrated Security=true;";

      Console.WriteLine("Give me a username");
      string username = Console.ReadLine()!;
      Console.WriteLine("Give me a password");
      string password = HashWithSHA256(Console.ReadLine()!);
      Console.WriteLine("Confirm password");
      string passwordConfirm = HashWithSHA256(Console.ReadLine()!);
      if (password != passwordConfirm)
      {
        throw new Exception("Inputs do not match!");
      }
      try
      {
      using (SqlConnection cnn = new SqlConnection(connectionString))
      {
        SqlCommand oCmd = new SqlCommand(
          "INSERT INTO [RegisterTestDB].[dbo].[Logins] (Username, Password)"
          +
          $"VALUES ({username}, {password})");
  
        // IF NOT EXISTS username IN Logins.username
      }
        //check if username exists already.
        // if username exists in dbo.Logins, throw error. Else continue:
        // Add information to database.
      }
      catch
      {

      }
    }

    public static string HashWithSHA256(string unhashed)
    // this code was lifted from Stack Overflow. Thanks to S. Johnson and A. Alvand
    // https://stackoverflow.com/questions/16999361/obtain-sha-256-string-of-a-string
    {
      using var hash = SHA256.Create();
      var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(unhashed));
      return Convert.ToHexString(byteArray);
    }
  }



  // This is for changing user information like name or password.
  public class ReregisterUser
  {

  }
}

