FROM microsoft/dotnet:latest

COPY ./bin/Debug/netcoreapp1.0/debian.8-x64/publish /app/

WORKDIR /app

EXPOSE 8001

ENTRYPOINT ["dotnet", "CalculatorDotnetCore.dll"]
