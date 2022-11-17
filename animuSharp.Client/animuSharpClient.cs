using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using Newtonsoft.Json;
using System.Text;

namespace animuSharp.Client
{
    /// <summary>
    /// main method for interacting with the api
    /// </summary>
    public class Client
    {
        private static readonly string baBaseURL = "https://animu.ml/api";
        private static string key;

        /// <summary>
        ///  Create a new instanse of the client
        /// </summary>
        /// <param name="apiKey">apiKey for makeing requests NOTE: it has a 5 requests/second ratelimit</param>
        public Client(string apiKey)
        {
            key = apiKey;
            HttpClient client = new();
            // API requires use of a key, so add it to the headers
            client.DefaultRequestHeaders.Add("Auth", key);
        }

        /// <summary>
        /// get a url if the desierd content
        /// </summary>
        /// <param name="content">the type of content you want to get select from <see cref="ContentType"/></param>
        /// <returns>a url of the selected item</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Generic> GetURl(ContentType content)
        {
            StringBuilder sb = new("/");

            switch (content)
            {
                case ContentType.angry:
                    sb.Append("angry");
                    break;

                case ContentType.baka:
                    sb.Append("baka");
                    break;

                case ContentType.bite:
                    sb.Append("bite");
                    break;

                case ContentType.blush:
                    sb.Append("blush");
                    break;

                case ContentType.bonk:
                    sb.Append("bonk");
                    break;

                case ContentType.bored:
                    sb.Append("bored");
                    break;

                case ContentType.bully:
                    sb.Append("bully");
                    break;

                case ContentType.bye:
                    sb.Append("bye");
                    break;

                case ContentType.chase:
                    sb.Append("chase");
                    break;

                case ContentType.cheer:
                    sb.Append("cheer");
                    break;

                case ContentType.cringe:
                    sb.Append("cringe");
                    break;

                case ContentType.cry:
                    sb.Append("cry");
                    break;

                case ContentType.cuddle:
                    sb.Append("cuddle");
                    break;

                case ContentType.dab:
                    sb.Append("dab");
                    break;

                case ContentType.dance:
                    sb.Append("dance");
                    break;

                case ContentType.die:
                    sb.Append("die");
                    break;

                case ContentType.disgust:
                    sb.Append("disgust");
                    break;

                case ContentType.facepalm:
                    sb.Append("facepalm");
                    break;

                case ContentType.fact:
                    sb.Append("fact");
                    break;

                case ContentType.feed:
                    sb.Append("feed");
                    break;

                case ContentType.glomp:
                    sb.Append("glomp");
                    break;

                case ContentType.happy:
                    sb.Append("happy");
                    break;

                case ContentType.hi:
                    sb.Append("hi");
                    break;

                case ContentType.highfive:
                    sb.Append("highfive");
                    break;

                case ContentType.hold:
                    sb.Append("hold");
                    break;

                case ContentType.hug:
                    sb.Append("hug");
                    break;

                case ContentType.kick:
                    sb.Append("kick");
                    break;

                case ContentType.kill:
                    sb.Append("kill");
                    break;

                case ContentType.kiss:
                    sb.Append("kiss");
                    break;

                case ContentType.laugh:
                    sb.Append("laugh");
                    break;

                case ContentType.lick:
                    sb.Append("lick");
                    break;

                case ContentType.love:
                    sb.Append("love");
                    break;

                case ContentType.lurk:
                    sb.Append("lurk");
                    break;

                case ContentType.midfing:
                    sb.Append("midfing");
                    break;

                case ContentType.nervous:
                    sb.Append("nervous");
                    break;

                case ContentType.nom:
                    sb.Append("nom");
                    break;

                case ContentType.nope:
                    sb.Append("nope");
                    break;

                case ContentType.nuzzle:
                    sb.Append("nuzzle");
                    break;

                case ContentType.panic:
                    sb.Append("panic");
                    break;

                case ContentType.password:
                    sb.Append("password");
                    break;

                case ContentType.peck:
                    sb.Append("peck");
                    break;

                case ContentType.poke:
                    sb.Append("poke");
                    break;

                case ContentType.pout:
                    sb.Append("pout");
                    break;

                case ContentType.punch:
                    sb.Append("punch");
                    break;

                case ContentType.quote:
                    sb.Append("quote");
                    break;

                case ContentType.run:
                    sb.Append("run");
                    break;

                case ContentType.sad:
                    sb.Append("sad");
                    break;

                case ContentType.shoot:
                    sb.Append("shoot");
                    break;

                case ContentType.shrug:
                    sb.Append("shrug");
                    break;

                case ContentType.sip:
                    sb.Append("sip");
                    break;

                case ContentType.slap:
                    sb.Append("slap");
                    break;

                case ContentType.sleepy:
                    sb.Append("sleepy");
                    break;

                case ContentType.smile:
                    sb.Append("smile");
                    break;

                case ContentType.smug:
                    sb.Append("smug");
                    break;

                case ContentType.stab:
                    sb.Append("stab");
                    break;

                case ContentType.stare:
                    sb.Append("stare");
                    break;

                case ContentType.suicide:
                    sb.Append("suicide");
                    break;

                case ContentType.tease:
                    sb.Append("tease");
                    break;

                case ContentType.think:
                    sb.Append("think");
                    break;

                case ContentType.thumbsup:
                    sb.Append("thumbsup");
                    break;

                case ContentType.tickle:
                    sb.Append("tickle");
                    break;

                case ContentType.triggered:
                    sb.Append("triggered");
                    break;

                case ContentType.waifu:
                    sb.Append("waifu");
                    break;

                case ContentType.Wag:
                    sb.Append("Wag");
                    break;

                case ContentType.wave:
                    sb.Append("wave");
                    break;

                case ContentType.wink:
                    sb.Append("wink");
                    break;

                case ContentType.yes:
                    sb.Append("yes");
                    break;

                default:
                    throw new Exception("no value given");
            }

            string nl = baBaseURL + sb.ToString();

            return await GetResponse<Generic>(nl).ConfigureAwait(false);
        }

        /// <summary>
        /// returns info about a random waifu
        /// </summary>
        /// <returns>a random waifu and associated info</returns>
        public async Task<Waifu> GetwaifuURl()
        {
            StringBuilder sre = new StringBuilder("/waifu");

            string end = baBaseURL + sre.ToString();

            return await GetResponse<Waifu>(end).ConfigureAwait(false);
        }

        //==========================================|make requests|==========================================
        /// <summary>
        ///     Send the request asynchronously (Dont use this method).
        /// </summary>
        /// <param name="destination">Url to get.</param>
        /// <typeparam name="T">Class to deserialize from JSON.</typeparam>
        /// <returns>JSON-deserialized class.</returns>
        public static async Task<T> GetResponse<T>(string destination)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Auth", key);
            var req = new HttpRequestMessage(HttpMethod.Get, destination);
            var res = await httpClient.SendAsync(req);

            var response = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}