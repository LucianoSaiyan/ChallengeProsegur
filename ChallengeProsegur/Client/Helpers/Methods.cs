using ChallengeProsegur.Shared;
using Newtonsoft.Json;
using System.Reflection;

namespace ChallengeProsegurClient.Helpers
{
    public static class Methods
    {

        /// <summary>
        /// Metodo que obtiene las propiedades de una clase que se para por 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties_from_Generic_Object<T>(T data) where T : class
        {
            try
            {
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    //ordena las propiedades para que el id quede primera dado que todas las entitades heredan de la interface IEntity
                    .OrderByDescending(pi => pi.Name == Constants.id)
                    .ToArray();
                return propertyInfos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deserializador Generico para los servicios con Objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T genericDeserializerObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Deserializador Generico para los servicios con Listas de Objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<T> genericDeserializerListObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        /// <summary>
        /// Funcion que arma un dictionary para obtener clave y valor de un objeto brindado
        /// </summary>
        /// <typeparam name="T">Objeto que tomara la funcion para actuar como tal</typeparam>
        /// <param name="data">Parametro del objeto instanciado</param>
        /// <returns></returns>
        public static Dictionary<object, object> GetPropertiesandValues<T>(T data) //where T : class
        {
            try
            {
                Dictionary<object, object> keyValuePairs = new Dictionary<object, object>();
                
                PropertyInfo[] propertyInfos = data.GetType().GetProperties()
                    .OrderByDescending(pi => pi.Name == Constants.id)
                    .ToArray();
                foreach (var propertyInfo in propertyInfos)
                {
                    keyValuePairs.Add(propertyInfo.Name, propertyInfo.GetValue(data) ?? string.Empty);
                }
                return keyValuePairs;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

    }

    public static class MethodsGenerics<G> where G : class
    {
        public static PropertyInfo[] getPropertiesGenerics(G data)
        {
            return data.GetType().GetProperties()
                .OrderByDescending(pi => pi.Name == Constants.id)
                .ToArray();
        }
    }

}
