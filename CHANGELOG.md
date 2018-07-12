# Change Log

## [v4.1.1](https://github.com/plivo/plivo-dotnet/tree/v4.1.1) (2018-06-29)
- Added state parameter to message list api.
- Fixed deletion of rented number.

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
