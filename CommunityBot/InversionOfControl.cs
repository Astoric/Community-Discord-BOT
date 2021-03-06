using CommunityBot.Configuration;
using CommunityBot.Features.Trivia;
using CommunityBot.Handlers;
using Discord.Commands;
using Discord.WebSocket;
using Lamar;

namespace CommunityBot
{
    public static class InversionOfControl
    {
        private static Container container;

        public static Container Container
        {
            get
            {
                return GetOrInitContainer();
            }
        }

        private static Container GetOrInitContainer()
        {
            if(container is null)
            {
                InitializeContainer();
            }

            return container;
        }

        public static void InitializeContainer(ApplicationSettings settings = null)
        {
            container = new Container(c =>
            {
                // c.For<UserIssueRepository>().Use<UserIssueDatabaseRepository>();
                // c.ForSingletonOf<ConnectionService>().UseIfNone<DiscordConnectionService>();
                // c.ForSingletonOf<DiscordSocketClient>().UseIfNone<DiscordSocketClient>();
                c.ForSingletonOf<Logger>().UseIfNone<Logger>();
                c.ForSingletonOf<TriviaGame>().UseIfNone<TriviaGame>();
                c.ForSingletonOf<DiscordEventHandler>().UseIfNone<DiscordEventHandler>();
                c.ForSingletonOf<CommandHandler>().UseIfNone<CommandHandler>();
                c.ForSingletonOf<CommandService>().UseIfNone<CommandService>();
                c.ForSingletonOf<ServerActivityLogger.ServerActivityLogger>().UseIfNone<ServerActivityLogger.ServerActivityLogger>();
                c.ForSingletonOf<DiscordSocketClient>().UseIfNone(DiscordClientFactory.GetBySettings(settings));
                c.ForSingletonOf<ApplicationSettings>().UseIfNone(settings);
            });
        }
    }
}
