﻿using Newtonsoft.Json;
using ShokoCompanion.Models;
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

        public async Task<List<ShokoAnimeEpisode>> GetAllEpisodesWithMultipleFiles(int userID, bool onlyFinishedSeries, bool ignoreVariations)
        {
            var result = new List<ShokoAnimeEpisode>();
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(BASE_URL + $"/v1/Episode/ForMultipleFiles/{userID}/{onlyFinishedSeries}/{ignoreVariations}")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<ShokoAnimeEpisode>>(resultString);
                    }
                }
            }
            catch (Exception ex)
            {
                // need to return ex.message for display.
                throw ex;
            }
            return result;
        }

        public async Task<List<ShokoVideoDetailed>> GetFilesByGroupAndResolution(int animeID,int userID)
        {
            var result = new List<ShokoVideoDetailed>();
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(BASE_URL + $"/v1/File/Detailed/{animeID}/{userID}")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<ShokoVideoDetailed>>(resultString);
                    }
                }
            }
            catch (Exception ex)
            {
                // need to return ex.message for display.
                throw ex;
            }
            return result;
        }
    }
}