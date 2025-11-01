namespace App.Scripts.Saver
{
    public interface ISaver
    {
        public void Save(string key, string data);
        public string Load(string key);
    }
}