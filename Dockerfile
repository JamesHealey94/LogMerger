FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY output ./
ENTRYPOINT ["dotnet", "LogMerger.Runner.dll"]