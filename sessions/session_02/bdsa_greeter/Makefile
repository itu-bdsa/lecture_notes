.PHONY: all build clean

all: build

bin/Release/net7.0/linux-x64/publish/hello: Program.cs bdsa_greeter.csproj
	dotnet publish -r linux-x64

bin/Release/net7.0/win-x64/publish/hello.exe: Program.cs bdsa_greeter.csproj
	dotnet publish -r win-x64

bin/Release/net7.0/osx-x64/publish/hello: Program.cs bdsa_greeter.csproj
	dotnet publish -r osx-x64

build: bin/Release/net7.0/linux-x64/publish/hello bin/Release/net7.0/win-x64/publish/hello.exe bin/Release/net7.0/osx-x64/publish/hello

clean:
	rm -r ./bin/ ./obj/
