using System;
using Plivo.Authentication;
using Plivo.Client;
using Plivo.Resource.Account;
using Plivo.Resource.Application;
using Plivo.Resource.Call;
using Plivo.Resource.Conference;
using Plivo.Resource.Endpoint;
using Plivo.Resource.Message;
using Plivo.Resource.Lookup;
using Plivo.Resource.Powerpack;
using Plivo.Resource.RentedNumber;
using Plivo.Resource.PhoneNumber;
using Plivo.Resource.Pricing;
using Plivo.Resource.Recording;
using Plivo.Resource.Subaccount;
using Plivo.Resource.Address;
using Plivo.Resource.Identity;
using Plivo.Resource.CallFeedback;
using Plivo.Resource.Media;
using Plivo.Resource.RegulatoryCompliance.Application;
using Plivo.Resource.RegulatoryCompliance.Document;
using Plivo.Resource.RegulatoryCompliance.DocumentType;
using Plivo.Resource.RegulatoryCompliance.EndUser;
using Plivo.Resource.RegulatoryCompliance.Requirement;
using Plivo.Resource.MultiPartyCall;
using Plivo.Resource.Brand;
using Plivo.Resource.Campaign;
using Plivo.Resource.Profile;
using Plivo.Resource.Token;

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
        private readonly Lazy<TokenInterface>_token;
        private readonly Lazy<ConferenceInterface> _conference;
        private readonly Lazy<MessageInterface> _message;
        private readonly Lazy<LookupInterface> _lookup;
        private readonly Lazy<PowerpackInterface> _powerpack;
        private readonly Lazy<BrandInterface> _brand;
        private readonly Lazy<CampaignInterface> _campiagn;
        private readonly Lazy<ProfileInterface> _profile;
        private readonly Lazy<MediaInterface> _media;
        private readonly Lazy<EndpointInterface> _endpoint;
        private readonly Lazy<PricingInterface> _pricing;
        private readonly Lazy<RecordingInterface> _recording;
        private readonly Lazy<RentedNumberInterface> _number;
        private readonly Lazy<PhoneNumberInterface> _phoneNumber;
        private readonly Lazy<AddressInterface> _address;
        private readonly Lazy<IdentityInterface> _identity;
        private readonly Lazy<CallFeedbackInterface> _callFeedback;
        private readonly Lazy<EndUserInterface> _endUser;
        private readonly Lazy<DocumentTypeInterface> _documentType;
        private readonly Lazy<RequirementInterface> _requirement;
        private readonly Lazy<DocumentInterface> _document;
        private readonly Lazy<ComplianceApplicationInterface> _complianceApplication;

        private readonly Lazy<MultiPartyCallInterface> _multiPartyCall;
        
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
        /// Gets the token.
        /// </summary>
        /// <value>The token.</value>
        public TokenInterface Token => _token.Value;
        
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

        public PowerpackInterface Powerpacks => _powerpack.Value;

        public BrandInterface Brand => _brand.Value;

        public CampaignInterface Campaign => _campiagn.Value;

        public ProfileInterface Profile => _profile.Value;

        public MediaInterface Media => _media.Value;

        public LookupInterface Lookup => _lookup.Value;

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
        /// Gets the call feedback.
        /// </summary>
        /// <value>Call Feedback.</value>
        public CallFeedbackInterface CallFeedback => _callFeedback.Value;

        public EndUserInterface ComplianceEndUser => _endUser.Value;

        public DocumentTypeInterface ComplianceDocumentType => _documentType.Value;

        public RequirementInterface ComplianceRequirement => _requirement.Value;

        public DocumentInterface ComplianceDocument => _document.Value;

        public ComplianceApplicationInterface ComplianceApplication => _complianceApplication.Value;

        public MultiPartyCallInterface MultiPartyCall => _multiPartyCall.Value;

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
            _token = new Lazy<TokenInterface>(()=> new TokenInterface(Client));
            _conference = new Lazy<ConferenceInterface>(() => new ConferenceInterface(Client));
            _message = new Lazy<MessageInterface>(() => new MessageInterface(Client));
            _lookup = new Lazy<LookupInterface>(() => new LookupInterface(Client));
            _powerpack = new Lazy<PowerpackInterface>(() => new PowerpackInterface(Client));
            _brand = new Lazy<BrandInterface>(() => new BrandInterface(Client));
            _profile = new Lazy<ProfileInterface>(()=> new ProfileInterface(Client));
            _campiagn = new Lazy<CampaignInterface>(() => new CampaignInterface(Client));
            _media = new Lazy<MediaInterface>(() => new MediaInterface(Client));
            _endpoint = new Lazy<EndpointInterface>(() => new EndpointInterface(Client));
            _pricing = new Lazy<PricingInterface>(() => new PricingInterface(Client));
            _recording = new Lazy<RecordingInterface>(() => new RecordingInterface(Client));
            _number = new Lazy<RentedNumberInterface>(() => new RentedNumberInterface(Client));
            _phoneNumber = new Lazy<PhoneNumberInterface>(() => new PhoneNumberInterface(Client));
            _address = new Lazy<AddressInterface>(() => new AddressInterface(Client));
            _identity = new Lazy<IdentityInterface>(() => new IdentityInterface(Client));
            _callFeedback = new Lazy<CallFeedbackInterface>(() => new CallFeedbackInterface(Client));

            _endUser = new Lazy<EndUserInterface>(() => new EndUserInterface(Client));
            _documentType = new Lazy<DocumentTypeInterface>(() => new DocumentTypeInterface(Client));
            _requirement = new Lazy<RequirementInterface>(() => new RequirementInterface(Client));
            _document = new Lazy<DocumentInterface>(() => new DocumentInterface(Client));
            _complianceApplication =
                new Lazy<ComplianceApplicationInterface>(() => new ComplianceApplicationInterface(Client));
            _multiPartyCall = new Lazy<MultiPartyCallInterface>(() => new MultiPartyCallInterface(Client));
        }
    }
}