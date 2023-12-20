// See https://aka.ms/new-console-template for more information

using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extensions;

var collection = new ServiceCollection();
collection.AddInfrastructure("Host=localhost;Username=postgres;Password=postgres;Database=postgres;");
collection.AddApplication("VERY_SECRET");
collection.AddPresentation();
IStartService a = collection.BuildServiceProvider().GetRequiredService<IStartService>();
a.Start();