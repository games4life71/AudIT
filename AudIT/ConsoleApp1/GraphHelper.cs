﻿using System.Net.Http.Headers;
using Azure.Core;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace ConsoleApp1;

public class GraphHelper
{
    // Settings object
    private static Settings? _settings;

// User auth token credential
    private static DeviceCodeCredential? _deviceCodeCredential;

// Client configured with user authentication
    private static GraphServiceClient? _userClient;

    public static void InitializeGraphForUserAuth(Settings settings,
        Func<DeviceCodeInfo, CancellationToken, Task> deviceCodePrompt)
    {
        _settings = settings;

        var options = new DeviceCodeCredentialOptions
        {
            ClientId = settings.ClientId,
            TenantId = settings.TenantId,
            DeviceCodeCallback = deviceCodePrompt,
        };

        _deviceCodeCredential = new DeviceCodeCredential(options);
        Console.WriteLine("asdasdasd" + _deviceCodeCredential.GetToken(new TokenRequestContext()));

        //reuse the token

        _userClient = new GraphServiceClient(_deviceCodeCredential, settings.GraphUserScopes);
        // _userClient = new GraphServiceClient(
        //     new Delegate(async (requestMessage) =>
        //     {
        //         // Request a token
        //         var token = await GetUserTokenAsync();
        //         // Set the token on the request
        //         requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
        //     })
        //
        // );
    }

    public static async Task<string> GetUserTokenAsync()
    {
        // Ensure credential isn't null
        _ = _deviceCodeCredential ??
            throw new System.NullReferenceException("Graph has not been initialized for user auth");

        // Ensure scopes isn't null
        _ = _settings?.GraphUserScopes ?? throw new System.ArgumentNullException("Argument 'scopes' cannot be null");

        // Request token with given scopes
        var context = new TokenRequestContext(_settings.GraphUserScopes);
        var response = await _deviceCodeCredential.GetTokenAsync(context);

        return response.Token;
    }
    public static Task<MessageCollectionResponse?> GetInboxAsync()
    {
        // Ensure client isn't null
        _ = _userClient ??
            throw new System.NullReferenceException("Graph has not been initialized for user auth");

        return _userClient.Me
            // Only messages from Inbox folder
            .MailFolders["Inbox"]
            .Messages
            .GetAsync((config) =>
            {
                // Only request specific properties
                config.QueryParameters.Select = new[] { "from", "isRead", "receivedDateTime", "subject" };
                // Get at most 25 results
                config.QueryParameters.Top = 25;
                // Sort by received time, newest first
                config.QueryParameters.Orderby = new[] { "receivedDateTime DESC" };
            });
    }
}