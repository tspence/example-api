namespace ExampleApi
{
    /// <summary>
    /// An example forecast
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// The date for the forecast
        /// </summary>
        public string Date { get; set; } = "";

        /// <summary>
        /// The temperature in Celsius
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// The temperature in Fahrenheit
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary of the forecast
        /// </summary>
        public string? Summary { get; set; }
    }
}