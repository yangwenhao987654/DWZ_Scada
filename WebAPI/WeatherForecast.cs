namespace WebAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class ResultDTO
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public int Age { get; set; }
    }
}
