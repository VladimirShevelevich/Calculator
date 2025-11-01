using System;
using System.Collections.Generic;
using Core;

namespace App.Scripts.Saver
{
    public class SaveSystemService : ISaveSystemService
    {
        private readonly Dictionary<Type, object> _datas = new();

        public void SaveData<T>(T data) where T : struct
        {
            _datas[typeof(T)] = data;
            //Save
        }

        public bool GetData<T>(out T data) where T : struct
        {
            if (_datas.TryGetValue(typeof(T), out var outData))
            {
                data = (T)outData;
                return true;
            }

            data = default;
            return false;
        }
    }
}