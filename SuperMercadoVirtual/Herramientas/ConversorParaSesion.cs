using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace SuperMercadoVirtual.Herramientas
{
    public static class ConversorParaSesion
    {
        // Guardar objeto C# a Json (objeto -> json)
        public static void ObjetoAJson(this ISession sesion, string llave, object valor)
        {
            sesion.SetString(llave, JsonConvert.SerializeObject(valor));
        }

        // Guardar objeto de Json a C# (json -> objeto)
        public static T JsonAObjeto<T>(this ISession sesion, string llave)
        {
            string valor = sesion.GetString(llave);
            return valor == null ? default (T): JsonConvert.DeserializeObject<T>(valor);
        }
    }
}

