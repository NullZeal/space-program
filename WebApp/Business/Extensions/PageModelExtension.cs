﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using WebApp.Business.DtoModels;

namespace WebApp.Business.Extensions;

public static class PageModelExtension
{
    public static IActionResult ValidateConnectedUser(this PageModel someModel)
    {
        if (someModel.Request.Cookies["currentUser"] == null || someModel.Request.Cookies["currentUser"] == "")
        {
            return someModel.RedirectToPage("/user/login");
        }
        return null;
    }

    public async static Task<IActionResult> LoadSpaceStation(
        this PageModel someModel,
        HttpClient _httpClient,
        Guid spaceStationId,
        SpaceStationDto spaceStation,
        string error)
    {
        try
        {
            var httpGetResponse = await _httpClient.GetAsync($"https://localhost:7202/api/spacestation/{spaceStationId}");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            var fetchedSpaceStation = jsonObject["fetchedSpaceStation"];

            spaceStation.SpaceStationId = (Guid)fetchedSpaceStation["spaceStationId"];
            spaceStation.Name = (string)fetchedSpaceStation["name"];

            return null;
        }
        catch
        {
            error = "Error - Could not retrieve the Space Station.";
            return someModel.Page();
        }
    }

    public async static Task<IActionResult> LoadOfficer(
        this PageModel someModel,
        HttpClient _httpClient,
        Guid officerId,
        OfficerDto officer,
        string error)
    {
        try
        {
            var httpGetResponse = await _httpClient.GetAsync($"https://localhost:7202/api/officer/{officerId}");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            var fetchedOfficer = jsonObject["fetchedOfficer"];

            officer.OfficerId = (Guid)fetchedOfficer["officerId"];
            officer.Name = (string)fetchedOfficer["name"];
            officer.Rank = (string)fetchedOfficer["rank"];
            officer.SpaceStationId = (Guid)fetchedOfficer["spaceStationId"];
            
            return null;
        }
        catch
        {
            error = "Error - Could not retrieve the Officer.";
            return someModel.Page();
        }
    }

    public async static Task<IActionResult> LoadSpaceStations(
        this PageModel someModel, 
        HttpClient _httpClient, 
        List<SpaceStationDto> spaceStations,
        string error)
    {
        try
        {
            var httpGetResponse = await _httpClient.GetAsync("https://localhost:7202/api/spacestation");
            httpGetResponse.EnsureSuccessStatusCode();

            var responseString = await httpGetResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseString);

            foreach (var spaceStation in jsonObject["fetchedSpaceStations"])
            {
                spaceStations.Add(new SpaceStationDto((Guid)spaceStation["spaceStationId"], spaceStation["name"].ToString()));
            }
            return null;
        }
        catch
        {
            error = "Error - Could not retrieve the existing Space Stations.";
            return someModel.Page();
        }
    }
}