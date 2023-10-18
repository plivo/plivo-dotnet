# Change Log

## [5.35.0](https://github.com/plivo/plivo-dotnet/tree/v5.35.0) (2023-10-17)
**Feature - Fixes for Campaign services list API meta data**
- Fixed Meta data response for campaign, brand and profile list

## [5.34.0](https://github.com/plivo/plivo-dotnet/tree/v5.34.0) (2023-10-13)
**Feature - WhatsApp message support**
- Added new params `template`, `template_json_string` and new message_type `whatsapp` to [send message API](https://www.plivo.com/docs/sms/api/message#send-a-message)
- Added  new  `message_state` (`read`), `message_type`(`whatsapp`), `conversation_id`, `conversation_origin`, `conversation_expiration_timestamp` in [list all messages API](https://www.plivo.com/docs/sms/api/message#list-all-messages) and [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message) response

## [5.33.0](https://github.com/plivo/plivo-dotnet/tree/v5.33.0) (2023-08-25)
**Feature - Added New Param 'carrier_fees', 'carrier_fees_rate', 'destination_network' in Get Message and List Message APIs**
- Added new params on message get and list response

## [v5.32.0](https://github.com/plivo/plivo-dotnet/tree/v5.32.0) (2023-08-03)
**Feature - DLT parameters**
- Added new params `DLTEntityID`, `DLTTemplateID`, `DLTTemplateCategory` to the [send message API](https://www.plivo.com/docs/sms/api/message/send-a-message/)
- Added new params `DLTEntityID`, `DLTTemplateID`, `DLTTemplateCategory` to the response for the [list all messages API](https://www.plivo.com/docs/sms/api/message/list-all-messages/) and the [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message)

## [v5.31.0](https://github.com/plivo/plivo-dotnet/tree/v5.31.0) (2023-06-28)
**Feature - Streaming API and XML**
- Added Stream API endpoints
- Added Stream XML creation ability

## [5.30.0](https://github.com/plivo/plivo-dotnet/tree/v5.30.0) (2023-05-02)
**Feature - CNAM Lookup**
- Added New Param `cnam_lookup` in to the response of the [list all numbers API], [list single number API]
- Added `cnam_lookup` filter to AccountPhoneNumber - list all my numbers API.
- Added `cnam_lookup` parameter to buy number[Buy a Phone Number]  to configure CNAM Lookup while buying a US number
- Added `cnam_lookup` parameter to update number[Update an account phone number] to configure CNAM Lookup while buying a US number

## [v5.29.0](https://github.com/plivo/plivo-dotnet/tree/v5.23.1) (2023-03-16)
**Feature - Added New Param 'cnam_lookup_number_config' in GetCall and ListCalls**
- Add `cnam_lookup_number_config` to the response for the [retrieve a call details API](https://www.plivo.com/docs/voice/api/call#retrieve-a-call) and the [retreive all call details API](https://www.plivo.com/docs/voice/api/call#retrieve-all-calls)

## [v5.28.0](https://github.com/plivo/plivo-dotnet/tree/v5.28.0) (2023-05-29)
- Added `MonthlyRecordingStorageAmount`, `RecordingStorageRate`, `RoundedRecordingDuration`, and `RecordingStorageDuration` parameters to the response for [get single recording API](https://www.plivo.com/docs/voice/api/recording#retrieve-a-recording) and [get all recordings API](https://www.plivo.com/docs/voice/api/recording#list-all-recordings)
- Added `RecordingStorageDuration` parameter as a filter option for [get all recordings API](https://www.plivo.com/docs/voice/api/recording#list-all-recordings)

## [v5.27.0](https://github.com/plivo/plivo-dotnet/tree/v5.27.0) (2023-05-04)
- Add New Param `renewalDate` to the response of the [list all numbers API], [list single number API]
- Add 5 new filters to AccountPhoneNumber - list all my numbers API:`renewal_date`, `renewal_date__gt`, `renewal_date__gte`,`renewal_date__lt` and `renewal_date__lte` (https://www.plivo.com/docs/numbers/api/account-phone-number#list-all-my-numbers)

## [v5.26.0](https://github.com/plivo/plivo-dotnet/tree/v5.26.0) (2023-04-25)
- Added new param `ReplacedSender` to the response for the [list all messages API](https://www.plivo.com/docs/sms/api/message/list-all-messages/) and the [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message)

## [v5.25.0](https://github.com/plivo/plivo-dotnet/tree/v5.25.0) (2023-04-11)
**Feature - Added New Param 'source_ip' in GetCall and ListCalls**
- Add `source_ip` to the response for the [retrieve a call details API](https://www.plivo.com/docs/voice/api/call#retrieve-a-call) and the [retreive all call details API](https://www.plivo.com/docs/voice/api/call#retrieve-all-calls)

## [v5.24.0](https://github.com/plivo/plivo-dotnet/tree/v5.23.0) (2023-17-03)
- Added New Param `CreatedAt` to the response for the [list all profiles API](https://www.plivo.com/docs/sms/api/10dlc/profile#retrieve-all-profiles) and the [get profile API](https://www.plivo.com/docs/sms/api/10dlc/profile#retrieve-a-specific-profile) and the [list all brands API](https://www.plivo.com/docs/sms/api/10dlc/brand#retrieve-all-brands) and the [get brand API](https://www.plivo.com/docs/sms/api/10dlc/brand#retrieve-a-specific-brand)  and the [list all campaigns API](https://www.plivo.com/docs/sms/api/10dlc/campaign#retrieve-all-campaigns) and the [get campaign API](https://www.plivo.com/docs/sms/api/10dlc/campaign#retrieve-a-specific-campaign)

## [v5.23.0](https://github.com/plivo/plivo-dotnet/tree/v5.23.0) (2023-03-03)
- Added new param `IsDomestic` to the response for the [list all messages API](https://www.plivo.com/docs/sms/api/message/list-all-messages/) and the [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message)

## [v5.22.0](https://github.com/plivo/plivo-dotnet/tree/v5.22.0) (2023-02-23)
 - Enhance MDR filtering capabilities 

## [v5.21.0](https://github.com/plivo/plivo-dotnet/tree/v5.21.0) (2023-01-25)
- Added new param `RequesterIp` to the response for the [list all messages API](https://www.plivo.com/docs/sms/api/message/list-all-messages/) and the [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message)

## [v5.20.0](https://github.com/plivo/plivo-dotnet/tree/v5.20.0) (2023-01-18)
- Added new param - 'message_expiry' in plivo-dotnet

## [v5.19.0](https://github.com/plivo/plivo-dotnet/tree/v5.19.0) (2022-12-16)
- Added: Update campaign api endpoints

## [v5.18.0](https://github.com/plivo/plivo-dotnet/tree/v5.18.0) (2022-12-06)
- Added: Delete campaign and brand api endpoints

## [v5.17.0](https://github.com/plivo/plivo-dotnet/tree/v5.17.0) (2022-10-17)
- Added: Brandusecase API, 10dlc api enhancement

## [v5.16.0](https://github.com/plivo/plivo-dotnet/tree/v5.16.0) (2022-10-14)
- Added 3 new keys to AccountPhoneNumber object:`tendlc_registration_status`, `tendlc_campaign_id` and `toll_free_sms_verification` (https://www.plivo.com/docs/numbers/api/account-phone-number#the-accountphonenumber-object)
- Added 3 new filters to AccountPhoneNumber - list all my numbers API:`tendlc_registration_status`, `tendlc_campaign_id` and `toll_free_sms_verification` (https://www.plivo.com/docs/numbers/api/account-phone-number#list-all-my-numbers)

## [v5.15.4](https://github.com/plivo/plivo-dotnet/tree/v5.15.4) (2022-09-30)
- Bug fix:: plivo_subaccount added in 10dlc profile api

## [v5.15.3](https://github.com/plivo/plivo-go/tree/v5.15.3) (2022-09-28)
- 10DLC: Adding more attributes to campaign creation request

## [v5.15.2](https://github.com/plivo/plivo-go/tree/v5.15.2) (2022-09-13)
- Bug fix: 10DLC LinkNumberSync remove mandatory params

## [v5.15.1](https://github.com/plivo/plivo-go/tree/v5.15.1) (2022-08-22)
- Fix Incorrect Exception handling for JSON response parsing exceptions

## [v5.15.0](https://github.com/plivo/plivo-go/tree/v5.15.0) (2022-08-18)
**Features - JWT Token Creation API**
- `JWT Token Creation API` added API to create a new JWT token.

## [v5.14.1](https://github.com/plivo/plivo-go/tree/v5.14.1) (2022-08-05)
**Fix - Powerpack number count**
- Handle zero numbers on powerpack

## [v5.14.0](https://github.com/plivo/plivo-go/tree/v5.14.0) (2022-07-12)
**Feature - STIR Attestation**
- Add stir attestation param as part of Get CDR and Get live call APIs Response

## [v5.13.4](https://github.com/plivo/plivo-dotnet/tree/v5.13.4) (2022-06-28)
**Fix - Print Exception for 400 case**
- Printing the Exception for 400 error case

## [v5.13.3](https://github.com/plivo/plivo-dotnet/tree/v5.13.3) (2022-06-23)
- Fixed versioning issue in nuspec

## [v5.13.2](https://github.com/plivo/plivo-dotnet/tree/v5.13.2) (2022-06-23)
- Mapped `first_name` and `last_name` param to AuthorizedContact Profile Creation request

## [v5.13.1](https://github.com/plivo/plivo-dotnet/tree/v5.13.1) (2022-05-12)
- Added `affiliate_marketing` param to CreateCampaign request

## [v5.13.0](https://github.com/plivo/plivo-dotnet/tree/v5.13.0) (2022-05-10)
- add `brand_type` field in BrandResponse

## [v5.12.0](https://github.com/plivo/plivo-dotnet/tree/v5.12.0) (2022-05-05)
**Feature - List all recordings and The MultiPartyCall element**
- `from_number` and `to_number` added to filtering param [List all recordings](https://www.plivo.com/docs/voice/api/recording#list-all-recordings)
- `record_min_member_count` param added to [Add a participant to a multiparty call using API](https://www.plivo.com/docs/voice/api/multiparty-call/participants#add-a-participant)

## [v5.11.0](https://github.com/plivo/plivo-dotnet/tree/v5.11.0) (2022-04-28)
**Feature - 10dlc API Callback**
- callback support for brand, campaign and link number api

## [v5.10.0](https://github.com/plivo/plivo-dotnet/tree/v5.10.0) (2022-04-18)
**Feature - Voice Async API requests**
- Added [asynchronous](https://www.plivo.com/docs/voice/api/request#asynchronous-request) SDK requests support for all The Voice APIs


## [v5.9.0](https://github.com/plivo/plivo-dotnet/tree/v5.9.0) (2022-04-14)
**Feature - 10dlc api**
- Profile API, Brand API, Number Linking

## [v5.8.0](https://github.com/plivo/plivo-dotnet/tree/v5.8.0) (2022-03-25)
**Feature - DialElement**
- `confirmTimeout` parameter added to [The Dial element](https://www.plivo.com/docs/voice/xml/dial/)

## [v5.7.4](https://github.com/plivo/plivo-dotnet/tree/v5.7.4) (2022-02-22)
**MPCListParticipant**
- member_address parameter added in response

## [v5.7.3](https://github.com/plivo/plivo-dotnet/tree/v5.7.3) (2022-02-17)
**Bug Fix - Phone number**
- Added support to query via city for Phone number List calls.

## [v5.7.2](https://github.com/plivo/plivo-dotnet/tree/v5.7.2) (2022-01-25)
**MPCStartCallRecording**
- parameter change from statusCallback to recordingCallback

## [v5.7.1](https://github.com/plivo/plivo-dotnet/tree/v5.7.1) (2022-01-25)
**Fix - HTTP Client**
- Log SDK version in the HTTP request.

## [v5.7.0](https://github.com/plivo/plivo-dotnet/tree/v5.7.0) (2021-12-16)
**Features - SMS**
- 10dlc api support

## [v5.6.1](https://github.com/plivo/plivo-dotnet/tree/v5.6.1) (2021-12-16)
**Bug fix**
- Added an exception to allow for more efficient error logs.

## [v5.6.0](https://github.com/plivo/plivo-dotnet/tree/v5.6.0) (2021-12-14)
**Features - Voice**
- Routing SDK traffic through Akamai endpoints for all the [Voice APIs](https://www.plivo.com/docs/voice/api/overview/)

## [v5.5.0](https://github.com/plivo/plivo-dotnet/tree/v5.5.0) (2021-11-25)
**Features - Voice: Multiparty calls**
- The [Add Multiparty Call API](https://www.plivo.com/docs/voice/api/multiparty-call/participants#add-a-participant) allows for greater functionality by accepting options like `start recording audio`, `stop recording audio`, and their HTTP methods.
- [Multiparty Calls](https://www.plivo.com/docs/voice/api/multiparty-call/) now has new APIs to `stop` and `play` audio.

## [v5.4.0](https://github.com/plivo/plivo-dotnet/tree/v5.4.0) (2021-10-11)
**Features - Messaging**
- This version includes advancements to the Messaging Interface that deals with the [Send SMS/MMS](https://www.plivo.com/docs/sms/api/message#send-a-message) interface, Creating a standard structure for `request/input` arguments to make implementation easier and incorporating support for the older interface.

  Example for [send SMS](https://github.com/plivo/plivo-dotnet#send-a-message)

## [v5.3.0](https://github.com/plivo/plivo-dotnet/tree/v5.3.0) (2021-07-28)
- Added generic error message for mandatory params in [Make Call](https://www.plivo.com/docs/voice/api/call#make-a-call) and [Multi party call](https://www.plivo.com/docs/voice/api/multiparty-call#start-a-new-multiparty-call).
- Removed validation for `ringtimeout` and `delaydial` params in [Start a multi party call](https://www.plivo.com/docs/voice/api/multiparty-call#start-a-new-multiparty-call).

## [v5.2.1](https://github.com/plivo/plivo-dotnet/tree/v5.2.1) (2021-07-27)
- Updated default HTTP client request timeout to 5 seconds.

## [v5.2.0](https://github.com/plivo/plivo-dotnet/tree/v5.2.0) (2021-07-14)
- Add support for MPC APIs and XML (Voice retry included), validated voice UTs.

## [v5.1.0](https://github.com/plivo/plivo-dotnet/tree/v5.1.0) (2021-07-13)
- Power pack ID has been included to the response for the [list all messages API](https://www.plivo.com/docs/sms/api/message/list-all-messages/) and the [get message details API](https://www.plivo.com/docs/sms/api/message#retrieve-a-message).
- Support for filtering messages by Power pack ID has been added to the [list all messages API](https://www.plivo.com/docs/sms/api/message#list-all-messages).

## [v5.0.1](https://github.com/plivo/plivo-dotnet/tree/v5.0.1) (2021-07-05)
- Make parameters optional for XML method AddSpeak

## [v5.0.0](https://github.com/plivo/plivo-dotnet/tree/v5.0.0) (2021-07-05)
- **BREAKING**: Removed the total_count parameter in meta data for list MDR response

## [v4.17.1](https://github.com/plivo/plivo-dotnet/tree/v4.17.1) (2021-07-02)
- Read voice network group from voice pricing
- Read voice network group from List/Get CDR response

## [v4.17.0](https://github.com/plivo/plivo-dotnet/tree/v4.17.0) (2021-06-15)
- Add stir verification param as part of Get CDR and Live call API response

## [v4.16.1](https://github.com/plivo/plivo-dotnet/tree/v4.16.1) (2020-04-08)
- Read origination prefix from voice pricing

## [v4.16.0](https://github.com/plivo/plivo-dotnet/tree/v4.16.0) (2021-03-30)
- Add support for Regulatory Compliance APIs.
- Add "complianceApplicationId","complianceStatus" - these new feilds in the List/Get rented numbers
- Add "city","mmsEnabled","mmsRate","complianceRequirement" - These new feilds are added in the Search Phone Number
- Add "npanxx" and "local_calling_area" support for Search Phone Number.

## [v4.15.1](https://github.com/plivo/plivo-dotnet/tree/v4.15.1) (2020-12-17)
- Fix Prosody XML error - SSML.

## [v4.15.0](https://github.com/plivo/plivo-dotnet/tree/v4.15.0) (2020-11-17)
- Add number_priority support for Powerpack API.

## [v4.14.0](https://github.com/plivo/plivo-dotnet/tree/v4.14.0) (2020-10-27)
- Change lookup API endpoint and response.

## [v4.13.0](https://github.com/plivo/plivo-dotnet/tree/v4.13.0) (2020-10-06)
- Add support for Lookup API.

## [v4.12.0](https://github.com/plivo/plivo-dotnet/tree/v4.12.0) (2020-09-24)
- Add "PublicUri" optional param support for Application API.

## [v4.11.0](https://github.com/plivo/plivo-dotnet/tree/v4.11.0) (2020-09-07)
- Add Powerpack for MMS

## [v4.10.2](https://github.com/plivo/plivo-dotnet/tree/v4.10.2) (2020-08-19)
- Internal changes in PHLO for MultiPartyCall component.

## [v4.10.1](https://github.com/plivo/plivo-dotnet/tree/v4.10.1) (2020-08-14)
- Add exception handling for non-JSON error responses and statusCode 401.

## [v4.10.0](https://github.com/plivo/plivo-dotnet/tree/v4.10.0) (2020-08-06)
- Add retries to multiple regions for voice requests.

## [v4.9.1](https://github.com/plivo/plivo-dotnet/tree/v4.9.1) (2020-06-30)
- Fix List Call Details response.

## [v4.9.0](https://github.com/plivo/plivo-dotnet/tree/v4.9.0) (2020-05-28)
- Add JWT helper functions.

## [v4.8.2](https://github.com/plivo/plivo-dotnet/tree/v4.8.1) (2020-05-19)
- Fix List All Rented Numbers API response.

## [v4.8.1](https://github.com/plivo/plivo-dotnet/tree/v4.8.1) (2020-05-19)
- Add Send MMS using Media_ID support.

## [v4.8.0](https://github.com/plivo/plivo-dotnet/tree/v4.8.0) (2020-04-29)
- Add V3 signature helper functions.

## [v4.7.1](https://github.com/plivo/plivo-dotnet/tree/v4.7.1) (2020-04-24)
- Fix Bulk call API response.

## [v4.7.0](https://github.com/plivo/plivo-dotnet/tree/v4.7.0) (2020-03-31)
- Add application cascade delete support.

## [v4.6.0](https://github.com/plivo/plivo-dotnet/tree/v4.6.0) (2020-03-30)
- Add Tollfree support for Powerpack

## [v4.5.0](https://github.com/plivo/plivo-dotnet/tree/v4.5.0) (2020-03-27)
- Add post call quality feedback API support.

## [v4.4.10](https://github.com/plivo/plivo-dotnet/tree/v4.4.10) (2020-03-05)
- Fix Newtonsoft warning.

## [v4.4.9](https://github.com/plivo/plivo-dotnet/tree/v4.4.9) (2020-02-25)
- Add Media support.

## [v4.4.8](https://github.com/plivo/plivo-dotnet/tree/v4.4.8) (2019-12-20)
- Add Powerpack support.

## [v4.4.7](https://github.com/plivo/plivo-dotnet/tree/v4.4.7) (2019-12-04)
- Add MMS support.

## [v4.4.6](https://github.com/plivo/plivo-dotnet/tree/v4.4.6) (2019-11-13)
- Add GetInput XML support.

## [v4.4.5](https://github.com/plivo/plivo-dotnet/tree/v4.4.5) (2019-10-14)
- Add proxy-support for Signature Validation.

## [v4.4.4](https://github.com/plivo/plivo-dotnet/tree/v4.4.4) (2019-09-30)
- Fix support for mixed SSML tags.

## [v4.4.3](https://github.com/plivo/plivo-dotnet/tree/v4.4.3) (2019-08-06)
- Add logic to handle invalid numbers for bulk SMS.

## [v4.4.2](https://github.com/plivo/plivo-dotnet/tree/v4.4.2) (2019-07-18)
- Add Status Code in API responses.

## [v4.4.1](https://github.com/plivo/plivo-dotnet/tree/v4.4.1) (2019-06-12)
- Add AggregateException Flattening

## [v4.4.0](https://github.com/plivo/plivo-dotnet/tree/v4.4.0) (2019-03-14)
- Add PHLO support
- Add Multi-Party Call triggers

## [v4.3.0-beta1](https://github.com/plivo/plivo-dotnet/tree/v4.3.0-beta1) (2019-03-14)
- Add PHLO support in beta release
- Add Multi-Party Call triggers

## [v4.2.3](https://github.com/plivo/plivo-dotnet/tree/v4.2.3) (2019-01-04)
- Update Thread Safety handling for synchronous execution.

## [v4.2.2](https://github.com/plivo/plivo-dotnet/tree/v4.2.2) (2018-12-27)
- Fix dynamic object usage with async/await statement.

## [v4.2.1](https://github.com/plivo/plivo-dotnet/tree/v4.2.1) (2018-12-13)
- Fix Web Proxy Support.

## [v4.2.0](https://github.com/plivo/plivo-dotnet/tree/v4.2.0) (2018-12-04)
- Changed base reference to .NET Standard 2.0 to support System.Web.Proxy.
- Add Strong Naming instructions.

## [v4.1.7](https://github.com/plivo/plivo-dotnet/tree/v4.1.7) (2018-11-21)
- Add hangup party details to CDR. CDR filtering allowed by hangup_source and hangup_cause_code.
- Add sub-account cascade delete support.

## [v4.1.6](https://github.com/plivo/plivo-dotnet/tree/v4.1.6) (2018-10-31)
- Add live calls filtering by to, from numbers and call direction.

## [v4.1.5](https://github.com/plivo/plivo-dotnet/tree/v4.1.5) (2018-10-16)
- Add support for SSML tags.

## [v4.1.4](https://github.com/plivo/plivo-dotnet/tree/v4.1.4) (2018-10-01)
- Add Trackable parameter in messages.

## [v4.1.3](https://github.com/plivo/plivo-dotnet/tree/v4.1.3) (2018-09-17)
- Added parent_call_uuid parameter added to filter calls.
- Queued status added for filtering calls in queued status.

## [v4.1.2](https://github.com/plivo/plivo-dotnet/tree/v4.1.2) (2018-08-28)
- Added log_incoming_messages parameter to Create and Update Application api.

## [v4.1.1](https://github.com/plivo/plivo-dotnet/tree/v4.1.1) (2018-07-12)
- Added state parameter to message list api.
- Fixed deletion of rented number.
- Conference member mute response fix.
- Removed the optional [ & ] while formatting the date.

## [v4.1.0](https://github.com/plivo/plivo-dotnet/tree/v4.1.0) (2018-02-16)
- Added Address and Identity resources.
- Fixes #50 (NullReferenceException)

## [v4.0.0](https://github.com/plivo/plivo-dotnet/tree/v4.0.0) (2018-01-18)
- Supports v2 signature validation
- Targets .NET Standard 1.3
- All utils are moved to a neater namespace

## [v4.0.0-beta2](https://github.com/plivo/plivo-dotnet/tree/v4.0.0-beta2) (2017-11-02)
- Fix #41 - Pricing API interface from v4.0.0-beta1

## [v4.0.0-beta1](https://github.com/plivo/plivo-dotnet/tree/v4.0.0-beta1) (2017-10-30)
- The new SDK works with both .NET Framework (4.5+) and .NET Core (1.0+)
- The API interfaces are consistent and guessable

## Other changes
* 3.0.7 Re-release
* 3.0.6 Added addition verify signature function
* 3.0.5 Added support for RestSharp 105.2.3
* 3.0.4 Added digitsMatchBLeg parameter to Dial XML.
* 3.0.3 Fixed sorting in Verify function
* 3.0.2 Added answer_time and initiation_time to CDR model.
* 3.0.1 Added beep attribute to Wait XML.
* 3.0.0 Updated RestSharpSigned
* 2.0.2 Added Request API function, stop_speak_member function in Conference API and abstracted all API responses to a parent class PlivoResponse.
* 2.0.1 Added modify_number function.
* 2.0.0 Update and separate bundling of RestSharp client and add RestSharpSigned as nuget package dependency. Signed version enables it to work with modern as well as older projects that still require strongname binaries.
* 1.3.7 Make Verify Signature function public
* 1.3.5 PhoneNumber API
* 1.3.2 Added old_auth_token and auth_token fields to SubAccount response
* 1.3.1 Added log attribute in GetDigits to handle sensitive DTMF info
* 1.3.0 Added Delete Recording API
* 1.2.9 Added minSilence attribute in Wait, async attribute in DTMF, NuGet Update -selfrelayDTMF attribute in Conference, stop_speak() method and invalid_numbers in Call Response and added get_account, get_recordings, get_recording and get_recording_by_call_uuid methods
* 1.2.8 Fixed issue with returning of nested XML object.
* 1.2.7 Added 'recordWhenAlone' attribute in Conference XML.
* 1.2.6 Fixed available number group for renting numbers.
* 1.2.5 Fix issues with packaging.
* 1.2.3 Allow optional parameters on various APIs.
* 1.2.2 Minor change. Fix for speak api method.
* 1.2.0 Additional APIs coverage: incoming carrier and pricing. support for unicode.
* 1.1.7 Minor change. Updated attributes for Conference and Record Elements.
* 1.1.6 Minor change. Updated attributes for GetDigits Element.
* 1.1.5 Minor change. Updated attributes for Conference Element.
* 1.1.4 Minor change. Updated attributes for Record Element.
* 1.1.3 Minor fix for attribute error.
* 1.1.2 Added attribute to XML element Wait.
* 1.1.1 Added method for making bulk calls with sip headers for each.
* 1.1.0 Multilingual speak support html entities. Added the new message APIs. Also updated various model attributes to handle json response.
* 1.0.3 Minor fix to deal with GET request on few resources.
* 1.0.2 Minor fix for PlivoElement.AddWait method.
* 1.0.1 Minor fix for Number API calls.
* 1.0   Supports making Plivo APIs calls and generation of Plivo XML.
