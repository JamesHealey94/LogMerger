FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY output ./
COPY src/LogMerger.Runner/resources ./input
ENTRYPOINT ["dotnet", "LogMerger.Runner.dll"]