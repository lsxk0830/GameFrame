# if UNITY_EDITOR
using FrameworkDesign;
using UnityEditor;
#endif
using UnityEngine;

namespace CounterApp
{
    public interface IStorage :IUtility
    {
        void SaveInt(string key ,int value);
        int LoadInt(string key, int defaoltValue = 0);
    }

    public class PlayerPresStorage : IStorage
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
        public int LoadInt(string key, int defaoltValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaoltValue);
        }
    }

    public class EditorPrefsStorage : IStorage
    {
        public void SaveInt(string key, int value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt(key, value);
#endif
        }
        public int LoadInt(string key, int defaoltValue = 0)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaoltValue);
#else
            return 0;
#endif
        }

    }
}
