# FTP Protocol

Prosty projekt FTP zrealizowany w C# jako eksperyment z protokołem FTP oraz komunikacją sieciową w .NET.

## Co zawiera

- `FTP_Server` - podstawowa implementacja serwera FTP
- `FTP_Client` - klient testowy / punkt startowy dla klienta FTP

## Technologie

- C#
- .NET
- Sockets / TCP

## Uruchomienie

1. Otwórz rozwiązanie:
   ```bash
   dotnet restore
   dotnet build
   ```
2. Uruchom serwer:
   ```bash
   dotnet run --project FTP_Server
   ```
3. Uruchom klient:
   ```bash
   dotnet run --project FTP_Client
   ```

## Uwagi

To jest prosty prototyp i nie zawiera pełnej implementacji specyfikacji FTP RFC 959. Projekt służy głównie do nauki i eksperymentów z komunikacją TCP oraz komendami FTP.

## Struktura projektu

```text
FTP_Protocol/
├── FTP_Server/
│   ├── Program.cs
│   ├── FTP.cs
│   ├── Server_Extension.cs
│   └── FTP_Server.csproj
├── FTP_Client/
│   ├── Program.cs
│   └── FTP_Client.csproj
├── FTP_Proj.sln
├── README.md
└── .gitignore
```
