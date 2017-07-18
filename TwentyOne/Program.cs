using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace TwentyOne
                                                                                                                                            {
    class Program
                                                                                                                                            {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
                                                                                                                                            {
            var config = new DiscordSocketConfig
                                                                                                                                            {
                TotalShards = 1,
                ShardId = 0,
                                                                                                                                            };

            var client = new DiscordShardedClient(config);

            client.Log += msg =>
                                                                                                                                            {
                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;
                                                                                                                                            };

            client.MessageReceived += msg =>
                                                                                                                                            {
                if (msg.Author.IsBot) return Task.CompletedTask;

                if (msg.Content.ToLower().Contains("savage"))
                    _ = msg.Channel.SendMessageAsync("21");
                else if (msg.Content.ToLower().Contains("21"))
                    _ = msg.Channel.SendMessageAsync("savage");

                return Task.CompletedTask;
                                                                                                                                            };

            string token = File.ReadAllText("token.png");
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
                                                                                                                                            }
                                                                                                                                            }
                                                                                                                                            }