import { useState } from "react";
import { ThemeProvider } from "styled-components";
import { fetchWeather } from "./services/weatherService";

import SearchBar from "./components/search-bar/SearchBar";
import WeatherCard from "./components/weather-card/WeatherCard";
import ErrorCard from "./components/error-card/ErrorCard";

function App() {
  const [city, setCity] = useState("");
  const [weather, setWeather] = useState(null);
  const [theme, setTheme] = useState("light");
  const [error, setError] = useState(null);

  const handleSearch = async () => {
    try {
      const data = await fetchWeather(city);
      setWeather(data);
      setError(null);
    } catch (err) {
      console.error(err);
      setWeather(null);
      setError("City not found. Please try again.");
    }
  };

  return (
    <ThemeProvider theme={{ mode: theme }}>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          textAlign: "center",
          padding: 24,
        }}
      >
        <button onClick={() => setTheme(theme === "light" ? "dark" : "light")}>
          {theme === "light" ? "🌙 Dark Mode" : "☀️ Light Mode"}
        </button>

        <SearchBar city={city} setCity={setCity} onSearch={handleSearch} />

        {error && <ErrorCard message={error} />}
        {weather && <WeatherCard weather={weather} />}
      </div>
    </ThemeProvider>
  );
}

export default App;
