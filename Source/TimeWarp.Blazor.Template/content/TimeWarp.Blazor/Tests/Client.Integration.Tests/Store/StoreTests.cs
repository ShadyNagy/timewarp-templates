namespace TimeWarp.Blazor.Integration.Tests
{
  using BlazorState;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using System.IO;
  using TimeWarp.Blazor.ApplicationFeature;
  using TimeWarp.Blazor.CounterFeature;
  using TimeWarp.Blazor.Integration.Tests.Infrastructure;
  using TimeWarp.Blazor.WeatherForecastFeature;

  internal class StoreTests : BaseTest
  {
    private readonly IReduxDevToolsStore ReduxDevToolsStore;

    public StoreTests(WebAssemblyHost aWebAssemblyHost) : base(aWebAssemblyHost)
    {
      ReduxDevToolsStore = aWebAssemblyHost.Services.GetService<IReduxDevToolsStore>();
    }

#if ReduxDevToolsEnabled
    public void ShouldLoadStatesFromJson()
    {
      //Arrange
      string jsonString = File.ReadAllText("./Store/Store.json");
      //Act
      ReduxDevToolsStore.LoadStatesFromJson(jsonString);
      // Assert
      ApplicationState applicationState = Store.GetState<ApplicationState>();
      applicationState.Name.ShouldBe("Blazor State Demo Application");
      applicationState.Guid.ToString().ShouldBe("5a2efcec-6297-4254-a2dc-30e4e567e549");

      CounterState counterState = Store.GetState<CounterState>();
      counterState.Count.ShouldBe(18);
      counterState.Guid.ToString().ShouldBe("a0d74c63-13f4-4a2f-b18b-9a1fdaa397b2");

      WeatherForecastsState weatherForecastsState = Store.GetState<WeatherForecastsState>();
      weatherForecastsState.WeatherForecasts.Count.ShouldBe(5);
      weatherForecastsState.WeatherForecasts[0].Summary.ShouldBe("Freezing");
      weatherForecastsState.WeatherForecasts[0].TemperatureC.ShouldBe(16);
      weatherForecastsState.WeatherForecasts[0].TemperatureF.ShouldBe(60);
      weatherForecastsState.WeatherForecasts[0].Date.Year.ShouldBe(2018);
      weatherForecastsState.WeatherForecasts[0].Date.Month.ShouldBe(8);
      weatherForecastsState.WeatherForecasts[0].Date.Day.ShouldBe(26);
      weatherForecastsState.WeatherForecasts[0].Date.Hour.ShouldBe(9);
      weatherForecastsState.WeatherForecasts[0].Date.Minute.ShouldBe(29);
      weatherForecastsState.WeatherForecasts[0].Date.Second.ShouldBe(54);
    }
#endif

    /// <summary>
    /// WeatherForecatesState will throw an exception if items initialized in the constructor are null.
    /// </summary>
    public void ShouldInitializeStateAfterConstruction()
    {
      WeatherForecastsState state = Store.GetState<WeatherForecastsState>();
      state.ShouldNotBeNull();
    }
  }
}