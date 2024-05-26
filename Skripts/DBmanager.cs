using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager
{
    public static string username;
    public static int score;
    public static int x;
    public static int y;
    public static int z;
    public static bool LoggedIn { get { return username != null; } }
    public static void LogOut()
    {
        username = null;
    }
}
