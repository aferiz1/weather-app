#Weather App

Weather-app je mala web aplikacija koja se sastoji od backenda i frontenda. Služi da se dobije trenutno vrijeme za grad koji se pretražuje.

Stack koji je korišten:

Backend: .NET (C#)

Baza: SQL Server

Frontend: React.js

Backend šalje zahtjev prema OpenWeatherMap API (https://openweathermap.org/), prikuplja podatke za traženi grad, pohranjuje ih u bazu i šalje frontend-u,
koji prikazuje podatke.

Trenutno backend je podešen da šalje zahtjev svakih 30 minuta i prikuplja podatke za već pretražene gradove (cron job). Frontend dobiva samo posljednje pohranjene podatke.

Instrukcije za pokretanje aplikacije:

#Backend (WeatherAPI)

Nakon što ste klonirali repozitorij, otvorite terminal u folderu WeatherAPI.

Instalirajte NuGet pakete: -> dotnet restore

Promijenite konekciju u appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Weather;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False"
}
Zamijenite (localdb)\\MSSQLLocalDB s nazivom svoje SQL konekcije u SSMS-u.

Dodajte svoj OpenWeather API key ( dobit ćete ga na https://openweathermap.org/):

"OpenWeather": {
  "ApiKey": "YOUR_API_KEY_HERE",
  "BaseUrl": "https://api.openweathermap.org/data/2.5/weather"
}

Pokrenite migracije i update baze: -> dotnet ef database update

Pokrenite backend: -> dotnet run

Trebalo bi da vidite:-> Now listening on: http://localhost:5196


#Frontend (weather-ui)

Otvorite terminal u folderu weather-ui.

Instalirajte dependencies: -> npm install

Ako koristite Windows PowerShell i dobijete grešku:

npm.ps1 cannot be loaded. The file is not digitally signed

Rješenje: otvorite PowerShell kao administrator i pokrenite: -> Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

Zatvorite terminal i pokušajte ponovo -> npm install.

Pokrenite frontend: -> npm run dev

Trebali biste vidjeti:-> Local:   http://localhost:5173/

Otvorite browser i idite na http://localhost:5173/ da testirate aplikaciju.
