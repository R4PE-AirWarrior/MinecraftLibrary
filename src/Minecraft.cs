using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MinecraftLibrary
{
    public class Minecraft
    {
        /// <summary>
        /// Generiert eine Session mit einem Usernamen und Passwort.
        /// </summary>
        /// <param name="username">Minecraft Username</param>
        /// <param name="password">Minecraft Passwort</param>
        /// <returns></returns>
        public MinecraftSession Login(String username, String password)
        {
            SessionPayload payload = new SessionPayload();
            Agent agent = new Agent();
            agent.name = "Minecraft";
            agent.version = 14;
            payload.agent = agent;
            payload.username = username;
            payload.password = password;
            payload.clientToken = "";
            string Json = JsonConvert.SerializeObject(payload);
            Console.WriteLine(Json);

            SessionResponse response = JsonConvert.DeserializeObject< SessionResponse>(PostRequest("https://authserver.mojang.com/authenticate", Json));
            Console.WriteLine(response.accessToken);
            Console.WriteLine(response.selectedProfile.name);

            return new MinecraftSession() {UserName = response.selectedProfile.name, SessionKey = response.accessToken};
        }

        private String PostRequest(String url, String json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
