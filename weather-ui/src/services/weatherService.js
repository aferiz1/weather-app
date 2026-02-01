export const fetchWeather = async (city) => {
  const res = await fetch(
    `http://localhost:5196/api/weathersnapshots/fetch?city=${city}`,
    { method: "POST" }
  );

  if (!res.ok) throw new Error("Failed to fetch weather");
  return res.json();
};
