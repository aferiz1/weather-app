import {
  Card,
  City,
  Description,
  Temperature,
  InfoRow,
} from "./WeatherCard.styles";
import getIcon from "../../utils/getIcon";

const WeatherCard = ({ weather }) => {
  if (!weather) return null;
  const icon = getIcon(weather.description.toLowerCase());

  return (
    <Card>
      <City>{weather.city}</City>
      <Description>
        {icon} {weather.description}
      </Description>
      <Temperature temp={weather.temperature}>
        {Math.round(weather.temperature)}°C
      </Temperature>
      <InfoRow>
        <span>💧 {weather.humidity}%</span>
        <span>💨 {weather.windSpeed} m/s</span>
      </InfoRow>
    </Card>
  );
};

export default WeatherCard;
