using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.CloudRail.SI;
using Com.CloudRail.SI.Services;
using Com.CloudRail.SI.ServiceCode.Commands.CodeRedirect;
using Com.CloudRail.SI.Types;
using MirrorApp.Hubs;
using MirrorApp.Controllers;

namespace MirrorApp.Worker
{
    public class AlexaResponse
    {
        private IntentRequest intentRequest;
        public SkillResponse response { get; set; }

        public AlexaResponse(SkillRequest input)
        {
            intentRequest = input.Request as IntentRequest;



            if (input.Session.New)
            {
                response = ResponseBuilder.Tell("Bonjour Jacques, que veux-tu faire avec ton miroir ?");
            }
            else
            {
                response = ResponseBuilder.Tell("Désolé, je n'ai pas compris");
            }
            response.Response.ShouldEndSession = false;


            if (intentRequest != null)
            {
                switch (intentRequest.Intent.Name)
                {
                    case "youtube":
                        YoutubeIntentAsync();
                        break;
                    case "AMAZON.StopIntent":
                        StopIntent();
                        break;
                    case "Kaamelott":
                        KaamelottIntent();
                        break;
                    default:
                        break;
                }
            }

        }

        private void KaamelottIntent()
        {
            response = ResponseBuilder.Tell("Je rafraichis la citation de Kaamelott");
            HomeController homeController = new HomeController();
            Config.citation =homeController.Kaamelott();
            response.Response.ShouldEndSession = false;
        }

        private async Task YoutubeIntentAsync()
        {
            CloudRail.AppKey = Config.cloudRailApiKey;

            YouTube service = new YouTube(
                new LocalReceiver(8082),
                Config.youtubeApiKey

            );

            
            string youtubeur = intentRequest.Intent.Slots.First().Value.Value;
            if (youtubeur != null)
            {
                response = ResponseBuilder.Tell("Dac je lance la vidéo de " + youtubeur);
                List<VideoMetaData> listVideoYoutube = service.SearchVideos(
                youtubeur,
                50,
                10
                );
                Random rnd = new Random();
                int numYtVideo = rnd.Next(listVideoYoutube.Count);
                Config.youtubeUrl = "https://www.youtube.com/embed/" + listVideoYoutube[numYtVideo].GetId()+ "?autoplay=1";
            }
            else
            {
                response = ResponseBuilder.Tell("Je ne conais pas ce youtubeur");
            }



            //VideolinkHub videolinkHub = new VideolinkHub();
            // await videolinkHub.ChangeVideoLink(Config.youtubeUrl);
            response.Response.ShouldEndSession = false;
        }

        private void StopIntent()
        {
            response = ResponseBuilder.Tell("A+ tes canon mec <3");
            response.Response.ShouldEndSession = true;
        }
    }
}
