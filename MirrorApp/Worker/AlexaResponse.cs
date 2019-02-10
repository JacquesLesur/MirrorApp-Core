using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        YoutubeIntent();
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
            response.Response.ShouldEndSession = false;
        }

        private void YoutubeIntent()
        {
            string youtubeur = intentRequest.Intent.Slots.First().Value.Value;
            if (youtubeur != null)
            {
                response = ResponseBuilder.Tell("Dac je lance la vidéo de " + youtubeur);
            }
            else
            {
                response = ResponseBuilder.Tell("Je ne conais pas ce youtubeur");
            }
            response.Response.ShouldEndSession = false;
        }

        private void StopIntent()
        {
            response = ResponseBuilder.Tell("A+ tes canon mec <3");
            response.Response.ShouldEndSession = true;
        }
    }
}
