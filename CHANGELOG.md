
# Change Log

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
