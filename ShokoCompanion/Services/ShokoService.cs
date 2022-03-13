using Newtonsoft.Json;
using Shoko.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Services
{



    internal class ShokoService
    {
        private static ShokoService instance = null;
        private static readonly object padlock = new object();
        private static readonly HttpClient httpClient = new HttpClient();
        private static string BASE_URL = "http://192.168.0.22:8111";

        public static int USER_ID { get { return 1; } }

        ShokoService()
        {
        }

        public static ShokoService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ShokoService();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<CL_AnimeEpisode_User>> GetAllEpisodesWithMultipleFiles(long userID, bool onlyFinishedSeries, bool ignoreVariations)
        {
            var result = new List<CL_AnimeEpisode_User>();
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(BASE_URL + $"/v1/Episode/ForMultipleFiles/{userID}/{onlyFinishedSeries}/{ignoreVariations}")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<CL_AnimeEpisode_User>>(resultString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<List<CL_VideoDetailed>> GetFilesByGroupAndResolution(long? userID,long? animeID)
        {
            var result = new List<CL_VideoDetailed>();
            if(animeID == null || userID == null)
                return result;
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(BASE_URL + $"/v1/File/Detailed/{animeID}/{userID}")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<CL_VideoDetailed>>(resultString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<List<CL_VideoDetailed>> DeletePhysicalFile(long? videoLocalPlaceID)
        {
            var result = new List<CL_VideoDetailed>();
            try
            {
                using (HttpResponseMessage response = await httpClient.DeleteAsync(new Uri(BASE_URL + $"/v1/File/Physical/{videoLocalPlaceID}")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        internal Dictionary<CL_AnimeEpisode_User, List<CL_VideoDetailed>> GetEpisodesWithAllFilesSelected(List<long?> selected, Dictionary<CL_AnimeEpisode_User, List<CL_VideoDetailed>> episodes)
        {
            return episodes.Where(pair => pair.Value.All(file => selected.Contains(file.Places[0].VideoLocal_Place_ID))).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
