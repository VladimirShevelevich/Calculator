namespace Core
{
    public interface ISaveSystemService
    {
        void SaveData<T>(T data) where T : struct;
        bool GetData<T>(out T data) where T : struct;
    }
}