


Thread.Sleep(7000);

using (var client = new HttpClient())
{
    var result = client
        .GetAsync("https://localhost:7295/WeatherForecast/Get")
        .GetAwaiter().GetResult();

    Console.WriteLine(result.IsSuccessStatusCode);
    
    if (result.IsSuccessStatusCode)
    {
        var model = result.Content.ReadAsStringAsync()
            .GetAwaiter().GetResult();

        Console.WriteLine(model);
    }
    else
    {
        Console.WriteLine(result.RequestMessage);
    }

}



Console.Read();