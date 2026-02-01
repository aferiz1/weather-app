const getIcon = (desc) => {
  if (desc.includes("rain")) return "🌧️";
  if (desc.includes("cloud")) return "☁️";
  if (desc.includes("clear")) return "☀️";
  if (desc.includes("snow")) return "❄️";
  return "🌡️";
};

export default getIcon;
