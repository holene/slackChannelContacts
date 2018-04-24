using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmailSlackBot.SlackResponses
{
    public static class SlackResponseFactory
    {
        public static SlackResponse GetResponse(string response, string responseType)
        {
            
            SlackResponse responseStatus = JsonConvert.DeserializeObject<SlackResponse>(response);

            if (responseStatus.ok)
            {
                switch (responseType)
                {
                    case "AuthTest":
                        return JsonConvert.DeserializeObject<AuthTestResponse>(response);
                    case "ConversationMembers":
                        return JsonConvert.DeserializeObject<ConversationMembersResponse>(response);
                    case "UserInfo":
                        return JsonConvert.DeserializeObject<UserResponse>(response);
                    case "OpenIMResponse":
                        return JsonConvert.DeserializeObject<OpenIMResponse>(response);
                    case "PostMessageResponse":
                        return JsonConvert.DeserializeObject<PostMessageResponse>(response);
                    default:
                        throw new undefinedResponseException(responseType, response);
                }
            }
            else
            {
                var ErrorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);

                throw new ErrorResponseException(ErrorResponse.error, responseType);
            }
        }
    }


    public class SlackResponse
    {
        public bool ok { get; set; }

        public override string ToString()
        {
            return $"OK: {ok}\n";
        }
    }
    public class AuthTestResponse : SlackResponse
    {

        public string url { get; set; }
        public string team { get; set; }
        public string user { get; set; }
        public string team_id { get; set; }
        public string user_id { get; set; }

        public override string ToString()
        {
            return base.ToString() + 
                $"url: {url}\n" +
                $"team: {team}\n" +
                $"user: {user}\n" +
                $"team id: {team_id}\n" +
                $"user id: {user_id}";
        }

    }

    public class ErrorResponse : SlackResponse
    {

        public string error { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Error: {error}";
        }
    }

    public class ConversationMembersResponse : SlackResponse
    {
        public string[] members { get; set; }

        public ResponseMetadata response_metadata { get; set; }

        public override string ToString()
        {
            string memberString = "[";

            foreach (var member in members)
            {
                memberString += member + ",\n";
            }
            memberString = memberString.Remove(memberString.Length - 1);
            memberString += "]\n";

            return base.ToString() +
                $"members: {memberString}" + "Metadata: {\n" + response_metadata.ToString() + "\n}";
                // + 
                //+ $"ResponseMetadata: {response_metadata.next_cursor}";
        }
    }

    public class ResponseMetadata
    {
        public string next_cursor { get; set; }

        public override string ToString()
        {
            return $"next cursor: {next_cursor}";
        }
    }

    public class UserResponse : SlackResponse
    {
        public SlackUser user { get; set; }

        public override string ToString()
        {
            return user.ToString();
        }
    }

    public class SlackUser : SlackResponse
    {
        public string id { get; set; }
        public string team_id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
        public string color { get; set; }
        public string real_name { get; set; }
        public string tz { get; set; }
        public string tz_label { get; set; }
        public string tz_ofsett { get; set; }
        public Profile profile { get; set; }
        public bool is_admin { get; set; }
        public bool is_owner { get; set; }
        public bool is_primary_owner { get; set; }
        public bool is_restricted { get; set; }
        public bool is_ultra_restricted { get; set; }
        public bool is_bot { get; set; }
        public int updated { get; set; }
        public bool is_app_user { get; set; }
        public bool has_2fa { get; set; }

        public override string ToString()
        {
            return $"name: {name}, deleted: {deleted}, userID: {id} " + profile.ToString();
        }
    }


    public class Profile
    {
        public string avatar_hash { get; set; }
        public string status_text { get; set; }
        public string status_emoji { get; set; }
        public string real_name { get; set; }
        public string display_name { get; set; }
        public string real_name_normalized { get; set; }
        public string display_name_normalized { get; set; }
        public string email { get; set; }
        public string image_24 { get; set; }
        public string image_32 { get; set; }
        public string image_48 { get; set; }
        public string image_72 { get; set; }
        public string image_192 { get; set; }
        public string image_512 { get; set; }
        public string team { get; set; }

        public override string ToString()
        {
            return $"{real_name}: {email}";
        }
    }


    public class OpenIMResponse : SlackResponse
    {
        public ChannelID channel { get; set; }
        public override string ToString()
        {
            return channel.id;
        }
    }

    public class ChannelID
    {
        public string id { get; set; }
    }

    public class PostMessageResponse : SlackResponse
    {
        public string channel { get; set; }
        public string ts { get; set; }
        public Message message { get; set; }
 

    }

    public class Message
    {
        public string text { get; set; }
        public string username { get; set; }
        public string bot_id { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string ts { get; set; }
    }
}
