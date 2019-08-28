﻿namespace BlazorHosted_CSharp.Client.Features.Counter
{
  using BlazorHosted_CSharp.Client.Pipeline.NotificationPostProcessor;
  using MediatR;
  using Microsoft.Extensions.Logging;
  using System.Threading;
  using System.Threading.Tasks;

  internal class IncrementCountNotificationHandler
    : INotificationHandler<PostPipelineNotification<IncrementCounterAction, CounterState>>
  {
    private readonly ILogger Logger;

    public IncrementCountNotificationHandler(ILogger<IncrementCountNotificationHandler> aLogger)
    {
      Logger = aLogger;
    }

    public Task Handle
    (
      PostPipelineNotification<IncrementCounterAction, CounterState> aPostPipelineNotification, 
      CancellationToken aCancellationToken
    )
    {
      Logger.LogDebug(aPostPipelineNotification.Request.GetType().Name);
      Logger.LogDebug($"{nameof(IncrementCountNotificationHandler)} handled");
      return Task.CompletedTask;
    }
  }
}