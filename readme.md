# Unity3D Automated Tests - 2DColliders

## About / Synopsis

* This is a my submission for the take home task for the Quality Software Engineer role.
* This contains tests the 2D Collider components in Unity3D, mainly BoxCollider2D / CircleCollider2D
    
### What it does:

* Run the TestRunner with Unity3D with the specified parameters
* Parse the test results from .XML to .HTML reports
* Upload the .HTML reports into the authenticated user's Google Drive in a new test directory

## Installation

* Specify your preferred version of Unity editor's path as environment user variable `Unity`. 

An example of the value is "C:\Program Files\Unity\Hub\Editor\2020.2.2f1\Editor\"

If that's undesired, please ammend the file `unityTestFull.bat` to point it to the Unity3D editor executable path of your choice.


## Usage

* Simply run the batch file `unityTestFull.bat` in the project's directory to execute the full flow of the tests, no other parameters needed
* After all the steps are executed, the test report can either be referenced in `/results` directory of the project, or in the user's Google Drive if successfully uploaded.


## Disclaimer

This project utilises another git project [Extent .NET CLI](https://github.com/extent-framework/extentreports-dotnet-cli) for the parsing of the NUnit-based TestRunner's .XML into a .HTML test report. Its executable `extent.exe` is being called by the batch file.

After the parsing of the test report, it will attempt to upload the test reports into the user's Google Drive in a new TestReport directory. 

This functionality is written in Python utilising Google Drive API, and means that the user has to authenticate with the Google SSO in order to proceed with the uploading of the files. 

The Google Drive upload is a demonstration of how it can be done but mutual trust is needed. The service won't abuse your Google SSO, and also please don't tinker with the supplied personal credentials necessary to make it work.

## Notes

2D Colliders is chosen as the components of choice here is simply due to it being one of the easier 2D feature to demonstrate testing capabilities in a short timeframe. 

I've also focused exclusively on the Play Mode tests, to avoid the potential tediousness of managing both PlayMode / EditorMode test executions.

Also there are plenty of improvements and places that can be done better (Usage of proper GameManager(s), variable naming, variable encapsulation, architectures, robust GoogleDrive handling, etc etc. There's plenty to learn here as well.


