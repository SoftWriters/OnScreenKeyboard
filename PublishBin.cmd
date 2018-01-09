IF NOT EXIST bin\ mkdir bin
dotnet publish src/FrontEnd/MapToKeyboardInput/MapToKeyboardInput.csproj -c Release -f netcoreapp2.0 -r win10-x64 -o ../../../bin/
