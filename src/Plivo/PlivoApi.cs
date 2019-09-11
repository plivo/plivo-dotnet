using System;
using Plivo.Authentication;
using Plivo.Client;
using Plivo.Resource.Account;
using Plivo.Resource.Application;
using Plivo.Resource.Call;
using Plivo.Resource.Conference;
using Plivo.Resource.Endpoint;
using Plivo.Resource.Message;
using Plivo.Resource.RentedNumber;
using Plivo.Resource.PhoneNumber;
using Plivo.Resource.Pricing;
using Plivo.Resource.Recording;
using Plivo.Resource.Subaccount;
using Plivo.Resource.Address;
using Plivo.Resource.Identity;


namespace Plivo
{
    /// <summary>
    /// Plivo API.
    /// </summary>
    public class PlivoApi
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public HttpClient Client { get; set; }

        /// <summary>
        /// The basic auth.
        /// </summary>
        protected BasicAuth BasicAuth;

        // resource interfaces
        private readonly Lazy<AccountInterface> _account;
        private readonly Lazy<SubaccountInterface> _subaccount;
        private readonly Lazy<ApplicationInterface> _application;
        private readonly Lazy<CallInterface> _call;
        private readonly Lazy<ConferenceInterface> _conference;
        private readonly Lazy<MessageInterface> _message;

        private readonly Lazy<PowerpackInterface> _powerpack;
        private readonly Lazy<EndpointInterface> _endpoint;
        private readonly Lazy<PricingInterface> _pricing;
        private readonly Lazy<RecordingInterface> _recording;
        private readonly Lazy<RentedNumberInterface> _number;
        private readonly Lazy<PhoneNumberInterface> _phoneNumber;
        private readonly Lazy<AddressInterface> _address;
        private readonly Lazy<IdentityInterface> _identity;

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <value>The account.</value>
        public AccountInterface Account => _account.Value;

        /// <summary>
        /// Gets the subaccount.
        /// </summary>
        /// <value>The subaccount.</value>
        public SubaccountInterface Subaccount => _subaccount.Value;

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
        public ApplicationInterface Application => _application.Value;

        /// <summary>
        /// Gets the call.
        /// </summary>
        /// <value>The call.</value>
        public CallInterface Call => _call.Value;

        /// <summary>
        /// Gets the conference.
        /// </summary>
        /// <value>The conference.</value>
        public ConferenceInterface Conference => _conference.Value;

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public MessageInterface Message => _message.Value;

        public PowerpackInterface Powerpack => _powerpack.Value;

        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        /// <value>The endpoint.</value>
        public EndpointInterface Endpoint => _endpoint.Value;

        /// <summary>
        /// Gets the pricing.
        /// </summary>
        /// <value>The pricing.</value>
        public PricingInterface Pricing => _pricing.Value;

        /// <summary>
        /// Gets the recording.
        /// </summary>
        /// <value>The recording.</value>
        public RecordingInterface Recording => _recording.Value;

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public RentedNumberInterface Number => _number.Value;

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public PhoneNumberInterface PhoneNumber => _phoneNumber.Value;

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public AddressInterface Address => _address.Value;

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public IdentityInterface Identity => _identity.Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.PlivoApi"/> class.
        /// </summary>
        /// <param name="authId">Auth identifier.</param>
        /// <param name="authToken">Auth token.</param>
        /// <param name="proxyAddress">Proxy Address.</param>
        /// <param name="proxyPort">Proxy Port.</param>
        /// <param name="proxyUsername">Proxy Username.</param>
        /// <param name="proxyPassword">Proxy Password.</param>
        public PlivoApi(
            string authId = null,
            string authToken = null,
            string proxyAddress = null,
            string proxyPort = null,
            string proxyUsername = null,
            string proxyPassword = null
        )
        {
            BasicAuth = new BasicAuth(authId, authToken);
            Client = new HttpClient(BasicAuth, proxyAddress, proxyPort, proxyUsername, proxyPassword);
            _account = new Lazy<AccountInterface>(() => new AccountInterface(Client));
            _subaccount = new Lazy<SubaccountInterface>(() => new SubaccountInterface(Client));
            _application = new Lazy<ApplicationInterface>(() => new ApplicationInterface(Client));
            _call = new Lazy<CallInterface>(() => new CallInterface(Client));
            _conference = new Lazy<ConferenceInterface>(() => new ConferenceInterface(Client));
            _message = new Lazy<MessageInterface>(() => new MessageInterface(Client));
             _powerpack = new Lazy<PowerpackInterface>(() => new PowerpackInterface(Client));
            _endpoint = new Lazy<EndpointInterface>(() => new EndpointInterface(Client));
            _pricing = new Lazy<PricingInterface>(() => new PricingInterface(Client));
            _recording = new Lazy<RecordingInterface>(() => new RecordingInterface(Client));
            _number = new Lazy<RentedNumberInterface>(() => new RentedNumberInterface(Client));
            _phoneNumber = new Lazy<PhoneNumberInterface>(() => new PhoneNumberInterface(Client));
            _address = new Lazy<AddressInterface>(() => new AddressInterface(Client));
            _identity = new Lazy<IdentityInterface>(() => new IdentityInterface(Client));
        }
    }
}