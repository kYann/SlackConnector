﻿using Newtonsoft.Json;

namespace SlackLibrary.Connections.Models
{
    public class Profile
    {
		[JsonProperty("avatar_hash")]
		public string AvatarHash { get; set; }

		[JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		[JsonProperty("real_name_normalized")]
        public string RealNameNormalised { get; set; }

        [JsonProperty("image_512")]
        public string Image { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        [JsonProperty("status_text")]
        public string StatusText { get; set;  }

		[JsonProperty("status_emoji")]
		public string StatusEmoji { get; set; }

		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }
	}
}