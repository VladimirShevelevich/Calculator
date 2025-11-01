using System;
using System.Collections.Generic;
using Core;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using VContainer.Unity;

namespace App.Scripts.Saver
{
    public class SaveSystemService : ISaveSystemService, IInitializable
    {
        private const string SAVE_DATA_KEY = "SaveDataKey";
        
        private readonly ISaver _saver;
        private Dictionary<Type, object> _datas = new();

        public SaveSystemService(ISaver saver)
        {
            _saver = saver;
        }

        public void Initialize()
        {
            LoadData();
        }

        public void SaveData<T>(T data) where T : struct
        {
            _datas[typeof(T)] = data;
            var json = JsonConvert.SerializeObject(_datas);
            _saver.Save(SAVE_DATA_KEY, json);
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

        private void LoadData()
        {
            var json = _saver.Load(SAVE_DATA_KEY);
            if (string.IsNullOrEmpty(json))
                return;

            var saveData = JsonConvert.DeserializeObject<Dictionary<Type, object>>(json);
            if (saveData == null)
            {
                Debug.LogError("Loading save has failed. Deserialization error");
                return;
            }

            _datas = saveData;
        }
    }
}