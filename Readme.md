This repo reproduces the issues with Chrome Web Driver on Chrome 73. ("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36"). The previous version 72.0.3626.121 did not fail.

Either the webdriver hangs, and when terminated will report the following error, or after a long duration it will close and report the same error:
```
The HTTP request to the remote WebDriver server for URL http://localhost:54379/session/0dfe5c28392999edbe50c90c6504cb0c/window/current/size timed out after 60 seconds.
```
This only occurs when setting the browser window size.

# Prerequisites
* Windows
* Visual Studio 2017
* Powershell
* Chrome 73

# Steps to reproduce
Run powershell in admin mode to enable remote sessions

`> Enable-PSRemoting`
Create a session and go to this git folder (or clone it> `git clone https://github.com/Serivy/ChromeWebDriver73Hang.git`)
`> Enter-PSSession -ComputerName localhost`

Build the project (nuget restore and then msbuild the solution)

`> ChromeWebDriver73Hang> .\build.bat`

Run the test

`ChromeWebDriver73Hang> .\run.bat`

The test will hang as seen below.
If run on chrome 72 or 71 it will not fail.

```
[localhost]: PS X:\ChromeWebDriver73Hang> .\run.bat

X:\ChromeWebDriver73Hang>"X:\ChromeWebDriver73Hang\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe" "X:\ChromeWebDriver73Hang\bin\Debug\WebDriverTest.dll" --work="X:\ChromeWebDriver73Hang\." --result=WebTestResults.xml
NUnit Console Runner 3.10.0 (.NET 2.0)
Copyright (c) 2019 Charlie Poole, Rob Prouse
Wednesday, 27 March 2019 12:19:27 PM

Runtime Environment
   OS Version: Microsoft Windows NT 10.0.17763.0
  CLR Version: 4.0.30319.42000

Test Files
    X:\ChromeWebDriver73Hang\bin\Debug\WebDriverTest.dll

    Errors, Failures and Warnings

1) Error : WebDriverTest.Tests.RunTest
OpenQA.Selenium.WebDriverException : The HTTP request to the remote WebDriver server for URL http://localhost:54379/session/0dfe5c28392999edbe50c90c6504cb0c/window/current/size timed out after 60 seconds.
  ----> System.Net.WebException : The request was aborted: The operation has timed out.
   at OpenQA.Selenium.Remote.HttpCommandExecutor.MakeHttpRequest(HttpRequestInfo requestInfo)
   at OpenQA.Selenium.Remote.HttpCommandExecutor.Execute(Command commandToExecute)
   at OpenQA.Selenium.Remote.DriverServiceCommandExecutor.Execute(Command commandToExecute)
   at OpenQA.Selenium.Remote.RemoteWebDriver.Execute(String driverCommandToExecute, Dictionary`2 parameters)
   at OpenQA.Selenium.Remote.RemoteWindow.set_Size(Size value)
   at WebDriverTest.Tests.RunTest() in X:\ChromeWebDriver73Hang\Tests.cs:line 14
--WebException
   at System.Net.HttpWebRequest.GetResponse()
   at OpenQA.Selenium.Remote.HttpCommandExecutor.MakeHttpRequest(HttpRequestInfo requestInfo)

Run Settings
    DisposeRunners: True
    WorkDirectory: X:\ChromeWebDriver73Hang\.
    ImageRuntimeVersion: 4.0.30319
    ImageTargetFrameworkName: .NETFramework,Version=v4.6.1
    ImageRequiresX86: False
    ImageRequiresDefaultAppDomainAssemblyResolver: False
    NumberOfTestWorkers: 8

Test Run Summary
  Overall result: Failed
  Test Count: 1, Passed: 0, Failed: 1, Warnings: 0, Inconclusive: 0, Skipped: 0
    Failed Tests - Failures: 0, Errors: 1, Invalid: 0
  Start time: 2019-03-27 04:19:27Z
    End time: 2019-03-27 04:21:55Z
    Duration: 147.458 seconds

Results (nunit3) saved as WebTestResults.xml
[localhost]: PS X:\ChromeWebDriver73Hang>
```