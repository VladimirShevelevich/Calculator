using UnityEngine;

namespace App.Scripts.Saver
{
    public class PrefsSaver : ISaver
    {
        public void Save(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
        }

        public string Load(string key)
        {
            return PlayerPrefs.GetString(key);
        }
    }
}