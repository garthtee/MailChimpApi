using MailChimp.Net.Models;
using System.Collections.Generic;

namespace GarthToland.MailChimpApi.Web
{
    public class Settings
    {
        public MailChimpSettings MailChimpSettings { get; set; }
    }

    public class MailChimpSettings
    {
        public string ApiKey { get; set; }
        public string ListId { get; set; }
        public IList<MemberTag> Tags { get; set; }
    }
}
