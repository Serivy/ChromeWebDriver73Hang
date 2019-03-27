nuget.exe restore WebDriverTest.sln

if exist "C:\Program Files (x86)\Microsoft Visual Studio\Preview\Enterprise\MSBuild\15.0\Bin\msbuild.exe" (
    "C:\Program Files (x86)\Microsoft Visual Studio\Preview\Enterprise\MSBuild\15.0\Bin\msbuild.exe" WebDriverTest.sln
) else (
    "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe" WebDriverTest.sln
)