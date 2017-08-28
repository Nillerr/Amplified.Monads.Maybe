cls

dotnet --version

dotnet restore Amplified.Monads.Maybe
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet build Amplified.Monads.Maybe
if %errorlevel% neq 0 exit /b %errorlevel%


dotnet restore Amplified.Monads.Maybe.Tests
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet build Amplified.Monads.Maybe.Tests
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet test Amplified.Monads.Maybe.Tests/Amplified.Monads.Maybe.Tests.csproj
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet pack Amplified.Monads.Maybe
if %errorlevel% neq 0 exit /b %errorlevel%