using Newtonsoft.Json;
using System.Reflection;

namespace ChallengeProsegur.Test
{
    [TestClass]
    [DeploymentItem(@"Data\XMLs\DocRequestGetFilteredList2.json")]
    public class MethodHelpersTest
    {
        string RequestGetUsuarios = @"Files\Usuarios\RequestGetUsuarios.json";
        const string ResponseGetUsuarios = @"Files\Usuarios\ResponseGetUsuarios.json";
        string RequestGetUsuariosDTO = @"Files\Usuarios\RequestGet{0}.json";
        const string ResponseGetUsuariosDTO = @"Files\Usuarios\ResponseGet{0}.json";
        public void Initialize()
        {
            

        }

        [TestMethod]
        public void GetProperties_from_Generic_Object_Test()
        {
            PropertyInfo[] propertyInfos = Methods.GetProperties_from_Generic_Object<UsuariosDTO>(new UsuariosDTO());
            Assert.IsNotNull(propertyInfos);
        }

        [TestMethod]
        public void MapObject_Test()
        {
            string file = File.ReadAllText(string.Format(ResponseGetUsuariosDTO, nameof(UsuariosDTO)));
            UsuariosDTO jsonconvert = JsonConvert.DeserializeObject<UsuariosDTO>(file);
            Dictionary<object, object> UsuariosDTODictionary = Methods.GetPropertiesandValues<UsuariosDTO>(jsonconvert);
            Assert.IsNotNull(UsuariosDTODictionary);
            Assert.AreNotEqual(0, UsuariosDTODictionary.Count);
        }
    }
}