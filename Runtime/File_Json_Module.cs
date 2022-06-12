#region Access
using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System.IO;
#endregion
namespace MMA.File_Json
{
    public static partial class Key
    {
        public static string Load = "FILE_Json_Load";
    }
    public sealed partial class File_Json_Module : Module
    {
        #region References
        //[Header("Applications")] //[SerializeField] public ApplicationBase interface_Json;
        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Json
        protected override void OnSubscription(bool condition)
        {
            Middleware<(string path, Type type), object>.Subscribe_Publish(condition, Key.Load, Load);
        }
        #endregion
        #region Methods
        // Contenedor de toda la logica del Json
        //path = $"{Application.streamingAssetsPath}/{path}.json";
        private static string Path(string path) => Application.persistentDataPath + path; //TODO Llamar al modulo Application
        private static bool Exist(string path) => File.Exists(Path(path)); //TODO Llamar al modulo FIle ?
        private static string LoadText(string path) => File.ReadAllText(path); //TODO Llamar al modulo FIle ?
        private static object Load((string path, Type type) param)
        {
            if (Exist(param.path))
            {
                try
                {
                    return JsonUtility.FromJson(LoadText(param.path), param.type);
                }
                catch (Exception)
                {
                    Debug.Log($"Error Parseando {nameof(param.type)} : {LoadText(param.path)}");
                    throw;
                }
            }
            throw new Exception($"{nameof(File_Json_Module)} => {nameof(param.type)}: No se encuentra el path => {param.path}");
        }
        #endregion
        #region Request ( Coroutines )
        // Contenedor de toda la Esperas de corutinas del Json
        #endregion
        #region Task ( async )
        // Contenedor de toda la Esperas asincronas del Json
        #endregion
    }
}