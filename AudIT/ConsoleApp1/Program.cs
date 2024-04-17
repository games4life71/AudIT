// // // See https://aka.ms/new-console-template for more information
// //
// //
// // using AudiT.Domain.Entities;
// // using AudIT.Domain.Misc;
// //
// // using AudIT.Infrastructure;
// // using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// // using Microsoft.EntityFrameworkCore;
// //
// // var db = new AudITContext();
// // //
// // // var inst = Institution.Create(
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd"
// // // ).Value;
// // //
// // //
// // // var depart = Department.Create(
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     institution: inst
// // // ).Value;
// // //
// // // var user = AudiT.Domain.Entities.User.Create(
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     "asdasd",
// // //     depart
// // // ).Value;
// // //
// // //
// // // var temp_doc = TemplateDocument.Create(
// // //     "asdasd",
// // //     "asdasd",
// // //     user,
// // //     user.Id,
// // //     DocumentState.Draft,
// // //     TemplateTypeStage.PregatireaMisiunii,
// // //     1
// // // ).Value;
// // //
// // //
// // // var st_doc = StandaloneDocument.Create(
// // //     "standalone",
// // //     "asdasd",
// // //     user,
// // //     user.Id,
// // //     depart,
// // //     depart.Id
// // // ).Value;
// // //
// // //
// // // //
// // // // db.Add(inst);
// // // // db.Add(depart);
// // // // db.Add(user);
// // // db.Add(temp_doc);
// // //
// // // db.Add(st_doc);
// // // db.SaveChanges();
// // // //
// // // // //get all the documents
// // // // var standaloneDocuments = db.StandaloneDocuments.ToList();
// // // // var templateDocuments = db.TemplateDocuments.ToList();
// // // //
// // // // Console.WriteLine("Standalone Documents:" + standaloneDocuments[0].Name);
// // // // // Console.WriteLine("Template Documents:" + templateDocuments[0].Name);
// // //
// // // //
// // // var auditMission = AuditMission.Create(
// // //     "asdasd123",
// // //     user,
// // //     user.Id,
// // //     depart,
// // //     depart.Id
// // // ).Value;
// // // //
// // // // var auditMissionDocument =   AuditMissionDocument.Create(
// // // //     auditMission,
// // // //     st_doc
// // // // ).Value;
// // // //
// // // // var auditMissionDocument2 =   AuditMissionDocument.Create(
// // // //     auditMission,
// // // //     temp_doc
// // // // ).Value;
// // // //
// // // //
// // // // auditMission.AuditMissionDocuments.Add(auditMissionDocument);
// // // // auditMission.AuditMissionDocuments.Add(auditMissionDocument2);
// // // // //
// // // // //
// // // db.Add(auditMission);
// // // db.SaveChanges();
// // //
// // //
// // // //retrieve the audit mission
// // //
// // // // var auditMission_db = db.AuditMissions.
// // // //     Include(auditMission1 => auditMission1.AuditMissionDocuments).
// // // //     ThenInclude(baseDocument => baseDocument.BaseDocument).First();
// // // //
// // // // Console.WriteLine("Audit Mission:" + auditMission_db.Name);
// // // // foreach (var doc in auditMission_db.AuditMissionDocuments)
// // // // {
// // // //     Console.WriteLine("Audit Mission Document:" + doc.BaseDocument.Name);
// // // // }
// // //
// // //
// // // //add a new objective
// // //
// // // var objective = Objectives.Create(
// // //     "test objective",
// // //     auditMission
// // // ).Value;
// // //
// // //
// // // var objectiveAction = ObjectiveAction.Create(
// // //     "test action",
// // //     true
// // // ).Value;
// // //
// // // var actionRisk = ActionRisk.Create(
// // //     "test risk",
// // //     Risk.Mare
// // // ).Value;
// // //
// // // objectiveAction.ActionRisks.Add(actionRisk);
// // // objective.ObjectiveActions.Add(objectiveAction);
// // // var auditMissionObjectives = AuditMissionObjectives.Create(
// // //     auditMission,
// // //     objective
// // // ).Value;
// // //
// // //
// // // db.Add(objective);
// // // db.Add(objectiveAction);
// // // db.Add(actionRisk);
// // // db.Add(auditMissionObjectives);
// // // db.SaveChanges();
// // //
// // //
// // // //retrieve the audit mission complete with objectives
// // //
// // // var audit_mission = db.AuditMissions.Find(Guid.Parse("502FDBE1-80D1-480B-AE76-A9907DBF04BE"));
// // //
// // // //get the objectives of the audit mission
// // //
// // // var objectives = db.AuditMissionObjectives.Where(auditmissobj => auditmissobj.AuditMissionId == audit_mission.Id)
// // //     .Include(audit_missionobj => audit_missionobj.Objectives).ToList();
// // //
// // // // foreach (var objective1 in objectives)
// // // // {
// // // //     Console.WriteLine("Objectives:" + objective.Objectives.Name);
// // // // }
// // //
// // // //get all the documents of the audit mission
// // //
// // // var documents = db.AuditMissionDocument.Where(auditDoc => auditDoc.AuditMissionId == audit_mission.Id)
// // //     .Include(auditDoc => auditDoc.BaseDocument).ToList()
// // //     .ToList();
// // //
// // //
// // // foreach (var document in documents)
// // // {
// // //     Console.WriteLine("Document:" + document.BaseDocument.Name);
// // // }
// // //
// // // //get all the objectives action and risks
// // //
// // // var objectives_actions = db.Objectives.Where(objective => objective.AuditMissionId == audit_mission.Id)
// // //     .Include(objective => objective.ObjectiveActions).ThenInclude(objectiveAction => objectiveAction.ActionRisks)
// // //     .ToList();
// // //
// // //
// // // foreach (var  objact in objectives_actions)
// // // {
// // //     Console.WriteLine("Objectives:" + objact.Name);
// // //     foreach (var objectt in objact.ObjectiveActions)
// // //     {
// // //         Console.WriteLine("Objectives Activity:" +  objectt.Name);
// // //         foreach (var risk in  objectt.ActionRisks)
// // //         {
// // //             Console.WriteLine("Risk:" + risk.Name);
// // //         }
// // //     }
// //
// // // }
// //
// // //add a new institution
// // var institution = Institution.Create(
// //     "asdasd",
// //     "asdasd",
// //     "asdasd"
// // ).Value;
// //
// // db.Add(institution);
// // db.SaveChanges();
// //
// // //add a new department
// // var depart1 = Department.Create(
// //     "asdasd",
// //     "asdasd",
// //     "asdasd",
// //     institution: institution
// // ).Value;
// //
// // db.Add(depart1);
// // db.SaveChanges();
// // //
// // // // //add a new aspnet user
// // //
// // // //get the department
// // //
// // var depart  = db.Departments.First(depart => depart.Name == "asdasd");
// //
// //
// //
// //  var user = AudiT.Domain.Entities.User.Create(
// //
// //         "asdasd",
// //         "asdasd",
// //         "asdasd",
// //         "asdasd",
// //         "asdasd",
// //         "asdasd",
// //         "depart",
// //         "depart",
// //         depart
// //     ).Value;
// //
// //     // identity.Add(user);
// //     // identity.SaveChanges();
// //     db.Add(user);
// //     db.SaveChanges();
// //
// //
// //
// // //create a new audit mission
// // var auditMission = AuditMission.Create(
// //     "asdasd123",
// //     user,
// //     Guid.Parse(user.Id),
// //     depart,
// //     depart.Id
// // ).Value;
// //
// // db.Add(auditMission);
// //
// // db.SaveChanges();
// //
// // //retrieve the audit mission with the user that created it
// // var miss = db.AuditMissions
// //     .Include(am => am.User)
// //     .First();
// //
// // Console.WriteLine("Audit Mission user :" + miss.User.UserName);
// //
// // using ConsoleApp1;
// //
// // Console.WriteLine(".NET Graph Tutorial\n");
// //
// // var settings = Settings.LoadSettings();
// //
// // // Initialize Graph
// // InitializeGraph(settings);
// //
// // // Greet the user by name
// // await GreetUserAsync();
// //
// // int choice = -1;
// //
// // while (choice != 0)
// // {
// //     Console.WriteLine("Please choose one of the following options:");
// //     Console.WriteLine("0. Exit");
// //     Console.WriteLine("1. Display access token");
// //     Console.WriteLine("2. List my inbox");
// //     Console.WriteLine("3. Send mail");
// //     Console.WriteLine("4. Make a Graph call");
// //
// //     try
// //     {
// //         choice = int.Parse(Console.ReadLine() ?? string.Empty);
// //     }
// //     catch (System.FormatException)
// //     {
// //         // Set to invalid value
// //         choice = -1;
// //     }
// //
// //     switch(choice)
// //     {
// //         case 0:
// //             // Exit the program
// //             Console.WriteLine("Goodbye...");
// //             break;
// //         case 1:
// //             // Display access token
// //             await DisplayAccessTokenAsync();
// //             break;
// //         case 2:
// //             // List emails from user's inbox
// //             await ListInboxAsync();
// //             break;
// //         case 3:
// //             // Send an email message
// //             await SendMailAsync();
// //             break;
// //         case 4:
// //             // Run any Graph code
// //             await MakeGraphCallAsync();
// //             break;
// //         default:
// //             Console.WriteLine("Invalid choice! Please try again.");
// //             break;
// //     }
// // }
// //
// // void InitializeGraph(Settings settings)
// // {
// //     GraphHelper.InitializeGraphForUserAuth(settings,
// //         (info, cancel) =>
// //         {
// //             // Display the device code message to
// //             // the user. This tells them
// //             // where to go to sign in and provides the
// //             // code to use.
// //             Console.WriteLine(info.Message);
// //             return Task.FromResult(0);
// //         });
// // }
// //
// // async Task GreetUserAsync()
// // {
// //     // TODO
// // }
// //
// // async Task DisplayAccessTokenAsync()
// // {
// //     try
// //     {
// //         var userToken = await GraphHelper.GetUserTokenAsync();
// //         Console.WriteLine($"User token: {userToken}");
// //     }
// //     catch (Exception ex)
// //     {
// //         Console.WriteLine($"Error getting user access token: {ex.Message}");
// //     }
// // }
// //
// // async Task ListInboxAsync()
// // {
// //     try
// //     {
// //         var messagePage = await GraphHelper.GetInboxAsync();
// //
// //         if (messagePage?.Value == null)
// //         {
// //             Console.WriteLine("No results returned.");
// //             return;
// //         }
// //
// //         // Output each message's details
// //         foreach (var message in messagePage.Value)
// //         {
// //             Console.WriteLine($"Message: {message.Subject ?? "NO SUBJECT"}");
// //             Console.WriteLine($"  From: {message.From?.EmailAddress?.Name}");
// //             Console.WriteLine($"  Status: {(message.IsRead!.Value ? "Read" : "Unread")}");
// //             Console.WriteLine($"  Received: {message.ReceivedDateTime?.ToLocalTime().ToString()}");
// //         }
// //
// //         // If NextPageRequest is not null, there are more messages
// //         // available on the server
// //         // Access the next page like:
// //         // var nextPageRequest = new MessagesRequestBuilder(messagePage.OdataNextLink, _userClient.RequestAdapter);
// //         // var nextPage = await nextPageRequest.GetAsync();
// //         var moreAvailable = !string.IsNullOrEmpty(messagePage.OdataNextLink);
// //
// //         Console.WriteLine($"\nMore messages available? {moreAvailable}");
// //     }
// //     catch (Exception ex)
// //     {
// //         Console.WriteLine($"Error getting user's inbox: {ex.Message}");
// //     }
// // }
// //
// // async Task SendMailAsync()
// // {
// //     // TODO
// // }
// //
// // async Task MakeGraphCallAsync()
// // {
// //     // TODO
// // }
//
//
// // Initialize the MSAL library with your application's configuration settings
// //
// // using System.Net.Http.Headers;
// // using Microsoft.Graph;
// // using Microsoft.Identity.Client;
// // using System.IO;
// // using System.Security.Cryptography;
// // using System.Text;
// // using Azure.Core;
// // using ConsoleApp1;
// //
// // string[] scopes = new string[] { "user.read", "mail.read" };
// //
// // var app = PublicClientApplicationBuilder.Create(
// //         "f74157c8-597d-4fca-a284-bb3d01ff4a56")
// //     .WithRedirectUri("http://localhost")
// //     .Build();
// //
// //
// // TokenCacheHelper.EnableSerialization(app.UserTokenCache);
// //
// //
// //
// // var accounts = await app.GetAccountsAsync();
// // if (accounts == null)
// // {
// //     Console.WriteLine("No accounts were found in the token cache on frst try.");
// // }
// // //AfR8Q~TfNNU0SHWUuNow-ThmNSHksQv_H61ufbyg
// //
// // else if (!accounts.Any())
// // {
// //     Console.WriteLine("No accounts were found in the token cache on frst aaaatry.");
// // }
// //
// // AuthenticationResult result;
// //
// // try
// // {
// //     result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
// //         .ExecuteAsync();
// //     Console.WriteLine("AcquireTokenSilent succeeded");
// // }
// // catch (MsalUiRequiredException e)
// // {
// //     // Console.WriteLine("error is " + e.Message);
// //     Console.WriteLine("AcquireTokenSilent failed, trying AcquireTokenInteractive");
// //     result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
// //     Console.WriteLine("AcquireTokenInteractive succeeded" + result.Account.Username);
// // }
// //
// // foreach (var account in accounts)
// // {
// //     Console.WriteLine("Account:" + account.Username);
// //     Console.WriteLine("Environment:" + account.Environment);
// //     Console.WriteLine("HomeAccountID:" + account.HomeAccountId);
// //     Console.WriteLine("AccessToken:" + app.AcquireTokenSilent(scopes, account).ExecuteAsync().Result.AccessToken);
// // }
// //
// // // Create a GraphServiceClient
// //
// // var graphClient = new GraphServiceClient();
// //
// // // Get the user's emails
// // var messages = await graphClient.Me.MailFolders.Inbox.Messages.Request().GetAsync();
// //
// // // Print the subject of each email
// // foreach (var message in messages)
// // {
// //     Console.WriteLine(message.Subject);
// // }
//
//
// using ConsoleApp1;
// using Microsoft.Graph;
// using Microsoft.Graph.Authentication;
// using Microsoft.Graph.Me.SendMail;
// using Microsoft.Graph.Models;
// using Microsoft.Identity.Client;
// using Microsoft.Kiota.Abstractions.Authentication;
//
// public class TokenProvider : IAccessTokenProvider
// {
//     private readonly IPublicClientApplication _pca;
//     private readonly string[] _scopes;
//
//     public TokenProvider(IPublicClientApplication pca, string[] scopes)
//     {
//         _pca = pca;
//         _scopes = scopes;
//     }
//
//     public async Task<string> GetAuthorizationTokenAsync(Uri uri,
//         Dictionary<string, object>? additionalAuthenticationContext = null,
//         CancellationToken cancellationToken = new CancellationToken())
//     {
//         // Get the account
//         var accounts = await _pca.GetAccountsAsync();
//         var firstAccount = accounts.FirstOrDefault();
//
//         // Try to get the token silently
//         try
//         {
//             var result = await _pca.AcquireTokenSilent(_scopes, firstAccount).ExecuteAsync(cancellationToken);
//             return result.AccessToken;
//         }
//         catch (MsalUiRequiredException)
//         {
//             // If silent acquisition fails, handle interactive acquisition
//             var result = await _pca.AcquireTokenInteractive(_scopes).ExecuteAsync(cancellationToken);
//             return result.AccessToken;
//         }
//     }
//
//     public AllowedHostsValidator AllowedHostsValidator { get; } = new AllowedHostsValidator();
// }
//
//
// public partial class Program
// {
//     private static readonly string ClientId = "f74157c8-597d-4fca-a284-bb3d01ff4a56";
//     private static readonly string ClientSecret = "<Your-Client-Secret>";
//     private static readonly string TenantId = "common";
//     private static readonly string AuthorizationCode = "<Your-Authorization-Code>";
//     private static readonly string RedirectUri = "http://localhost";
//     private static readonly string[] Scopes = new[] { "user.read" };
//
//    static async Task SendEmail(GraphServiceClient graphClient)
//     {
//         var message = new Message
//         {
//             Subject = "Hello from Microsoft Graph API",
//             Body = new ItemBody
//             {
//                 ContentType = BodyType.Text,
//                 Content = "This is the body of the email"
//             },
//             ToRecipients = new List<Recipient>
//             {
//                 new Recipient
//                 {
//                     EmailAddress = new EmailAddress
//                     {
//                         Address = "7stefanadrian@gmail.com"
//                     }
//                 }
//             }
//         };
//
//         var saveToSentItems = true;
//
//         try
//         {
//             await graphClient.Me.SendMail.PostAsync(new SendMailPostRequestBody
//                 {
//                     Message = message
//                 }
//             );
//
//
//             Console.WriteLine("Email sent successfully");
//         }
//         catch (ServiceException ex)
//         {
//             Console.WriteLine($"Error sending email: {ex.Message}");
//         }
//     }
//
//     public static void Main(string[] args)
//     {
//         var pcaOptions = new PublicClientApplicationOptions
//         {
//             ClientId = ClientId,
//             TenantId = TenantId,
//             RedirectUri = RedirectUri,
//         };
//
//         var pca = PublicClientApplicationBuilder
//             .CreateWithApplicationOptions(pcaOptions)
//             .Build();
//         var tokenProvider = new TokenProvider(pca, Scopes);
//         var authProvider = new BaseBearerTokenAuthenticationProvider(tokenProvider);
//
//
//         TokenCacheHelper.EnableSerialization(pca.UserTokenCache);
//
//         // Use the auth provider to create a new GraphServiceClient
//         var graphClient = new GraphServiceClient(authProvider);
//
//         Console.WriteLine("Graph client created" + graphClient.Users);
//
//         //make a request
//         var mails = graphClient.Me
//             // Only messages from Inbox folder
//             .MailFolders["Inbox"]
//             .Messages
//             .GetAsync((config) =>
//             {
//                 // Only request specific properties
//                 config.QueryParameters.Select = new[] { "from", "isRead", "receivedDateTime", "subject" };
//                 // Get at most 25 results
//                 config.QueryParameters.Top = 25;
//                 // Sort by received time, newest first
//                 config.QueryParameters.Orderby = new[] { "receivedDateTime DESC" };
//             });
//
//         foreach (var mail in mails.Result.Value)
//         {
//             Console.WriteLine("Mail:" + mail.Subject);
//         }
//         // Send an email
//          SendEmail(graphClient).Wait();
//         // Now you can use the graphClient to make requests
//     }
// }


//upload a file to s3 bucket

using AudiT.Domain.Entities;
using AudIT.Infrastructure;
using Microsoft.EntityFrameworkCore;

var context = new AudITContext();


//retrieve a institution

var newDepar = Department.Create(
    "departemant",
    "adress123",
    "123",
    context.Institutions.First()
);


var newActivity = Activity.Create(
    "activity",
    ActivityType.Mission,
    newDepar.Value,
    newDepar.Value.Id,
    context.Users.First(),
    Guid.Parse( context.Users.First().Id),
    context.AuditMissions.First().Id
).Value;


context.Add(newActivity);




//save the department
// context.Add(newDepar.Value);
context.SaveChanges();

//
// var obj_act = context.ObjectiveAction.Include(obj_act => obj_act.ActionRisks).First();
//
// //add a new action risk to the objective action
// var actionRisk = ActionRisk.Create(
//     "test risk",
//     Risk.Mare,
//     obj_act.Id
// ).Value;
//
//
// context.Add(actionRisk);
// context.SaveChanges();
//
//
//
//
// Console.WriteLine("Objective Activity:" + obj_act.Name);