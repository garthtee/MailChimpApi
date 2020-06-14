using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GarthToland.MailChimpApi.Web
{
    public interface IMailChimpService
    {
        Task<Member> CreateSubscriberAsync(Subscriber subscriber);
    }

    public class MailChimpService : IMailChimpService
    {
        private readonly Settings _settings;
        private readonly IMailChimpManager _mailChimpManager;

        public MailChimpService(Settings settings)
        {
            _settings = settings;
            _mailChimpManager = new MailChimpManager(settings.MailChimpSettings.ApiKey);
        }

        public async Task<Member> CreateSubscriberAsync(Subscriber subscriber)
        {
            var member = new Member()
            {
                EmailAddress = subscriber.Email,
                StatusIfNew = Status.Subscribed,
                Tags = _settings.MailChimpSettings.Tags.ToList(),
            };

            member.MergeFields.Add("FNAME", subscriber.FirstName);
            member.MergeFields.Add("LNAME", subscriber.LastName);

            return await _mailChimpManager.Members.AddOrUpdateAsync(_settings.MailChimpSettings.ListId, member);
        }
    }
}
