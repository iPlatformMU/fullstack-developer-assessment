using FoursquareTest.Data;
using FoursquareTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Web.Http;
using System.Xml.Serialization;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace FoursquareTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(List<Result> model)
        {
            var fromDatabaseEF = new SelectList(_db.Places?.ToList(), "Id", "Name");
            ViewData["Places"] = fromDatabaseEF;
            ViewData["FourplacesPlaces"] = new List<Result>();

            if(model==null)
                model = new List<Result>();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<Result[]> GetPlacesFromFoursquare(string place)
        {
            FoursquarePlaces foursquarePlaces = new FoursquarePlaces();

            var client = new RestClient($"https://api.foursquare.com/v3/places/search?query={place}");
            var request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "fsq3jBZmlh/xLErkwNS1mJxwJc8WSDYHDjO1U2wlR7ccSE4=");
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                try
                {
                    foursquarePlaces = Newtonsoft.Json.JsonConvert.DeserializeObject<FoursquarePlaces>(response.Content);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Could not deserialise response from Foursquare");
                }
            }

            if(!foursquarePlaces.results.Any())
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent(string.Format("No place found for = {0}", place)),
                    ReasonPhrase = "Could not found any place"
                };
                throw new HttpResponseException(resp);
            }

            var filterResp = foursquarePlaces.results.GroupBy(x => new { x.name, x.geocodes.main.latitude, x.geocodes.main.longitude })
               .Select(group => group.First()).ToArray();

            return filterResp;
        }


        [HttpGet]
        public async Task<List<FlickrPhoto>> GetFlickrImages(string latitude, string longitude)
        {
            List<FlickrPhoto> placeImages = new List<FlickrPhoto>();

            var apiurl = $"https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=ca370d51a054836007519a00ff4ce59e&1&lat={latitude}&lon={longitude}";

            var client = new RestClient(apiurl);
            var request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                try
                {
                    var res = FromXml<rsp>(response.Content);

                    if(res.stat == "ok")
                    {
                        res.photos?.photo.ToList().ForEach(x => placeImages.Add(new FlickrPhoto()
                        {
                            Title = x.title,
                            ImageUri = $"https://live.staticflickr.com/{x.server}/{x.id}_{x.secret}.jpg"
                        }));
                    }
                    else 
                    {
                        var resp = new HttpResponseMessage(HttpStatusCode.Conflict)
                        {
                            Content = new StringContent("Response from Flikr KO"),
                            ReasonPhrase = "Flickr could not process request."
                        };

                        throw new HttpResponseException(resp);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Could not deserialise response from Foursquare");
                }
            }

            if (!placeImages.Any())
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent(string.Format("No images could be retrieved from lat: {0}, lon: {1}", latitude, longitude)),
                    ReasonPhrase = "No photos found."
                };
                throw new HttpResponseException(resp);
            }


            return placeImages;
        }

        protected T FromXml<T>(string xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return returnedXmlClass;
        }


    }
}